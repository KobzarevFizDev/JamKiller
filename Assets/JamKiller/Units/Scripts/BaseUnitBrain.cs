using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.GOB;

namespace JamKiller.Units
{
    public abstract class BaseUnitBrain : MonoBehaviour
    {
        protected List<BaseGoal> _goals;

        private BaseGoal _previousGoal;
        private BaseGoal _actualGoal;

        private BaseGoal GetActualGoal()
        {
            BaseGoal actualGoal = null;
            foreach (BaseGoal goal in _goals)
            {
                if (actualGoal == null || actualGoal.Utility < goal.Utility)
                    actualGoal = goal;
            }
            return actualGoal;
        }

        private void Update()
        {
            _previousGoal = _actualGoal;
            _actualGoal = GetActualGoal();
            if (GoalWasChanged())
            {
                _previousGoal?.Reset();
                _actualGoal.Reset();
                Debug.Log($"Актуальная цель = {_actualGoal.Id}");
            }
            _actualGoal.Execute(Time.deltaTime);
        }

        private bool GoalWasChanged()
        {
            return _previousGoal != _actualGoal;
        }
    }
}
