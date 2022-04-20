using System.Collections.Generic;
using System.Net.Mail;
using System;
using LoggingProvider;

namespace AnignoLibrary.Communication.Email
{
    public class EmailSender
    {
		#region (------  Fields  ------)

        private readonly Dictionary<int, SmtpClientEx> _activeSmtpClients = new Dictionary<int, SmtpClientEx>();

		#endregion (------  Fields  ------)

		#region (------  Events  ------)

        public event EmailSenderEventHandler OnCanceled;

        public event EmailSenderEventHandler OnError;

        public event EmailSenderEventHandler OnSuccessfulySent;

		#endregion (------  Events  ------)

		#region (------  Delegates  ------)

        public delegate void EmailSenderEventHandler(int smtpClientId, object extraData);

		#endregion (------  Delegates  ------)

		#region (------  Properties  ------)

        public static string LastError { get; set; }

		#endregion (------  Properties  ------)

		#region (------  Event Handlers  ------)

        private void smtpClientEx_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Logger.Log();
            int smtpClientId = (int)e.UserState;
            lock (_activeSmtpClients)
            {
                _activeSmtpClients[smtpClientId].SendCompleted -= smtpClientEx_SendCompleted;
                _activeSmtpClients.Remove(smtpClientId);
            }
            if (e.Cancelled && OnCanceled != null) OnCanceled(smtpClientId, DateTime.Now);
            if (e.Error != null && OnError != null) OnError(smtpClientId, e.Error.Message);
            if (!e.Cancelled && e.Error == null && OnSuccessfulySent != null) OnSuccessfulySent(smtpClientId, DateTime.Now);
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Static Methods  ------)

        /// <summary>
        /// Creates a MailMessageEx with unique MessageId
        /// </summary>
        public static MailMessageEx PrepareMailMessage(string fromName, string fromEmail, string toName, string toEmail, string subject, string body, params string[] attachedFiles)
        {
            Logger.LogDebug("subject: {0}", subject);
            MailAddress from = new MailAddress(fromEmail, fromName);
            MailAddress to = new MailAddress(toEmail, toName);
            MailMessageEx message = new MailMessageEx(from, to);
            message.Subject = subject;
            message.Body = body;
            foreach (string filename in attachedFiles)
            {
                message.Attachments.Add(new Attachment(filename));
            }
            return message;
        }

        /// <summary>
        /// Send synchronized email. Returns SmtpClientId if message was sent successfuly, else returns -1 and set LastError propertiy
        /// </summary>
        public static int SendEmailSync(SmtpClientEx smtpClientEx, string fromName, string toName, string toEmail, string subject, string body, params string[] attachedFiles)
        {
            Logger.LogDebug("subject: {0}", subject);
            MailMessageEx message = PrepareMailMessage(fromName, smtpClientEx.FromEmail, toName, toEmail, subject, body, attachedFiles);
            try
            {
                smtpClientEx.Send(message);
            }
            catch (SmtpException ex)
            {
                LastError = ex.Message;
                Logger.LogError(ex);
                return -1;
            }
            return smtpClientEx.SmtpClientId;
        }

		#endregion (------  Static Methods  ------)

		#region (------  Public Methods  ------)

        public void CancelSend(int smtpClientId)
        {
            Logger.Log();
            lock (_activeSmtpClients)
            {
                _activeSmtpClients[smtpClientId].SendAsyncCancel();
            }
        }

        /// <summary>
        /// Send asynchronized email. Returns SmtpClientId if message was started to be sent successfuly, else returns -1
        /// </summary>
        public int SendEmailASync(SmtpClientEx smtpClientEx, string fromName, string toName, string toEmail, string subject, string body, params string[] attachedFiles)
        {
            Logger.LogDebug("subject: {0}", subject);
            MailMessageEx message = PrepareMailMessage(fromName, smtpClientEx.FromEmail, toName, toEmail, subject, body, attachedFiles);
            try
            {
                lock (_activeSmtpClients)
                {
                    _activeSmtpClients.Add(smtpClientEx.SmtpClientId, smtpClientEx);
                }
                smtpClientEx.SendCompleted += smtpClientEx_SendCompleted;
                smtpClientEx.SendAsync(message, smtpClientEx.SmtpClientId);
            }
            catch (SmtpException ex)
            {
                Logger.LogError(ex);
                return -1;
            }
            return smtpClientEx.SmtpClientId;
        }

		#endregion (------  Public Methods  ------)
    }
}