using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class MoveToTarget : BaseAction
    {
        public MoveToTarget(IUnit ownerUnit) : base(ownerUnit) { }

        public void SetTarget(Transform target)
        {
            _ownerUnit.StartMoveToTarget(target);
        }
        public bool IsTargetReached => _ownerUnit.IsReachedTarget();

        public override void Execute(IActionVisitor visitor, ActionContext context, float deltaTime)
        {
            visitor.Visit(this, context, deltaTime);
        }
    }
}
