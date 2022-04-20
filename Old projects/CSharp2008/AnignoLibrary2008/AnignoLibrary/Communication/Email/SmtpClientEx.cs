using System.Net.Mail;
using LoggingProvider;

namespace AnignoLibrary.Communication.Email
{
    /// <summary>
    /// Expends SmtpClient, add unique SmtpClientId
    /// </summary>
    public class SmtpClientEx : SmtpClient
    {
        private static int SmtpClientUniqueId;
        public readonly int SmtpClientId = SmtpClientUniqueId++;
        public readonly string FromEmail;
        public readonly int TimeOutSec;

        public SmtpClientEx(string host, int port, int timeoutSec, string fromEmail)
            : base(host, port)
        {
            FromEmail = fromEmail;
            TimeOutSec = Timeout = timeoutSec * 1000;
            Logger.LogDebug("fromEmail: {0} timeout: {1}", fromEmail, timeoutSec);
        }

    }
}