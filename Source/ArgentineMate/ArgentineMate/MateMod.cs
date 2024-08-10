using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Verse;
using HarmonyLib;

namespace ArgentineMate
{
    [StaticConstructorOnStartup]
    public class MateMod
    {
        static MateMod()
        {
            var harmony = new Harmony("Argon.Mate");
            harmony.PatchAll();
        }
    }
}
