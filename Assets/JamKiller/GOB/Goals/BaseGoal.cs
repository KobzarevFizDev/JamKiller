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

        private bool _isLoop;
        private int _currentActionIndex;


        public BaseGoal(IUnit ownerUnit, GoalContext context, bool isLoop)
        {
            _ownerUnit = ownerUnit;
            _context = context;
            _isLoop = isLoop;
        }

        public void Execute(float deltaTime)
        {
            if (_currentActionIndex >= _actions.Count) 
            {
                if (_isLoop)
                {
                    foreach(var action in _actions)
                    {
                        action.ResetStatus();
                    }
                    _currentActionIndex = 0;
                }
                else
                {
                    IsCompleted = true;
                    return;
                }
            }

            BaseAction currentAction = _actions[_currentActionIndex];

            Debug.Log($"CurrentAction = {currentAction}");

            if(currentAction.Status == ExecuteStatus.Completed)
            {
                _currentActionIndex++;
            }
            else if(currentAction.Status == ExecuteStatus.InProgress || currentAction.Status == ExecuteStatus.NotStarted)
            {
                currentAction.Execute(_context, deltaTime);
            }

            //bool allCompleted = true;
            //foreach(var action in _actions)
            //{
            //    if (action.Status == ExecuteStatus.Completed)
            //        continue;

            //    allCompleted = false;

            //    if(action.Status == ExecuteStatus.InProgress || action.Status == ExecuteStatus.NotStarted)
            //    {
            //        action.Execute(_context, deltaTime);
            //        break;
            //    }
            //}
            //IsCompleted = allCompleted;
        }


        public abstract void Interrupt();
    }
}
