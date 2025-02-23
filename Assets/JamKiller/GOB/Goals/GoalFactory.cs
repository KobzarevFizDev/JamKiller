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

        public GoalContext CreateGoalContext(IUnit owner)
        {
            return new GoalContext(owner);
        }

        public HideGoal CreateHideGoal(IUnit owner, GoalContext goalContext)
        {
            return new HideGoal(_coverProvider, owner, goalContext);
        }

        public MeleeAttackUnitGoal CreateAttackUnitGoal(IUnit owner, GoalContext goalContext)
        {
            return new MeleeAttackUnitGoal(_unitsProvider, owner, goalContext);
        }

        public RangedAttackGoal CreateRangedAttackGoal(IUnit owner, GoalContext goalContext)
        {
            return new RangedAttackGoal(_unitsProvider, owner, goalContext);
        }

        public ChangeRangedAttackPositionGoal CreateChangedAttackPositionGoal(IUnit owner, GoalContext goalContext)
        {
            return new ChangeRangedAttackPositionGoal(owner, goalContext);
        }

        public SearchEnemyGoal CreateSearchEnemyGoal(IUnit owner, GoalContext goalContext)
        {
            return new SearchEnemyGoal(owner, goalContext);
        }
    }
}
