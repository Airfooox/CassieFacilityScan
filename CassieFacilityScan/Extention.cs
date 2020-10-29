using System.Linq;

namespace CassieFacilityScan
{
    using Exiled.API.Features;
    using MEC;
    using System.Collections.Generic;
    public static class Extension
    {
        public static IEnumerator<float> DelayedCassieMessage(string msg, bool makeHold, bool makeNoise, float delay)
        {
            yield return Timing.WaitForSeconds(delay);
            Cassie.Message(msg, makeHold, makeNoise);
        }

        public static string GenerateCassieMessage()
        {
            int classDCount = Player.Get(RoleType.ClassD).Count();
            int scientistCount = Player.Get(RoleType.Scientist).Count();
            int mtfCount = Player.Get(Team.MTF).Count();
            int scpCount = Player.Get(Team.SCP).Count();
            int chaosInsurgencyCount = Player.Get(Team.CHI).Count();
            int serpentsHandCount = Player.Get(Team.TUT).Count(); // Tutorial is Serpents Hand

            string message = $"{CassieFacilityScan.Instance.Config.ScanBegin} ";

            message += GenerateClassMessage(classDCount, CassieFacilityScan.Instance.Config.ClassDName);
            message += GenerateClassMessage(scientistCount, CassieFacilityScan.Instance.Config.ScientistName);
            message += GenerateClassMessage(mtfCount, CassieFacilityScan.Instance.Config.MtfName);
            message += GenerateClassMessage(scpCount, CassieFacilityScan.Instance.Config.ScpName);

            if (CassieFacilityScan.Instance.Config.CombineIntoUnauthorizedLifeForms)
            {
                int unauthorizedLifeForms = chaosInsurgencyCount + serpentsHandCount;
                message += GenerateClassMessage(unauthorizedLifeForms,
                    CassieFacilityScan.Instance.Config.UnauthorizedLifeFormsName);
            }
            else
            {
                message += GenerateClassMessage(chaosInsurgencyCount, CassieFacilityScan.Instance.Config.ChoasInsurgencyName);
                message += GenerateClassMessage(serpentsHandCount, CassieFacilityScan.Instance.Config.SerpentsHandName);
            }

            message += $"{CassieFacilityScan.Instance.Config.ScanEnd}";

            Log.Info("Broadcasting facility scan message.");
            return message;
        }

        public static string GenerateClassMessage(int classCount, string classStringConfig)
        {
            return
                $"{(classCount > 0 ? classCount.ToString() : (CassieFacilityScan.Instance.Config.SayZeroInsteadOfNo ? "0" : "NO"))} {classStringConfig.Replace("{s}", (classCount == 1 ? "" : "s"))} . ";
        }
    }
}