using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class MoveByPathAction : BaseAction
    {
        public MoveByPathAction(IUnit ownerUnit) : base(ownerUnit) { }


        public override void Execute(GoalContext context, float deltaTime)
        {
            Debug.Log("Выполняется MoveByPathAction");

            if (Status == ExecuteStatus.NotStarted)
            {
                _ownerUnit.StartMoveByPath(context.Path);
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
