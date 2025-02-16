using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Location;

namespace JamKiller.GOB
{
    public class FindCoverAction : BaseAction
    {
        private CoverProvider _coverProvider;
        private IUnit _ownerUnit;
        public FindCoverAction(CoverProvider coverProvider, IUnit unit)
        {
            _coverProvider = coverProvider;
            _ownerUnit = unit;
        }

        public Cover FindCover()
        {
            return _coverProvider.GetNearestCover(_ownerUnit);
        }

        public override void Accept(IActionVisitor visitor, ActionContext context, float deltaTime)
        {
            visitor.Visit(this, context);
        }
    }
}
