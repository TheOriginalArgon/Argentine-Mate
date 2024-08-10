using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Verse;
using RimWorld;

namespace ArgentineMate
{
    public class GameComponent_MateTracker : GameComponent
    {
        public GameComponent_MateTracker(Game game) { }

        public Dictionary<Pawn, int> pawnsMateTracker_backup = new Dictionary<Pawn, int>();
        private List<Pawn> _list_pawns;
        private List<int> _list_ticks;
        public int tickCounter = 0;
        public int tickInterval = 15000;

        public override void FinalizeInit()
        {
            MateTracker.pawnsMateTracker = pawnsMateTracker_backup;
            base.FinalizeInit();
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref tickCounter, "tickCounterMate", 0, true);
            Scribe_Collections.Look(ref pawnsMateTracker_backup, "pawnsMateTracker_backup", LookMode.Reference, LookMode.Value, ref _list_pawns, ref _list_ticks, true, false, false);
        }

        public override void GameComponentTick()
        {
            if (!Find.IdeoManager.classicMode)
            {
                tickCounter++;
                if (tickCounter > tickInterval)
                {
                    pawnsMateTracker_backup = MateTracker.pawnsMateTracker;
                    if (Current.Game.World.factionManager.OfPlayer.ideos.GetPrecept(DefDatabase<PreceptDef>.GetNamed("AM_MateConsumption_Required")) != null)
                    {
                        foreach (Pawn pawn in PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_Colonists)
                        {
                            MateTracker.AddPawn(pawn, 0);
                            if (MateTracker.pawnsMateTracker[pawn] < int.MaxValue - tickInterval)
                            {
                                MateTracker.IncreasePawnTicks(pawn, tickInterval);
                            }
                        }
                    }
                    tickCounter = 0;
                }
            }
        }
    }
}
