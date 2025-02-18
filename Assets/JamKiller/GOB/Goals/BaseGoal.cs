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

        //private ActionVisitor _visitor;
        private ActionContext _context;

        public BaseGoal(IUnit ownerUnit)
        {
            _ownerUnit = ownerUnit;
            //_visitor = new ActionVisitor();
            _context = new ActionContext(ownerUnit);
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
                    //action.Execute(_visitor, _context, deltaTime);
                    break;
                }
            }
            IsCompleted = allCompleted;
        }

        public abstract void Interrupt();
    }
}
