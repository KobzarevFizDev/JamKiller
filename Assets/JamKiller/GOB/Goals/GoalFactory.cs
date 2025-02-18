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

        public MeleeAttackUnitGoal CreateAttackUnitGoal(IUnit owner)
        {
            return new MeleeAttackUnitGoal(_unitsProvider, owner);
        }

        public RangedAttackGoal CreateRangedAttackGoal(IUnit owner)
        {
            return new RangedAttackGoal(_unitsProvider, owner);
        }

        public ChangeRangedAttackPositionGoal CreateChangedAttackPositionGoal(IUnit owner)
        {
            return new ChangeRangedAttackPositionGoal(owner);
        }
    }
}
