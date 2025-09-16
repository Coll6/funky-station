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
            public string Action { get; } // E.g., "play" or link URL

            public CassetteActionEvent(NetUserId channel, string playerName, string action)
            {
                Channel = channel;
                PlayerName = playerName;
                Action = action;
            }
        }
    }
}
