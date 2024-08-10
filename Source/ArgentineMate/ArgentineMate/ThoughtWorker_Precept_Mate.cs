using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using UnityEngine;
using Verse;

namespace ArgentineMate
{
    public class ThoughtWorker_Precept_Mate : ThoughtWorker_Precept, IPreceptCompDescriptionArgs
    {
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            if (ThoughtUtility.ThoughtNullified(p, def))
            {
                return false;
            }

            if (MateTracker.pawnsMateTracker.ContainsKey(p))
            {
                float num = MateTracker.pawnsMateTracker[p] / 60000f;
                Log.Warning($"TIMER FOR {p.Name} IS {num}");
                if (num > 1f && def.minExpectationForNegativeThought != null && p.MapHeld != null && ExpectationsUtility.CurrentExpectationFor(p.MapHeld).order < def.minExpectationForNegativeThought.order)
                {
                    return false;
                }
                if (num < 1f)
                {
                    return ThoughtState.ActiveAtStage(0);
                }
                if (num < 2f)
                {
                    return ThoughtState.ActiveAtStage(1);
                }
                if (num < 5f)
                {
                    return ThoughtState.ActiveAtStage(2);
                }
                if (num < 10f)
                {
                    return ThoughtState.ActiveAtStage(3);
                }
                return ThoughtState.ActiveAtStage(4);
            }
            return false;
        }

        public IEnumerable<NamedArgument> GetDescriptionArgs()
        {
            yield return 0.75f.ToString("F2").Named("DAYSSINCELASTMATE");
        }
    }
}
