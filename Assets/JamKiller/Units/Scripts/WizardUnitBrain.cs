using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.GOB;
using Zenject;

namespace JamKiller.Units
{
    // todo: Нужно сделать базовый класс для UnitBrain
    public class WizardUnitBrain : MonoBehaviour
    {
        private List<BaseGoal> _goals;

        [Inject]
        private void Constructor(GoalFactory goalFactory)
        {
            var unit = GetComponent<IUnit>();
            _goals = new List<BaseGoal>();
            _goals.Add(goalFactory.CreateRangedAttackGoal(unit));
            _goals.Add(goalFactory.CreateChangedAttackPositionGoal(unit));
        }

        public BaseGoal GetActualGoal()
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
            //_hideGoal.Execute(Time.deltaTime);
        }
    }
}
