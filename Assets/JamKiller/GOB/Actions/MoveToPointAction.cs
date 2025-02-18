using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class MoveToPointAction : BaseAction
    {
        public MoveToPointAction(IUnit ownerUnit) : base(ownerUnit) { }


        public override void Execute(ActionContext context, float deltaTime)
        {
            if (Status == ExecuteStatus.NotStarted)
            {
                _ownerUnit.StartMoveToPoint(context.DestinationPoint);
                Status = ExecuteStatus.InProgress;
            }
            else if (Status == ExecuteStatus.InProgress)
            {
                if (_ownerUnit.IsMoveCompleted())
                    Status = ExecuteStatus.Completed;
            }
        }
    }
}
