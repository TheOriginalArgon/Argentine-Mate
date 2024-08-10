using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;
using HarmonyLib;

namespace ArgentineMate
{
    [HarmonyPatch]
    public class HarmonyPatches
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(CompDrug), nameof(CompDrug.PostIngested))]
        private static void IngestedMate(Pawn ingester, CompDrug __instance)
        {
            if (__instance.parent.def.defName == "AM_Mate")
            {
                MateTracker.AddPawn(ingester, 0);
                MateTracker.ResetPawnTicks(ingester);
            }
        }
    }
}
