using Robust.Shared;
using Robust.Shared.Configuration;

namespace Content.Shared._Monkestation.CCVar;

[CVarDefs]
public sealed class InternetSoundCCvars : CVars
{
    /// <summary>
    /// Enables the yt-dlp handler, assuming yt-dlp is downloaded and properly setup for environmental access.
    /// </summary>
    public static readonly CVarDef<bool> InternetSoundYtdlp =
        CVarDef.Create("internet.sound.enable_ytdlp", false, CVar.SERVERONLY);
}
