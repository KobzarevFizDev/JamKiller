using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public enum GoalId { Hide, MeleeAttack, RangedAttack, ChangeRangedAttackPosition }
    public abstract class BaseGoal
    {
        public abstract int Utility { get; }
        public abstract GoalId Id { get; }
        public bool IsCompleted { private set; get; }

        protected List<BaseAction> _actions;
        protected IUnit _ownerUnit;

        private GoalContext _context;

        public BaseGoal(IUnit ownerUnit, GoalContext context)
        {
            _ownerUnit = ownerUnit;
            _context = context;
        }

        public void Execute(float deltaTime)
        {

            bool allCompleted = true;
            foreach(var action in _actions)
            {
                if (action.Status == ExecuteStatus.Completed)
                    continue;

                allCompleted = false;

                if(action.Status == ExecuteStatus.InProgress || action.Status == ExecuteStatus.NotStarted)
                {
                    action.Execute(_context, deltaTime);
                    break;
                }
            }
            IsCompleted = allCompleted;
        }

        public abstract void Interrupt();
    }
}
