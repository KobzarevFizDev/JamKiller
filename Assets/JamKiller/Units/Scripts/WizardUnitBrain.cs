using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.GOB;
using Zenject;

namespace JamKiller.Units
{

    public class WizardUnitBrain : BaseUnitBrain
    {
        [Inject]
        private void Constructor(GoalFactory goalFactory)
        {
            var unit = GetComponent<IUnit>();
            var goalContext = goalFactory.CreateGoalContext(unit);
            _goals = new List<BaseGoal>();
            _goals.Add(goalFactory.CreateSearchEnemyGoal(unit, goalContext));
            _goals.Add(goalFactory.CreateRangedAttackGoal(unit, goalContext));
        }
    }
}
