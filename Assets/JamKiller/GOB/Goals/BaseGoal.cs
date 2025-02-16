using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamKiller.GOB
{
    public enum GoalId { Hide, Attack, ChangeAttackPosition }
    public abstract class BaseGoal
    {
        public abstract float Priority { get; }
        public abstract GoalId Id { get; }

        protected List<BaseAction> _actions;

        private ActionVisitor _visitor;
        private ActionContext _context;

        public BaseGoal(IUnit ownerUnit)
        {
            _visitor = new ActionVisitor();
            _context = new ActionContext(ownerUnit);
        }

        public void Execute(float deltaTime)
        {
            foreach(var action in _actions)
            {
                action.Accept(_visitor, _context, deltaTime);
            }
        }

        public abstract void Interrupt();
    }
}
