using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamKiller.GOB
{
    // todo: Удалить deltaTime
    public interface IActionVisitor 
    {
        public void Visit(FollowTargetAction action, ActionContext context, float deltaTime);
        public void Visit(FindCoverAction action, ActionContext context);
        public void Visit(WaitAction action, ActionContext context);
        public void Visit(FindEnemyUnitAction action, ActionContext context);
        public void Visit(AttackAction action, ActionContext context, float deltaTime);
        public void Visit(MoveToPointAction action, ActionContext context);
        public void Visit(FindRangedAttackPositionAction action, ActionContext context);
        public void Visit(CalculatePathAroundPointAction action, ActionContext context);
        public void Visit(SetEnemyAsPointOfAvoidanceAction action, ActionContext context);
        public void Visit(MoveByPathAction action, ActionContext context);
    }
}
