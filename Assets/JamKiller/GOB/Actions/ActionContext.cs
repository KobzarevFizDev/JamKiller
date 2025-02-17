using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Location;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class ActionContext
    {
        public ActionContext(IUnit ownerUnit)
        {
            OwnerUnit = ownerUnit;
        }

        public IUnit OwnerUnit { private set; get; }
        public Transform Target { get; set; }
        public IUnit TargetEnemyUnit { get; set; }
    }
}
