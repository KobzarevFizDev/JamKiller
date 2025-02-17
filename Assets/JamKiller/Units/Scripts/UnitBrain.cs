using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using JamKiller.GOB;

namespace JamKiller.Units
{
    public class UnitBrain : MonoBehaviour
    {

        private HideGoal _hideGoal;
        private AttackUnitGoal _attackUnitGoal;

        [Inject]
        private void Constructor(GoalFactory goalFactory)
        {
            var unit = GetComponent<IUnit>();
            _hideGoal = goalFactory.CreateHideGoal(unit);
            _attackUnitGoal = goalFactory.CreateAttackUnitGoal(unit);
        }

        private void Update()
        {
            _attackUnitGoal.Execute(Time.deltaTime);
            //_hideGoal.Execute(Time.deltaTime);
        }

    }
}
