using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class MeleeAttackUnitGoal : BaseGoal
    {  
        public override int Utility => _ownerUnit.IsSeriouslyInjured() ? 0 : 10;

        public override GoalId Id => GoalId.MeleeAttack;

        public MeleeAttackUnitGoal(UnitsProvider unitsProvider, IUnit ownerUnit, GoalContext context) : base(ownerUnit, context)
        {
            _actions = new List<BaseAction>();
            _actions.Add(new FindEnemyUnitAction(unitsProvider, ownerUnit));
            _actions.Add(new FollowTargetAction(ownerUnit));
            _actions.Add(new AttackAction(ownerUnit));
        }

        public override void Interrupt()
        {
            throw new System.NotImplementedException();
        }
    }
}
