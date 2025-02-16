using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Location;

namespace JamKiller.GOB
{
    public class ActionContext
    {
        public ActionContext(IUnit ownerUnit)
        {
            OwnerUnit = ownerUnit;
        }

        public IUnit OwnerUnit { private set; get; }
        public Cover TargetCover;
        public IUnit TargetEnemyUnit;
    }
}
