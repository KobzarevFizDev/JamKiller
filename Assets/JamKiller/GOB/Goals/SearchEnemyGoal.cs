using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class SearchEnemyGoal : BaseGoal
    {
        public override int Utility => throw new System.NotImplementedException();

        public override GoalId Id => throw new System.NotImplementedException();

        public SearchEnemyGoal(IUnit ownerUnit, GoalContext context) 
            : base(ownerUnit, context, isLoop: true)
        {
            _actions = new List<BaseAction>();
            _actions.Add(new CreateRandomWayPointAction(ownerUnit));
            _actions.Add(new MoveToPointAction(ownerUnit));
        }

        public override void Interrupt()
        {
            throw new System.NotImplementedException();
        }
    }
}
