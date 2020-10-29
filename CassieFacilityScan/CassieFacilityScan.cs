using MEC;

namespace CassieFacilityScan
{
    using System;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Server = Exiled.Events.Handlers.Server;

    public class CassieFacilityScan : Plugin<Config>
    {
        private static readonly Lazy<CassieFacilityScan> LazyInstance = new Lazy<CassieFacilityScan>(() => new CassieFacilityScan());
        public static CassieFacilityScan Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Handlers.Server server;

        private CassieFacilityScan() {}

        public override void OnEnabled()
        {
            base.OnEnabled();

            RegisterEvents();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();

            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            server = new Handlers.Server();

            Server.RoundStarted += server.OnRoundStarted;
        }

        public void UnregisterEvents()
        {
            Server.RoundStarted -= server.OnRoundStarted;

            server = null;

            // Kill the coroutines when disabled
            Timing.KillCoroutines("cassiefacilityscan_timer");
        }
    }
}
