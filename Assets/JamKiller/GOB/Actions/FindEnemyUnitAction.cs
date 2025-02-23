using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class FindEnemyUnitAction : BaseAction
    {
        private UnitsProvider _unitsProvider;

        public FindEnemyUnitAction(UnitsProvider unitsProvider, IUnit ownerUnit) : base(ownerUnit)
        {
            _unitsProvider = unitsProvider;
            _ownerUnit = ownerUnit;
        }

        public override void Execute(GoalContext context, float deltaTime)
        {
            TeamId team = _ownerUnit.GetTeamId();
            IUnit enemy = _unitsProvider.GetEnemyUnitForTeam(team);
            context.TargetEnemyUnit = enemy;
            context.Target = enemy.GetTransform();
            Status = ExecuteStatus.Completed;
        }
    }
}
