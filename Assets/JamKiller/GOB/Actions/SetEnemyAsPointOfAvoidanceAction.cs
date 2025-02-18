using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class SetEnemyAsPointOfAvoidanceAction : BaseAction
    {
        public SetEnemyAsPointOfAvoidanceAction(IUnit ownerUnit) : base(ownerUnit) { }


        public override void Execute(ActionContext context, float deltaTime)
        {
            IUnit targetUnit = context.TargetEnemyUnit;
            context.DestinationPoint = targetUnit.GetPosition();
            Status = ExecuteStatus.Completed;
        }
    }
}
