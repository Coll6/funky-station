using Content.Server.Chat.Managers;
using Content.Shared._Monkestation.Audio.ICassettes;

namespace Content.Server._Monkestation.Audio.ICassettes
{
    public sealed class CassetteSystem : ISharedCassetteSystem
    {
        [Dependency] private readonly IChatManager _chatManager = default!;
        public override void Initialize()
        {
            base.Initialize();
            SubscribeNetworkEvent<CassetteActionEvent>(OnActionReceived);
        }
        private void OnActionReceived(CassetteActionEvent ev, EntitySessionEventArgs args)
        {
            _chatManager.DispatchServerAnnouncement($"YT-DLP is disabled, cassette cannot play ❌ {ev.PlayerName}");
        }
    }
}
