using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class WaitAction : BaseAction
    {
        public WaitAction(IUnit ownerUnit) : base(ownerUnit) { }

        public override void Execute(IActionVisitor visitor, ActionContext context, float deltaTime)
        {
            visitor.Visit(this, context);
        }
    }
}
