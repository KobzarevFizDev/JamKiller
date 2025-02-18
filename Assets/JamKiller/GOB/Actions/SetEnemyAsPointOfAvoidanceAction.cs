using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class SetEnemyAsPointOfAvoidanceAction : BaseAction
    {
        public SetEnemyAsPointOfAvoidanceAction(IUnit ownerUnit) : base(ownerUnit) { }

        public void SetAvoidancePoint(ActionContext actionContext)
        {
            IUnit targetUnit = actionContext.TargetEnemyUnit;
            actionContext.DestinationPoint = targetUnit.GetPosition();
        }

        public override void Execute(IActionVisitor visitor, ActionContext context, float deltaTime)
        {
            visitor.Visit(this, context);
        }
    }
}
