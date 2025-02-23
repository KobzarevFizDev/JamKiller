using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class AttackAction : BaseAction
    {
        public AttackAction(IUnit ownerUnit) : base(ownerUnit) { }

        public override void Execute(GoalContext context, float deltaTime)
        {
            if(_ownerUnit.GetNumberAttacksWithouChangingPosition() < 2)
            {
                _ownerUnit.Attack();
                Status = ExecuteStatus.InProgress;
            }
            else
            {
                Status = ExecuteStatus.Completed;
            }
        }
    }
}
