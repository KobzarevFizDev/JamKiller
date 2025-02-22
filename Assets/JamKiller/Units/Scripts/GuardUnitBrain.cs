using System.Collections;
using System.Collections.Generic;
using Zenject;
using JamKiller.GOB;

namespace JamKiller.Units
{
    public class UnitBrain : BaseUnitBrain
    {
        [Inject]
        private void Constructor(GoalFactory goalFactory)
        {
            var unit = GetComponent<IUnit>();
            var goalContext = goalFactory.CreateGoalContext(unit);
            _goals = new List<BaseGoal>();
            _goals.Add(goalFactory.CreateAttackUnitGoal(unit, goalContext));
            _goals.Add(goalFactory.CreateHideGoal(unit, goalContext));
        }

    }
}
