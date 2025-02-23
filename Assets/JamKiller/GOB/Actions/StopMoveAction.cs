using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class StopMoveAction : BaseAction
    {
        public StopMoveAction(IUnit ownerUnit) : base(ownerUnit) { }

        public override void Execute(GoalContext context, float deltaTime)
        {
            _ownerUnit.StopMove();
            Status = ExecuteStatus.Completed;
        }
    }
}
