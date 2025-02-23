using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class ChangeRangedAttackPositionGoal : BaseGoal
    {
        public override int Utility
        {
            get
            {
                int numberOfAttacks = _ownerUnit.GetNumberAttacksWithouChangingPosition();
                if (numberOfAttacks > 2)
                    return 10;
                else
                    return 0;
            }
        }

        public override GoalId Id => GoalId.ChangeRangedAttackPosition;

        public ChangeRangedAttackPositionGoal(IUnit ownerUnit, GoalContext goalContext) 
            : base(ownerUnit, goalContext, isLoop: true) 
        {
            _actions = new List<BaseAction>();
            _actions.Add(new FindRangedAttackPositionAction(ownerUnit));
            _actions.Add(new CalculatePathAroundPointAction(ownerUnit));
            _actions.Add(new MoveByPathAction(ownerUnit));
        }
    }
}
