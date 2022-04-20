using System;
using System.Net.Mail;

namespace AnignoLibrary.Communication.Email
{
    /// <summary>
    /// Expends MainMessage, add unique MessageId
    /// </summary>
    public class MailMessageEx : MailMessage
    {
        private static int MessageUniqueId;
        public readonly int MessageId = MessageUniqueId++;

        public MailMessageEx(MailAddress addressFrom, MailAddress addressTo)
            : base(addressFrom, addressTo)
        {
        }
    }
}