using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Location;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class HideGoal : BaseGoal
    {
        public override GoalId Id => GoalId.Hide;
        public override int Utility => _ownerUnit.IsSeriouslyInjured() ? 10 : 0;


        public HideGoal(CoverProvider coverProvider, IUnit ownerUnit, GoalContext context) 
            : base(ownerUnit, context, isLoop: true)
        {
            _actions = new List<BaseAction>();
            _actions.Add(new FindCoverAction(coverProvider, ownerUnit));
            _actions.Add(new MoveToPointAction(ownerUnit, needToSearchEnemy: false));
        }

        public override void Interrupt()
        {
            throw new System.NotImplementedException();
        }
    }
}
