using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using JamKiller.GOB;
using System.Linq;

namespace JamKiller.Units
{
    public class UnitBrain : MonoBehaviour
    {
        private List<BaseGoal> _goals;

        [Inject]
        private void Constructor(GoalFactory goalFactory)
        {
            var unit = GetComponent<IUnit>();
            var goalContext = goalFactory.CreateGoalContext(unit);
            _goals = new List<BaseGoal>();
            _goals.Add(goalFactory.CreateAttackUnitGoal(unit, goalContext));
            _goals.Add(goalFactory.CreateHideGoal(unit, goalContext));
        }

        public BaseGoal GetActualGoal()
        {
            BaseGoal actualGoal = null;
            foreach(BaseGoal goal in _goals)
            {
                if (actualGoal == null || actualGoal.Utility < goal.Utility)
                    actualGoal = goal;
            }
            return actualGoal;
        }

        private void Update()
        {
            BaseGoal actualGoal = GetActualGoal();
            Debug.Log($"Актуальная цель = {actualGoal.Id}");
            actualGoal.Execute(Time.deltaTime);
            //_hideGoal.Execute(Time.deltaTime);
        }

    }
}
