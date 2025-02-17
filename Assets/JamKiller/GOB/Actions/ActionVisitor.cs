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
        public void Visit(FindCoverAction findCoverAction, ActionContext context)
        {
            Debug.Log("Выполняется действие FindCover");
            context.Target = findCoverAction.Find().transform;
            findCoverAction.Status = ExecuteStatus.Completed;
        }

        public void Visit(MoveToTarget moveToPointAction, ActionContext context, float deltaTime)
        {
            Debug.Log("Выполняется действие MoveToPoint");

            if(moveToPointAction.Status == ExecuteStatus.NotStarted)
            {
                moveToPointAction.SetTarget(context.Target);
                moveToPointAction.Status = ExecuteStatus.InProgress;
            }
            else if(moveToPointAction.Status == ExecuteStatus.InProgress)
            {
                if (moveToPointAction.IsTargetReached)
                    moveToPointAction.Status = ExecuteStatus.Completed;
            }
        }

        public void Visit(WaitAction action, ActionContext context)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(FindEnemyUnitAction findEnemyAction, ActionContext context)
        {
            Debug.Log("Выполняется действие FindEnemy");
            var enemy = findEnemyAction.Find();
            context.TargetEnemyUnit = enemy;
            context.Target = enemy.GetTransform();
            findEnemyAction.Status = ExecuteStatus.Completed;
        }

        public void Visit(AttackAction attackAction, ActionContext context, float deltaTime)
        {
            Debug.Log("Выполняется действие AttackAction");
            attackAction.Attack(context.OwnerUnit, deltaTime);
            attackAction.Status = ExecuteStatus.InProgress;
        }
    }
}
