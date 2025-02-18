using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Location;

namespace JamKiller.GOB
{

    public enum ExecuteStatus
    {
        NotStarted,
        InProgress,
        Completed
    }

    // todo: �������� ����� ���������� ������ ���������� ������ ActionContext ����� ���� Action ��� ��������
    // todo: �������� ����� ������ StatusExecute � Action
    // todo: �������� ��� ������� ������ �� �����
    public class ActionVisitor : IActionVisitor
    {
        public void Visit(FindCoverAction findCoverAction, ActionContext context)
        {
            Debug.Log("����������� �������� FindCover");
            Cover cover = findCoverAction.Find();
            if(cover.TryGetSafePosition(out Vector3 safePosition))
            {
                context.DestinationPoint = safePosition;
                findCoverAction.Status = ExecuteStatus.Completed;
            }
            else
            {
                throw new System.InvalidOperationException("Get save position of cover error");
            }
            //context.DestinationPoint = findCoverAction.Find().;
            //findCoverAction.Status = ExecuteStatus.Completed;
        }

        public void Visit(FollowTargetAction followTarget, ActionContext context, float deltaTime)
        {
            Debug.Log("����������� �������� FollowTarget");

            if(followTarget.Status == ExecuteStatus.NotStarted)
            {
                followTarget.SetTarget(context.Target);
                followTarget.Status = ExecuteStatus.InProgress;
            }
            else if(followTarget.Status == ExecuteStatus.InProgress)
            {
                if (followTarget.IsTargetReached)
                    followTarget.Status = ExecuteStatus.Completed;
            }
        }

        public void Visit(MoveToPointAction moveToPoint, ActionContext context)
        {
            Debug.Log("����������� �������� MoveToPoint");

            if(moveToPoint.Status == ExecuteStatus.NotStarted)
            {
                moveToPoint.SetPoint(context.DestinationPoint);
                moveToPoint.Status = ExecuteStatus.InProgress;
            }
            else if(moveToPoint.Status == ExecuteStatus.InProgress)
            {
                if (moveToPoint.IsPointReached)
                    moveToPoint.Status = ExecuteStatus.Completed;
            }
        }

        public void Visit(WaitAction action, ActionContext context)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(FindEnemyUnitAction findEnemyAction, ActionContext context)
        {
            Debug.Log("����������� �������� FindEnemy");
            var enemy = findEnemyAction.Find();
            DebugExtension.DebugWireSphere(enemy.GetPosition(), Color.red, 1f, 1000f);
            context.TargetEnemyUnit = enemy;
            context.Target = enemy.GetTransform();
            findEnemyAction.Status = ExecuteStatus.Completed;
        }

        public void Visit(AttackAction attackAction, ActionContext context, float deltaTime)
        {
            Debug.Log("����������� �������� AttackAction");
            attackAction.Attack();
            attackAction.Status = ExecuteStatus.InProgress;
        }

        public void Visit(FindRangedAttackPositionAction findAttackAction, ActionContext context)
        {
            Debug.Log("����������� �������� FindRangedAttackPositionAction");

            Vector3 rangedAttackPosition = findAttackAction.Find(context.TargetEnemyUnit);
            DebugExtension.DebugWireSphere(rangedAttackPosition, Color.blue, 1f, 1000f);
            findAttackAction.Status = ExecuteStatus.Completed;
            context.DestinationPoint = rangedAttackPosition;
        }

        public void Visit(CalculatePathAroundPointAction calculatePathAction, ActionContext context)
        {
            Debug.Log("����������� �������� CalculatePathAroundPointAction");
            calculatePathAction.CalculatePath(context);
            //calculatePathAction.CalculatePath(center, context.OwnerUnit.GetOptimalRangedAttackDistance());
            calculatePathAction.Status = ExecuteStatus.Completed;
        }

        public void Visit(SetEnemyAsPointOfAvoidanceAction setAvoidanceAction, ActionContext context)
        {
            Debug.Log("����������� �������� SetEnemyAsPointOfAvoidance");
            setAvoidanceAction.SetAvoidancePoint(context);
            setAvoidanceAction.Status = ExecuteStatus.Completed;
        }

        public void Visit(MoveByPathAction moveByPathAction, ActionContext context)
        {

            Debug.Log("����������� �������� MoveByPathAction ");

            if (moveByPathAction.Status == ExecuteStatus.NotStarted)
            {
                moveByPathAction.SetPath(context);
                moveByPathAction.Status = ExecuteStatus.InProgress;
            }
            else if (moveByPathAction.Status == ExecuteStatus.InProgress)
            {
                if (moveByPathAction.IsPointReached)
                    moveByPathAction.Status = ExecuteStatus.Completed;
            }

            moveByPathAction.Status = ExecuteStatus.Completed;

        }
    }
}
