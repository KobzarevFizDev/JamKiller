using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamKiller.GOB
{
    public class MoveToPointAction : BaseAction
    {
        private Vector3 _targetPos;

        public bool IsTargetReached { private set; get; }

        public void SetTarget(Vector3 position)
        {
            _targetPos = position;
        }

        public void MoveToPoint(IUnit unit)
        {
            IsTargetReached = unit.MoveToPoint(_targetPos);
        }

        public override void Accept(IActionVisitor visitor, ActionContext context, float deltaTime)
        {
            visitor.Visit(this, context, deltaTime);
        }
    }
}
