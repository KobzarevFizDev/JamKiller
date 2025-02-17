using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamKiller.GOB
{
    public interface IActionVisitor 
    {
        public void Visit(MoveToTarget action, ActionContext context, float deltaTime);
        public void Visit(FindCoverAction action, ActionContext context);
        public void Visit(WaitAction action, ActionContext context);
        public void Visit(FindEnemyUnitAction action, ActionContext context);
        public void Visit(AttackAction action, ActionContext context, float deltaTime);
    }
}
