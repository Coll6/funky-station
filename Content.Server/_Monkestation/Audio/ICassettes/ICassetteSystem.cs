using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Content.Server.Chat.Managers;
using Content.Shared._Monkestation.Audio.ICassettes;
using Content.Shared._Monkestation.CCVar;
using Content.Shared.Administration;
using Content.Shared.Administration.Managers;
using Robust.Shared.Configuration;
using Robust.Shared.Player;

namespace Content.Server._Monkestation.Audio.ICassettes
{
    public sealed class ICassetteSystem : ISharedCassetteSystem
    {
        private const AdminFlags FunMin = AdminFlags.Fun;
        private string Path = "";

        [Dependency] private readonly IChatManager _chatManager = default!;
        [Dependency] private readonly IConfigurationManager _cfg = default!;
        [Dependency] private readonly ISharedAdminManager _admin = default!;
        public override void Initialize()
        {
            base.Initialize();
            Path = _cfg.GetCVar(InternetSoundCCvars.InternetSoundYtdlpPath);
            SubscribeNetworkEvent<CassetteActionEvent>(OnAdminActionReceived);
        }
        private void OnAdminActionReceived(CassetteActionEvent ev, EntitySessionEventArgs args)
        {
            var enabled = _cfg.GetCVar(InternetSoundCCvars.InternetSoundYtdlp);
            if (!enabled)
            {
                // TODO yt-dlp not enabled messaging
                return;
            }

            if (!_admin.HasAdminFlag(args.SenderSession, FunMin))
            {
                // TODO Add error messaging
                return;
            }

            AttemptYtdlp(args.SenderSession).GetAwaiter().GetResult();
            // TODO figure out how to play music when ytdlp downloads file
        }
        private async Task AttemptYtdlp(ICommonSession sender)
        {
            try
            {
                // TODO allow for custom paths default to env if path doesn't exist of file is not available.
                /*
                var pathEnv = Environment.GetEnvironmentVariable("PATH");
                if (string.IsNullOrEmpty(pathEnv))
                {
                    return;
                }
*/

                //_chatManager.DispatchServerAnnouncement($"Attempting process with enviromental {currentDesktop}");
                var process = Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = "yt-dlp",
                        Arguments = "--version",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                    });
                _chatManager.DispatchServerAnnouncement("Process my have happened");
                if (process == null)
                {
                    _chatManager.DispatchServerAnnouncement("Null process");
                    return;
                }

                _chatManager.DispatchServerAnnouncement(
                    $"Process says {await process.StandardOutput.ReadToEndAsync()} and {await process.StandardError.ReadToEndAsync()}");
            }
            catch (SystemException e)
            {
                _chatManager.DispatchServerAnnouncement($"Exception {e.Message}");
            }
        }
    }
}
