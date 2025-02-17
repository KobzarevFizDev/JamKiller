using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Location;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class FindCoverAction : BaseAction
    {
        private CoverProvider _coverProvider;
        public FindCoverAction(CoverProvider coverProvider, IUnit ownerUnit) : base(ownerUnit)
        {
            _coverProvider = coverProvider;
        }

        public Cover Find()
        {
            return _coverProvider.GetNearestCover(_ownerUnit);
        }

        public override void Execute(IActionVisitor visitor, ActionContext context, float deltaTime)
        {
            visitor.Visit(this, context);
        }
    }
}
