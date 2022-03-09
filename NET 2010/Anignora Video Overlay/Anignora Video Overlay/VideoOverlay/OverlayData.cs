using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using AnignoraDataTypes.Configurations;

namespace Anignora_Video_Overlay.VideoOverlay
{
    [Serializable]
    public class OverlayData : IConfiguration
    {
        public const string CATEGORY_DEDICATED = "Dedicated";
        public const string CATEGORY_GENERIC = "Dedicated";
        public const string CATEGORY_GLOBAL = "Dedicated";

        [Category(CATEGORY_DEDICATED), DisplayName("Logo File Name"), Description("")]
        public string LogoImagePath { get; set; }
        public string[] ScrollingTextDedicated { get; set; }
        public int ScrollingTextDedicatedCount { get; set; }
        public string VideoFilesDirectoryDedicated { get; set; }
        public int VideoFilesDedicatedCount { get; set; }

        public string[] ScrollingTextGeneric { get; set; }
        public int ScrollingTextGenericCount { get; set; }
        public string VideoFilesDirectoryGeneric { get; set; }
        public int VideoFilesGenericCount { get; set; }

        public int ScrollingTextSpeed { get; set; }

        public void SetDefaults()
        {
            ScrollingTextGenericCount = 5;
            ScrollingTextDedicatedCount = 3;
            LogoImagePath = "Samples\\SampleLogo.jpg";
            VideoFilesDirectoryGeneric = "Samples\\Generic";
            VideoFilesDirectoryDedicated = "Samples\\Dedicated";
            VideoFilesGenericCount = 5;
            VideoFilesDedicatedCount = 3;
            ScrollingTextSpeed = 2;

            ScrollingTextGeneric = new[] { 
                "כיתוב רץ כללי 0",
                "כיתוב רץ כללי 1",
                "כיתוב רץ כללי 2",
                "כיתוב רץ כללי 3",
                "כיתוב רץ כללי 4",
                "כיתוב רץ כללי 5",
                "כיתוב רץ כללי 6",
                "כיתוב רץ כללי 7",
                "כיתוב רץ כללי 8",
                "כיתוב רץ כללי 9",
            };
            ScrollingTextDedicated = new[] { 
                "כיתוב רץ יעודי 0",
                "כיתוב רץ יעודי 1",
                "כיתוב רץ יעודי 2",
                "כיתוב רץ יעודי 3",
                "כיתוב רץ יעודי 4",
                "כיתוב רץ יעודי 5"
            };
        }
    }
}
