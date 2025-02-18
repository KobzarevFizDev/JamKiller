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

        public override void Execute(ActionContext context, float deltaTime)
        {
            Cover cover = _coverProvider.GetNearestCover(_ownerUnit);
            if(cover.TryGetSafePosition(out Vector3 safePosition))
            {
                context.DestinationPoint = safePosition;
                Status = ExecuteStatus.Completed;
            }
            else
            {
                throw new System.InvalidOperationException("Get save position of cover error");
            }
        }
    }
}
