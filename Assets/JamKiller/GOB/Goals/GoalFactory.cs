using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Location;
using JamKiller.Units;


namespace JamKiller.GOB
{
    public class GoalFactory
    {
        private CoverProvider _coverProvider;
        private UnitsProvider _unitsProvider;
        public GoalFactory(CoverProvider coverProvider, UnitsProvider unitsProvider)
        {
            _coverProvider = coverProvider;
            _unitsProvider = unitsProvider;
        }

        public HideGoal CreateHideGoal(IUnit owner)
        {
            return new HideGoal(_coverProvider, owner);
        }

        public AttackUnitGoal CreateAttackUnitGoal(IUnit owner)
        {
            return new AttackUnitGoal(_unitsProvider, owner);
        }
    }
}
