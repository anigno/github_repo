using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnignoBackupToEmail
{
    public class AnignoBackupToEmailData
    {
        public string SenderGmailAddress=string.Empty;
        public string SenderGmailPassword=string.Empty;
        public decimal MaximumAttachmentSizeMb=8;
        public string ArchivesPassword = string.Empty;
        public decimal UploadSpeedKps = 5;
        public string EmailSubjectPrefix = "BackupToEmail";

        List<string> DirectoriesToArchive=new List<string>();
        List<string> ArchivesToSend=new List<string>();
    }
}
