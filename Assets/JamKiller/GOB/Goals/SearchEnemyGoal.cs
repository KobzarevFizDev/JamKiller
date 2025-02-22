using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class SearchEnemyGoal : BaseGoal
    {
        public override int Utility
        {
            get
            {
                if (_context.TargetEnemyUnit == null)
                    return 100;
                else
                    return 0;
            }
        }

        public override GoalId Id => GoalId.SearchEnemy;

        public SearchEnemyGoal(IUnit ownerUnit, GoalContext context) 
            : base(ownerUnit, context, isLoop: true)
        {
            _actions = new List<BaseAction>();
            _actions.Add(new CreateRandomWayPointAction(ownerUnit));
            _actions.Add(new MoveToPointAction(ownerUnit, needToSearchEnemy: true));
        }

        public override void Interrupt()
        {
            throw new System.NotImplementedException();
        }
    }
}
