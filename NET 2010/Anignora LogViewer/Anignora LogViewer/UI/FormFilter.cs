using System;
using System.Windows.Forms;
using Anignora_LogViewer.BL.Filtering;

namespace Anignora_LogViewer.UI
{
    public partial class FormFilter : Form
    {
        private readonly string[] m_existingFiltersNames;
        public FilterData FilterDataItem { get; private set; }

        public FormFilter()
        {
            InitializeComponent();
        }

        public FormFilter(FilterData p_filterData,string[] p_existingFiltersNames)
            : this()
        {
            m_existingFiltersNames = p_existingFiltersNames;
            FilterDataItem = p_filterData;
            updateControlsFromFilterData(FilterDataItem);
        }

        private void updateControlsFromFilterData(FilterData p_filterData)
        {
            textBoxFilterName.Text=p_filterData.FilterName  ;
            checkBoxFilterNegative.Checked=p_filterData.FilterNegative  ;

            textBoxLoger.Text=p_filterData.LoggerText  ;
            checkBoxLogerNegative.Checked=p_filterData.LoggerNegative  ;

            textBoxType.Text=p_filterData.TypeText  ;
            checkBoxTypeNegative.Checked=p_filterData.TypeNegative  ;

            textBoxMethod.Text=p_filterData.MethodText  ;
            checkBoxMethodNegative.Checked=p_filterData.MethodNegative  ;

            textBoxMessage.Text=p_filterData.MessageText ;
            checkBoxMessageNegative.Checked=p_filterData.MessageNegative  ;

            textBoxThread.Text=p_filterData.ThreadText  ;
            checkBoxThreadNegative.Checked=p_filterData.ThreadNegative  ;

            checkBoxDebug.Checked=p_filterData.Debug  ;
            checkBoxInfo.Checked=p_filterData.Info  ;
            checkBoxWarn.Checked=p_filterData.Warn  ;
            checkBoxError.Checked=p_filterData.Error  ;
            checkBoxFatal.Checked=p_filterData.Fatal  ;
        }


        private void onButtonOkClick(object sender, EventArgs e)
        {
            FilterDataItem.FilterName=textBoxFilterName.Text;
            FilterDataItem.FilterNegative = checkBoxFilterNegative.Checked;

            FilterDataItem.LoggerText = textBoxLoger.Text;
            FilterDataItem.LoggerNegative = checkBoxLogerNegative.Checked;

            FilterDataItem.TypeText = textBoxType.Text;
            FilterDataItem.TypeNegative = checkBoxTypeNegative.Checked;

            FilterDataItem.MethodText = textBoxMethod.Text;
            FilterDataItem.MethodNegative = checkBoxMethodNegative.Checked;

            FilterDataItem.MessageText = textBoxMessage.Text;
            FilterDataItem.MessageNegative = checkBoxMessageNegative.Checked;

            FilterDataItem.ThreadText = textBoxThread.Text;
            FilterDataItem.ThreadNegative = checkBoxThreadNegative.Checked;

            FilterDataItem.Debug = checkBoxDebug.Checked;
            FilterDataItem.Info = checkBoxInfo.Checked;
            FilterDataItem.Warn = checkBoxWarn.Checked;
            FilterDataItem.Error = checkBoxError.Checked;
            FilterDataItem.Fatal = checkBoxFatal.Checked;
        }

        private void textBoxFilterName_TextChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = false;
            if (textBoxFilterName.Text != "") buttonOK.Enabled = true;
        }
    }
}
