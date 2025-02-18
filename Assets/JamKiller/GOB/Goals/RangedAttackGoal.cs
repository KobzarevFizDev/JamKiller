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
                int numberOfAttacks = _ownerUnit.GetNumberAttacksWithouChangingPosition();
                if (numberOfAttacks > 2)
                    return 0;
                else
                    return 10;
            }
        }

        public RangedAttackGoal(UnitsProvider unitsProvider, IUnit ownerUnit) : base(ownerUnit)
        {
            _actions = new List<BaseAction>();
            _actions.Add(new FindEnemyUnitAction(unitsProvider, ownerUnit));
            _actions.Add(new FindRangedAttackPositionAction(ownerUnit));
            _actions.Add(new MoveToPointAction(ownerUnit));
            _actions.Add(new AttackAction(ownerUnit));
        }

        public override void Interrupt()
        {
            throw new System.NotImplementedException();
        }
    }
}
