using BepInEx;
using BokuMono.Data;
using HarmonyLib;
using System;

namespace SoSPioneersBlackScreen
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class BepInExLoader : BepInEx.Unity.IL2CPP.BasePlugin
    {
        public const string
            MODNAME = "BlackScreenFix",
            AUTHOR = "Yentis",
            GUID = "com." + AUTHOR + "." + MODNAME,
            VERSION = "1.0.1";

        public static BepInEx.Logging.ManualLogSource log;

        public BepInExLoader()
        {
            log = Log;
        }

        public override void Load()
        {
            log.LogMessage("Loading");

            try
            {
                var harmony = new Harmony("yentis.blackscreenfix.il2cpp");

                harmony.Patch(
                    typeof(NpcScheduleMasterData).GetMethod(nameof(NpcScheduleMasterData.GetNotOpenFestivalScheduleId)),
                    prefix: new HarmonyMethod(typeof(Patches).GetMethod(nameof(Patches.GetNotOpenFestivalScheduleId)))
                );
            }
            catch (Exception exception)
            {
                log.LogError(exception);
            }

            log.LogMessage("Started");
        }
    }
}