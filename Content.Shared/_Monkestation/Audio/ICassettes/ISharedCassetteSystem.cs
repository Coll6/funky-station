using Robust.Shared.Network;
using Robust.Shared.Serialization;

namespace Content.Shared._Monkestation.Audio.ICassettes
{
    public abstract class ISharedCassetteSystem : EntitySystem
    {
        [Serializable, NetSerializable]
        public sealed class CassetteActionEvent : EntityEventArgs
        {
            public NetUserId Channel { get; }
            public string PlayerName { get; }
            public string Action { get; }
            public string Url { get; }
            public CassetteActionEvent(NetUserId channel, string playerName, string action, string url)
            {
                Channel = channel;
                PlayerName = playerName;
                Action = action;
                Url = url;
            }
        }
    }
}
