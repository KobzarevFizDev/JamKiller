using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.GOB;

namespace JamKiller.Units
{
    public abstract class BaseUnitBrain : MonoBehaviour
    {
        protected List<BaseGoal> _goals;


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
            BaseGoal actualGoal = GetActualGoal();
            Debug.Log($"Актуальная цель = {actualGoal.Id}");
            actualGoal.Execute(Time.deltaTime);
        }
    }
}
