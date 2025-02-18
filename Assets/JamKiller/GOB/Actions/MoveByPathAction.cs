using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class MoveByPathAction : BaseAction
    {
        public MoveByPathAction(IUnit ownerUnit) : base(ownerUnit) { }

        public void SetPath(ActionContext context)
        {
            _ownerUnit.StartMoveByPath(context.Path);
        }

        public bool IsPointReached => _ownerUnit.IsMoveCompleted();

        public override void Execute(IActionVisitor visitor, ActionContext context, float deltaTime)
        {
            visitor.Visit(this, context);
        }
    }
}
