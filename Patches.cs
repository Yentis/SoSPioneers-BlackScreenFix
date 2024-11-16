using BokuMono;
using BokuMono.Data;
using UnityEngine;

namespace SoSPioneersBlackScreen
{
    public class Patches : MonoBehaviour
    {
        public static bool GetNotOpenFestivalScheduleId(ref NpcScheduleMasterData __instance, ref uint __result, BokuMonoSeason season, int index)
        {
            if (__instance.CharaId >= 700)
            {
                __result = 0;
                return false;
            }

            return true;
        }
    }
}
