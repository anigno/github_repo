using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using AnignoraDataTypes.Configurations;
using Common;
using SamplesProviders.Configuration;

namespace SamplesProviders
{
    public class SerialBytesSamplesProvider : DataProviderBase
    {
        #region Constructors

        public SerialBytesSamplesProvider()
        {
            ConfiguratorXml<SerialBytesSamplesProvidersConfig> configurator = new ConfiguratorXml<SerialBytesSamplesProvidersConfig>("SerialBytesSamplesProvidersConfig.XML");
            m_configuration = configurator.Configuration;
        }

        #endregion

        #region Protected Methods

        protected override Result StartInit()
        {
            try
            {
                m_port = new SerialPort(m_configuration.CommPort, m_configuration.BaudRate, m_configuration.Parity, m_configuration.DataBits);
                m_port.Open();
                Task.Factory.StartNew(SerialReadHandler);
                return new Result(ResultEnum.Passed);
            }
            catch (Exception ex)
            {
                return new Result(ResultEnum.Failed, ex.Message, ex);
            }
        }

        protected override void StopInit()
        {
            m_cancellationTokenSource.Cancel(false);
            if (m_port == null) return;
            if (m_port.IsOpen) m_port.Close();
            m_port.Dispose();
        }

        #endregion

        #region Private Methods

        private async void SerialReadHandler()
        {
            if (m_cancellationTokenSource == null || m_cancellationTokenSource.IsCancellationRequested) m_cancellationTokenSource = new CancellationTokenSource();
            while (!m_cancellationTokenSource.Token.IsCancellationRequested)
            {
                await Task.Delay(100, m_cancellationTokenSource.Token);
                int bytesToRead = m_port.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                m_port.Read(buffer, 0, bytesToRead);
                float[] floats = CommonHelper.Map(buffer, m_configuration.FromLow, m_configuration.FromHigh, m_configuration.ToLow, m_configuration.ToHigh);
                OnSamplesSubject.OnNext(floats);
            }
        }

        #endregion

        #region Fields

        private readonly SerialBytesSamplesProvidersConfig m_configuration;
        private SerialPort m_port;
        private CancellationTokenSource m_cancellationTokenSource;

        #endregion
    }
}