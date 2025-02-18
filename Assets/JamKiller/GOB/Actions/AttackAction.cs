using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class AttackAction : BaseAction
    {
        public AttackAction(IUnit ownerUnit) : base(ownerUnit) { }

        public void Attack()
        {
            _ownerUnit.Attack();
        }

        public override void Execute(IActionVisitor visitor, ActionContext context, float deltaTime)
        {
            visitor.Visit(this, context, deltaTime);
        }
    }
}
