using System.Collections;
using Exiled.API.Features;
using MEC;

namespace CassieFacilityScan.Handlers
{
    using Exiled.Events.EventArgs;
    using System.Collections.Generic;

    class Server
    {
        public void OnRoundStarted()
        {
            // Kill old corountines before creating new one
            Timing.KillCoroutines("cassiefacilityscan_timer");
            Timing.RunCoroutine(CassieFacilityScanMessage(), "cassiefacilityscan_timer");
        }

        public static IEnumerator<float> CassieFacilityScanMessage()
        {
            yield return Timing.WaitForSeconds(0.1f);

            if (CassieFacilityScan.Instance.Config.BroadcastAtStartOfRound)
            {
                Timing.RunCoroutine(Extension.DelayedCassieMessage(Extension.GenerateCassieMessage(), false, false, 0), "cassiefacilityscan_timer");
            }

            while (RoundSummary.RoundInProgress())
            {
                yield return Timing.WaitForSeconds(480f);
                Timing.RunCoroutine(Extension.DelayedCassieMessage(Extension.GenerateCassieMessage(), false, false, 0),
                    "cassiefacilityscan_timer");
            }
        }
    }
}
