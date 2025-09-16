using Content.Server.Chat.Managers;
using Content.Shared._Monkestation.Audio.ICassettes;
using Content.Shared._Monkestation.CCVar;
using Robust.Shared.Configuration;

namespace Content.Server._Monkestation.Audio.ICassettes
{
    public sealed class CassetteSystem : ISharedCassetteSystem
    {
        [Dependency] private readonly IChatManager _chatManager = default!;
        [Dependency] private readonly IConfigurationManager _cfg = default!;
        public override void Initialize()
        {
            base.Initialize();
            SubscribeNetworkEvent<CassetteActionEvent>(OnActionReceived);
        }
        private void OnActionReceived(CassetteActionEvent ev, EntitySessionEventArgs args)
        {
            var enabled = _cfg.GetCVar(InternetSoundCCvars.InternetSoundYtdlp);
            if(!enabled)
                _chatManager.DispatchServerAnnouncement($"YT-DLP is disabled, cassette cannot play ❌ {ev.PlayerName}");
        }
    }
}
