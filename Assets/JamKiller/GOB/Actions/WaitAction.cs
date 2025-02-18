using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class WaitAction : BaseAction
    {
        public WaitAction(IUnit ownerUnit) : base(ownerUnit) { }

        public override void Execute(ActionContext context, float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
