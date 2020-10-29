using System.ComponentModel;

namespace CassieFacilityScan
{
    using Exiled.API.Interfaces;
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Start of the scan before every class is listed.")]
        public string ScanBegin { get; set; } =
            "BELL_START ATTENTION . COMMENCING FACILITY SCAN .g4 . . . SCAN COMPLETED . DETECTED";

        
        [Description("Name of class d personnel count. (Use {s} for optional s, if count is greater than 1 or zero)")]
        public string ClassDName { get; set; } = "CLASSD PERSONNEL";
        
        [Description("Name of science personnel count. (Use {s} for optional s, if count is greater than 1 or zero)")]
        public string ScientistName { get; set; } = "SCIENCE PERSONNEL";
        
        [Description("Name of mtf unit count. (Use {s} for optional s, if count is greater than 1 or zero)")]
        public string MtfName { get; set; } = "MTFUNIT{s}";
        
        [Description("Name of scps. (Use {s} for optional s, if count is greater than 1 or zero)")]
        public string ScpName { get; set; } = "NOT CONTAINED SCPSUBJECT{s}";
        
        [Description("Name of choas insurgency count. (Use {s} for optional s, if count is greater than 1 or zero)")]
        public string ChoasInsurgencyName { get; set; } = "CHAOSINSURGENCY";

        [Description("Name of serpents hand count. (Use {s} for optional s, if count is greater than 1 or zero)")]
        public string SerpentsHandName { get; set; } = "SERPENTS HAND";
        
        [Description("End of the scan message after every class is listed.")]
        public string ScanEnd { get; set; } = "BELL_END";
        
        [Description("Boolean wether chaos insurgency and serpents hand should be combined into one count.")]
        public bool CombineIntoUnauthorizedLifeForms { get; set; } = false;
        
        [Description("Name of unauthorized life forms (chaos insurgency and serpents hand) (Use {s} for optional s, if count is greater than 1 or zero)")]
        public string UnauthorizedLifeFormsName { get; set; } = "UNAUTHORIZED LIFE FORM{s}";
        
        [Description("Instead of saying 'no' when none of one class is detected, say 'zero'.")]
        public bool SayZeroInsteadOfNo { get; set; } = false;

        [Description("Broadcast the message at start of the round.")]
        public bool BroadcastAtStartOfRound { get; set; } = false;
    }
}
