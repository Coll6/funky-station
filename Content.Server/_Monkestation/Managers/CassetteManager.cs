using Robust.Shared.Configuration;

namespace Content.Server._Monkestation.Managers;

/// <summary>
/// This handles...
/// </summary>
public sealed class CassetteManager : EntitySystem
{
    [Dependency] private readonly IConfigurationManager _cfg = default!;
    /// <inheritdoc/>
    public override void Initialize()
    {

    }

    public bool ServerCassetteValue()
    {
        return _cfg.GetCVar<bool>("internet.sound.enable_ytdlp");
    }
}
