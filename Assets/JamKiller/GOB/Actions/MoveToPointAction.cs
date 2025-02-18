using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class MoveToPointAction : BaseAction
    {
        public MoveToPointAction(IUnit ownerUnit) : base(ownerUnit) { }

        public void SetPoint(Vector3 point)
        {
            _ownerUnit.StartMoveToPoint(point);
        }

        public bool IsPointReached => _ownerUnit.IsMoveCompleted();

        public override void Execute(IActionVisitor visitor, ActionContext context, float deltaTime)
        {
            visitor.Visit(this, context);
        }
    }
}
