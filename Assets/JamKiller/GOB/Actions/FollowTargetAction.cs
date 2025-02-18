using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class FollowTargetAction : BaseAction
    {
        public FollowTargetAction(IUnit ownerUnit) : base(ownerUnit) { }

        public void SetTarget(Transform target)
        {
            _ownerUnit.StartMoveToTarget(target);
        }

        public bool IsTargetReached => _ownerUnit.IsMoveCompleted();

        public override void Execute(IActionVisitor visitor, ActionContext context, float deltaTime)
        {
            visitor.Visit(this, context, deltaTime);
        }
    }
}
