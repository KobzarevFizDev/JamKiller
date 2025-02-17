using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class AttackUnitGoal : BaseGoal
    {  
        public override float Priority => throw new System.NotImplementedException();

        public override GoalId Id => GoalId.Attack;

        public AttackUnitGoal(UnitsProvider unitsProvider, IUnit ownerUnit) : base(ownerUnit)
        {
            _actions = new List<BaseAction>();
            _actions.Add(new FindEnemyUnitAction(unitsProvider, ownerUnit));
            _actions.Add(new MoveToTarget(ownerUnit));
            _actions.Add(new AttackAction(ownerUnit));
        }

        public override void Interrupt()
        {
            throw new System.NotImplementedException();
        }
    }
}
