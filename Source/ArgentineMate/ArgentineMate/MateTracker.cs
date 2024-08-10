using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Verse;

namespace ArgentineMate
{
    public static class MateTracker
    {
        // Yeah, a tracker class with a dictionary for just one event, but well... that's what modding's about.

        public static Dictionary<Pawn, int> pawnsMateTracker = new Dictionary<Pawn, int>();

        public static void AddPawn(Pawn pawn, int ticks)
        {
            if (pawn != null && !pawnsMateTracker.ContainsKey(pawn))
            {
                pawnsMateTracker[pawn] = ticks;
                //pawnsMateTracker.Add(pawn, ticks);
                //Log.Message($"{pawn.Name} consumed mate (added).");
                //foreach (KeyValuePair<Pawn, int> pair in pawnsMateTracker)
                //{
                //    Log.Message($"{pair.Key} in tick {pair.Value}");
                //}
            }
        }

        public static void IncreasePawnTicks(Pawn pawn, int ticks)
        {
            if (pawn != null)
            {
                pawnsMateTracker[pawn] += ticks;
                //Log.Message($"{pawn.Name} increased mate ticks by {ticks}.");
                //foreach (KeyValuePair<Pawn, int> pair in pawnsMateTracker)
                //{
                //    Log.Message($"{pair.Key} in tick {pair.Value}");
                //}
            }
        }

        public static void ResetPawnTicks(Pawn pawn)
        {
            if (pawn != null)
            {
                pawnsMateTracker[pawn] = 0;
                //Log.Message($"{pawn.Name} reset mate ticks.");
                //foreach (KeyValuePair<Pawn, int> pair in pawnsMateTracker)
                //{
                //    Log.Message($"{pair.Key} in tick {pair.Value}");
                //}
            }
        }
    }
}
