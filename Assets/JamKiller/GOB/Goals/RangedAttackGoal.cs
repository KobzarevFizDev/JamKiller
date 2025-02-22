using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class RangedAttackGoal : BaseGoal
    {
        public override GoalId Id => GoalId.RangedAttack;

        public override int Utility
        {
            get
            {
                if (_context.TargetEnemyUnit == null)
                    return 0;
                else
                    return 100;
            }
        }

        public RangedAttackGoal(UnitsProvider unitsProvider, IUnit ownerUnit, GoalContext context) 
            : base(ownerUnit, context, isLoop: true)
        {
            _actions = new List<BaseAction>();
            _actions.Add(new FindRangedAttackPositionAction(ownerUnit));
            _actions.Add(new CalculatePathAroundPointAction(ownerUnit));
            _actions.Add(new MoveByPathAction(ownerUnit));
            _actions.Add(new AttackAction(ownerUnit));
        }

        public override void Interrupt()
        {
            throw new System.NotImplementedException();
        }
    }
}
