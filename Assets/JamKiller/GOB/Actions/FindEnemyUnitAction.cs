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

        public IUnit Find()
        {
            TeamId team = _ownerUnit.GetTeamId();
            return _unitsProvider.GetEnemyUnitForTeam(team);
        }

        public override void Execute(IActionVisitor visitor, ActionContext context, float deltaTime)
        {
            visitor.Visit(this, context);
        }
    }
}
