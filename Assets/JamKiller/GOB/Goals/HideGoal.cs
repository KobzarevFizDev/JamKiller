using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Location;

namespace JamKiller.GOB
{
    public class HideGoal : BaseGoal
    {
        public override GoalId Id => GoalId.Hide;
        public override float Priority => throw new System.NotImplementedException();


        public HideGoal(CoverProvider coverProvider, IUnit ownerUnit) : base(ownerUnit)
        {
            _actions = new List<BaseAction>();
            _actions.Add(new FindCoverAction(coverProvider, ownerUnit));
            _actions.Add(new MoveToPointAction());
        }

        public override void Interrupt()
        {
            throw new System.NotImplementedException();
        }
    }
}
