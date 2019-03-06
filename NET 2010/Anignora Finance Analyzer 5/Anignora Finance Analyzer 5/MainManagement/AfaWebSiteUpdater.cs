using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AfaDataExtraction;
using AfaDataExtraction.Contango;
using AnignoraCommunication.FTP.FtpByWebRequest;
using AnignoraDataTypes;
using AnignoraDataTypes.HtmlReporting;
using AnignoraFinanceAnalyzer5.Systems;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstAnalyzer;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using AnignoraProcesses;
using log4net;

namespace AnignoraFinanceAnalyzer5.MainManagement
{
    public class AfaWebSiteUpdater
    {
        #region (------  Constants  ------)
        private const string ACTIVE_SIGNALED_RESULT_BG_COLOR = "#444488";
        private const string ACTIVE_OPTION_SIGNALED_RESULT_BG_COLOR = "#884444";
        private const string ACTIVE_RESULT_BG_COLOR = "#555555";
        private const string ACTIVE_RESULT_TEXT_COLOR = "#FFFFFF";
        private const string GREEN = "#88FF88";
        //private const string HIDDEN_RESULT_TEXT_COLOR = "#111111";
        private const string PAGE_BACKGROUND_COLOR = "#000000";
        private const string PAGE_TEXT_COLOR = "#FFFFFF";
        private const string RED = "#FF8888";
        private const string SYMBOLS_HTML_FILE = "symbols.html";
        private const string SYSTEMS_HTML_FILE = "systems.html";
        //private const string WHITE = "#FFFFFF";
        private const string HIT_YELLOW = "#FFFF88";
        private const string MISS_YELLOW = "#FFFF55";
        #endregion (------  Constants  ------)

        #region (------  Fields  ------)
        private readonly ASCIIEncoding m_asciiEncoding = new ASCIIEncoding();
        private readonly string m_baseDirectory;
        private readonly DateTime m_noUpdateStartTime;
        private readonly DateTime m_noUpdateEndTime;
        private readonly ContangoManager m_contangoManager;
        private readonly AfaSystemBase m_contangoStartShorts;
        //private readonly AfaSystemBase m_contangoStartLongs;
        private readonly ExtractionManager m_extractionManager;
        private readonly FtpWebRequestClient m_ftpClient;
        private readonly AfaSystemBase[] m_systems;
        private readonly ThreadInterlocked m_threadInterlocked;
        private static readonly ILog s_log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion (------  Fields  ------)

        #region (------  Constructors  ------)
        public AfaWebSiteUpdater(
            AfaSystemBase[] p_systems,
            ExtractionManager p_extractionManager,
            int p_periodicUpdateIntervalMs,
            string p_ftpServer,
            string p_username,
            string p_password,
            string p_baseDirectory,
            DateTime p_noUpdateStartTime,
            DateTime p_noUpdateEndTime,
            ContangoManager p_contangoManager,
            AfaSystemBase p_contangoStartShorts
            /*,AfaSystemBase p_contangoStartLongs*/)
        {
            m_systems = p_systems;
            m_extractionManager = p_extractionManager;
            m_ftpClient = new FtpWebRequestClient(p_ftpServer, p_username, p_password);
            m_ftpClient.FtpFileUploaded += onFtpClientFtpFileUploaded;
            m_baseDirectory = p_baseDirectory;
            m_noUpdateStartTime = p_noUpdateStartTime;
            m_noUpdateEndTime = p_noUpdateEndTime;
            m_contangoManager = p_contangoManager;
            m_contangoStartShorts = p_contangoStartShorts;
            //m_contangoStartLongs = p_contangoStartLongs;
            m_threadInterlocked = new ThreadInterlocked("AfaWebSiteUpdater", ftpAction, true, p_periodicUpdateIntervalMs);
        }

        void onFtpClientFtpFileUploaded(object p_sender, FtpFileTransferEventArgs p_e)
        {
            if (!p_e.IsSucceeded)
            {
                s_log.ErrorFormat("RemoteFile:{0} failed  {1}", p_e.RemoteFile, p_e.ErrorMessage);
            }
        }
        #endregion (------  Constructors  ------)

        #region (------  Public Methods  ------)
        public void Start()
        {
            m_threadInterlocked.Start();
        }
        #endregion (------  Public Methods  ------)

        #region (------  Private Methods  ------)
        private TagTd createColoredTd(string p_innerText, string p_textColor)
        {
            TagTd td = new TagTd();
            Tag font = new Tag("Font");
            td.AddTag(font);
            font.AddAttribute(new TagAttribute("color", p_textColor));
            font.InnerText = p_innerText;
            return td;
        }

        private string createSymbolsHtml(ExtractionManager p_extractionManager)
        {
            HtmlReporter reporter = new HtmlReporter();
            Tag body = reporter.HtmlTag.AddTag(new TagBody());
            body.AddAttribute(new TagAttribute("bgcolor", PAGE_BACKGROUND_COLOR));
            body.AddAttribute(new TagAttribute("text", PAGE_TEXT_COLOR));
            body.AddAttribute(new TagAttribute("link", "#EEEEEE"));
            body.AddAttribute(new TagAttribute("vlink", "#EEEEEE"));

            string licenseString = FirstAnalyzerProtector.GetLicensedDate().ToString();
            string dateNow = DateTime.Now.ToString("dd/MM/yyy HH:mm");
            string computerName = Environment.MachineName;
            body.InnerText = string.Format("{0}   [{1}.{2}] [{3}]", dateNow, Application.ProductVersion, licenseString, computerName);

            Tag symbolsTable = body.AddTag(new TagTable());
            body.AddTag(new TagBr());
            symbolsTable.AddAttribute(new TagAttribute("border", "1"));
            symbolsTable.AddAttribute(new TagAttribute("width", "200"));
            Tag tagTrHeader = symbolsTable.AddTag(new TagTr());
            tagTrHeader.AddTag(new TagTd { InnerText = "Symbol" });
            tagTrHeader.AddTag(new TagTd { InnerText = "Close" });
            tagTrHeader.AddTag(new TagTd { InnerText = "DailyChange%" });
            tagTrHeader.AddTag(new TagTd { InnerText = "MAD" });

            Dictionary<string, SymbolExtractedData> recentData = p_extractionManager.GetSymbolsRecentData();
            foreach (KeyValuePair<string, SymbolExtractedData> data in recentData)
            {
                Tag tagTr = symbolsTable.AddTag(new TagTr());
                tagTr.AddTag(new TagTd { InnerText = data.Key });
                tagTr.AddTag(new TagTd { InnerText = data.Value.Close.ToString("0.00") });
                string dailyColor = data.Value.DailyChangePerRecent < 0 ? RED : GREEN;
                tagTr.AddTag(createColoredTd(data.Value.DailyChangePerRecent.ToString("0.00%"), dailyColor));
                if (data.Key.ToUpper().Contains("VXX"))
                {
                    tagTr.AddTag(new TagTd { InnerText = data.Value.MovAvgDiff.ToString("0.00") });
                }
            }

            body.AddTag(new TagBr());
            Tag contangoDivTag = body.AddTag(new Tag("Div"));
            ContangoExtractedData contangoData = m_contangoManager.GetLastContangoData();
            string sContango = string.Format("Va:{0} Vb:{1} curC:{2:0.000}", contangoData.ValueA, contangoData.ValueB, contangoData.ContangoValue);
            contangoDivTag.InnerText = sContango;
            return reporter.Report;
        }

        private Tag createContangoStartDivTag(AfaSystemBase p_contangoShortsSystem/*, AfaSystemBase p_contangoLongsSystem*/, ContangoManager p_contangoManager)
        {
            Tag contangoStartTag = new Tag("Div");
            FirstCalculatorResult[] resultsShorts = p_contangoShortsSystem.GetSymbolCalculatedResults("VXX");
            //FirstCalculatorResult[] resultsLongs = p_contangoLongsSystem.GetSymbolCalculatedResults("VXX");
            ContangoExtractedData previousContangoData = p_contangoManager.GetPreviousToLastContangoData();
            if (previousContangoData == null) return contangoStartTag;
            float vs = -1 /*,vl = -1*/;
            if (resultsShorts.Length > 0)
            {
                vs = resultsShorts.First().CIntraStart;
            }
            //if (resultsLongs.Length > 0)
            //{
            //    vl = resultsLongs[0].CIntraStart;
            //}
            Tag tagTable = contangoStartTag.AddTag(new TagTable());
            tagTable.AddAttribute(new TagAttribute("border", "1"));
            Tag tagTr = tagTable.AddTag(new TagTr());
            tagTr.AddAttribute(new TagAttribute("bgcolor", ACTIVE_RESULT_BG_COLOR));
            tagTr.AddTag(createColoredTd("PrevC: " + previousContangoData.ContangoValue.ToString("0.000"), ACTIVE_RESULT_TEXT_COLOR));
            tagTr.AddTag(createColoredTd("CShortsStart: " + vs, ACTIVE_RESULT_TEXT_COLOR));
            //tagTr.AddTag(createColoredTd("CLongsStart: " + vl, ACTIVE_RESULT_TEXT_COLOR));
            return contangoStartTag;
        }

        private void addSignalsOnlyData(Tag p_signalsDivTag, AfaSystemBase[] p_systems)
        {
            Tag systemTableTag = p_signalsDivTag.AddTag(new TagTable());
            systemTableTag.AddAttribute(new TagAttribute("border", "1"));
            systemTableTag.AddAttribute(new TagAttribute("width", "450"));
            //Headers
            Tag tr = systemTableTag.AddTag(new TagTr());
            tr.AddAttribute(new TagAttribute("bgcolor", ACTIVE_RESULT_BG_COLOR));
            tr.AddTag(new TagTd { InnerText = "System" });
            tr.AddTag(new TagTd { InnerText = "Symbol" });
            tr.AddTag(new TagTd { InnerText = "Date" });
            tr.AddTag(new TagTd { InnerText = "Daily%" });
            tr.AddTag(new TagTd { InnerText = "Signal" });
            tr.AddTag(new TagTd { InnerText = "Profit%" });
            tr.AddTag(new TagTd { InnerText = "DTC" });
            tr.AddTag(new TagTd { InnerText = "Weight%" });
            tr.AddTag(new TagTd { InnerText = "Result" });
            tr.AddTag(new TagTd { InnerText = "PCut" });
            tr.AddTag(new TagTd { InnerText = "LCut" });
            tr.AddTag(new TagTd { InnerText = "CSt" });
            if (!isUpdateAllow())
            {
                tr = systemTableTag.AddTag(new TagTr());
                Tag noDataTd = tr.AddTag(createColoredTd("Full data is not displayed during market time", ACTIVE_RESULT_TEXT_COLOR));
                noDataTd.AddAttribute(new TagAttribute("colspan", "10"));

            }
            foreach (AfaSystemBase system in p_systems)
            {
                foreach (FirstCalculatorResult result in system.GetRecentActiveResultsForWeb())
                {
                    string symbolName = result.FirstAnalyzeResultItem.SymbolExtractedDataItem.WebName;
                    if (!system.ProfitSymbol.Contains(symbolName)) continue;
                    tr = systemTableTag.AddTag(new TagTr());

                    if (!isUpdateAllow() && result.SignalResult == SignalResultEnum.None)
                    {
                        //tr.AddTag(createColoredTd(system.SystemName, ACTIVE_RESULT_TEXT_COLOR));
                        //Tag noDataTd= tr.AddTag(createColoredTd("No Data during market time", ACTIVE_RESULT_TEXT_COLOR));
                        //noDataTd.AddAttribute(new TagAttribute("colspan","9"));
                        continue;
                    }

                    bool isNewSignal = result.SignalType != SignalTypeEnum.None && result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead.Date == DateTime.Now.Date;
                    string trBackcolor = isNewSignal ? ACTIVE_SIGNALED_RESULT_BG_COLOR : ACTIVE_RESULT_BG_COLOR;

                    //If signaled and options system color orange
                    if (isNewSignal && system.SystemName.ToUpper().Contains("OPTIONS")) trBackcolor = ACTIVE_OPTION_SIGNALED_RESULT_BG_COLOR;

                    tr.AddAttribute(new TagAttribute("bgcolor", trBackcolor));
                    tr.AddTag(createColoredTd(system.SystemName, ACTIVE_RESULT_TEXT_COLOR));
                    symbolName += " " + system.RegularMultiplier;
                    tr.AddTag(createColoredTd(symbolName, ACTIVE_RESULT_TEXT_COLOR));
                    tr.AddTag(createColoredTd(result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead.ToString("dd/MM/yy"), ACTIVE_RESULT_TEXT_COLOR));
                    float dailyChangePerRecent = result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DailyChangePerRecent;
                    tr.AddTag(createColoredTd(dailyChangePerRecent.ToString("0.00%"), dailyChangePerRecent > 0 ? GREEN : RED));
                    tr.AddTag(createColoredTd(result.SignalType.ToString(), ACTIVE_RESULT_TEXT_COLOR));
                    string profit = result.ProfitPer.ToString("0.00%");
                    if (profit == "0.00%") profit = "&nbsp;";
                    tr.AddTag(createColoredTd(profit, result.ProfitPer > 0 ? GREEN : RED));

                    tr.AddTag(createColoredTd(result.DaysToClose.ToString("0"), ACTIVE_RESULT_TEXT_COLOR));

                    
                    tr.AddTag(createColoredTd(result.SignalWeight.ToString("0.00%"), ACTIVE_RESULT_TEXT_COLOR));
                    string signalResult = result.SignalResult.ToString();
                    if (signalResult == "None") signalResult = "&nbsp;";
                    tr.AddTag(createColoredTd(signalResult, result.SignalResult == SignalResultEnum.Hit ? HIT_YELLOW : MISS_YELLOW));

                    tr.AddTag(createColoredTd(result.ProfitCut.ToString("0.00"), ACTIVE_RESULT_TEXT_COLOR));
                    tr.AddTag(createColoredTd(result.LossCut.ToString("0.00"), ACTIVE_RESULT_TEXT_COLOR));
                    tr.AddTag(createColoredTd(result.CIntraStart.ToString("0.00"), ACTIVE_RESULT_TEXT_COLOR));
                }
            }

        }

        private string createSystemsHtmlString(AfaSystemBase[] p_systems)
        {
            HtmlReporter reporter = new HtmlReporter();
            Tag body = reporter.HtmlTag.AddTag(new TagBody());
            body.AddAttribute(new TagAttribute("bgcolor", PAGE_BACKGROUND_COLOR));
            body.AddAttribute(new TagAttribute("text", PAGE_TEXT_COLOR));
            body.AddAttribute(new TagAttribute("link", "#EEEEEE"));
            body.AddAttribute(new TagAttribute("vlink", "#EEEEEE"));

            string licenseString = FirstAnalyzerProtector.GetLicensedDate().ToString();
            string dateNow = DateTime.Now.ToString("dd/MM/yyy HH:mm");
            string computerName = Environment.MachineName;
            body.InnerText = string.Format("{0}   [{1}.{2}] [{3}]", dateNow, Application.ProductVersion, licenseString, computerName);

            body.AddTag(new TagBr());
            body.AddTag(new TagBr());
            Tag signalsHeadersDiv = body.AddTag(new Tag("DIV"));
            signalsHeadersDiv.InnerText = "Signals:";
            Tag signalsTag = body.AddTag(new Tag("DIV"));
            //Add profit symbols signals only
            addSignalsOnlyData(signalsTag, p_systems);

            if (m_contangoStartShorts != null/* && m_contangoStartLongs != null*/)
            {
                Tag contangoStartDivTag = createContangoStartDivTag(m_contangoStartShorts/*, m_contangoStartLongs*/, m_contangoManager);
                body.AddTag(contangoStartDivTag);
            }
            body.AddTag(new TagBr());
            body.AddTag(new TagBr());
            body.AddTag(new TagBr());

            return reporter.Report;
            //Tag systemsHeaderDiv = body.AddTag(new Tag("DIV"));

            //systemsHeaderDiv.InnerText = "Systems:";
            //foreach (AfaSystemBase system in p_systems)
            //{
            //    Tag systemTableTag = body.AddTag(new TagTable());
            //    systemTableTag.AddAttribute(new TagAttribute("border", "1"));
            //    systemTableTag.AddAttribute(new TagAttribute("width", "450"));
            //    //Ststem name
            //    Tag tr = systemTableTag.AddTag(new TagTr());
            //    Tag td=tr.AddTag(new TagTd());
            //    td.AddAttribute(new TagAttribute("colspan", "9"));
            //    td.InnerText = system.SystemName;
            //    //Headers
            //    tr = systemTableTag.AddTag(new TagTr());
            //    tr.AddTag(new TagTd { InnerText = "Symbol" });
            //    tr.AddTag(new TagTd { InnerText = "Date" });
            //    tr.AddTag(new TagTd { InnerText = "Daily%" });
            //    tr.AddTag(new TagTd { InnerText = "Signal" });
            //    tr.AddTag(new TagTd { InnerText = "Profit%" });
            //    tr.AddTag(new TagTd { InnerText = "Weight%" });
            //    tr.AddTag(new TagTd { InnerText = "Result" });
            //    tr.AddTag(new TagTd { InnerText = "PCut" });
            //    tr.AddTag(new TagTd { InnerText = "LCut" });

            //    float dailyChangePer = 0;
            //    float totalProfitPer = 0;
            //    foreach (FirstCalculatorResult result in system.GetRecentActiveResultsForWeb())
            //    {
            //        tr = systemTableTag.AddTag(new TagTr());
            //        string textColor = HIDDEN_RESULT_TEXT_COLOR;
            //        if (result.SignalWeight > 0)
            //        {
            //            textColor = ACTIVE_RESULT_TEXT_COLOR;
            //            tr.AddAttribute(new TagAttribute("bgcolor", ACTIVE_RESULT_BG_COLOR));

            //        }
            //        tr.AddTag(createColoredTd(result.FirstAnalyzeResultItem.SymbolExtractedDataItem.WebName, textColor));
            //        tr.AddTag(createColoredTd(result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead.ToString("dd/MM/yy"), textColor));
            //        tr.AddTag(createColoredTd(result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DailyChangePerRecent.ToString("0.00%"), textColor));
            //        tr.AddTag(createColoredTd(result.SignalType.ToString(), textColor));
            //        string profit = result.ProfitPer.ToString("0.00%");
            //        if (profit == "0.00%") profit = "&nbsp;";
            //        tr.AddTag(createColoredTd(profit, textColor));
            //        tr.AddTag(createColoredTd(result.SignalWeight.ToString("0.00%"), textColor));
            //        string signalResult = result.SignalResult.ToString();
            //        if (signalResult == "None") signalResult = "&nbsp;";
            //        tr.AddTag(createColoredTd(signalResult, textColor));

            //        tr.AddTag(createColoredTd(result.ProfitCut.ToString("0.00"), textColor));
            //        tr.AddTag(createColoredTd(result.LossCut.ToString("0.00"), textColor));


            //        //Calculate totals
            //        float signalMul = result.SignalType == SignalTypeEnum.Short ? -1 : 1;
            //        if (result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead.Date != DateTime.Now.Date)
            //        {
            //            dailyChangePer += result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DailyChangePerRecent*signalMul*result.SignalWeight;
            //        }
            //        totalProfitPer += result.ProfitPer*result.SignalWeight;
            //    }

            //    tr = systemTableTag.AddTag(new TagTr());
            //    string sTotal = "Total%: " + totalProfitPer.ToString("0.00%");
            //    string sDaily = "Daily%: " + dailyChangePer.ToString("0.00%");
            //    Tag tagTotal;
            //    Tag tagDaily;
            //    //colored total profit
            //    if (totalProfitPer < 0)
            //        tagTotal = tr.AddTag(createColoredTd(sTotal, RED));
            //    else if (totalProfitPer > 0)
            //        tagTotal = tr.AddTag(createColoredTd(sTotal, GREEN));
            //    else
            //        tagTotal = tr.AddTag(createColoredTd(sTotal, WHITE));

            //    //colored daily profit
            //    if (dailyChangePer < 0)
            //        tagDaily = tr.AddTag(createColoredTd(sDaily, RED));
            //    else if (dailyChangePer > 0)
            //        tagDaily = tr.AddTag(createColoredTd(sDaily, GREEN));
            //    else
            //        tagDaily = tr.AddTag(createColoredTd(sDaily, WHITE));

            //    //add totals td's
            //    tagDaily.AddAttribute(new TagAttribute("colspan", "5"));
            //    tagTotal.AddAttribute(new TagAttribute("colspan", "4"));
            //    body.AddTag(new TagBr());
            //}
            ////File.WriteAllText("1.html",reporter.Report);
            //return reporter.Report;
        }

        private bool isUpdateAllow()
        {
            DateTime currentTime = DateTime.Now.Time();
            if (currentTime > m_noUpdateStartTime && currentTime < m_noUpdateEndTime) return false;
            return true;
        }

        private void ftpAction()
        {
            string systemsHtml;
            string symbolsHtml;
            s_log.DebugFormat("Will update web site for:{0}", m_baseDirectory);
            systemsHtml = createSystemsHtmlString(m_systems);
            symbolsHtml = createSymbolsHtml(m_extractionManager);
            byte[] bytes = m_asciiEncoding.GetBytes(systemsHtml);
            MemoryStream ms = new MemoryStream();
            ms.Write(bytes, 0, bytes.Length);
            long continuteFlag = 1;
            m_ftpClient.UploadStream(ms, m_baseDirectory + "/" + SYSTEMS_HTML_FILE, ref continuteFlag);
            s_log.DebugFormat(systemsHtml);

            bytes = m_asciiEncoding.GetBytes(symbolsHtml);
            ms = new MemoryStream();
            ms.Write(bytes, 0, bytes.Length);
            m_ftpClient.UploadStream(ms, m_baseDirectory + "/" + SYMBOLS_HTML_FILE, ref continuteFlag);
            s_log.DebugFormat(symbolsHtml);
        }

        #endregion (------  Private Methods  ------)
    }
}
