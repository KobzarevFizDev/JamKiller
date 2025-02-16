using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamKiller.GOB
{

    public enum ExecuteStatus
    {
        NotStarted,
        InProgress,
        Completed
    }

    public class ActionVisitor : IActionVisitor
    {
        public bool Visit(FindCoverAction action, ActionContext context)
        {
            context.TargetCover = action.FindCover();
            action.Status = ExecuteStatus.Completed;
            return true;
        }

        public bool Visit(MoveToPointAction action, ActionContext context, float deltaTime)
        {
            if(action.Status == ExecuteStatus.NotStarted)
            {
                action.SetTarget(context.TargetCover.transform.position);
                action.Status = ExecuteStatus.InProgress;
                return false;
            }
            else if(action.Status == ExecuteStatus.InProgress)
            {
                action.MoveToPoint(context.OwnerUnit);
                if (action.IsTargetReached)
                    action.Status = ExecuteStatus.Completed;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
