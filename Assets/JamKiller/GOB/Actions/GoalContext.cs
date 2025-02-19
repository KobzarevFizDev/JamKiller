using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Location;
using JamKiller.Units;

namespace JamKiller.GOB
{
    // todo: При смене Goal у каждый Goal должен быть определен метод сброса необходимый параметров
    public class GoalContext
    {
        public GoalContext(IUnit ownerUnit)
        {
            OwnerUnit = ownerUnit;
        }

        public Vector3[] Path { get; set; }
        public IUnit OwnerUnit { private set; get; }
        public Transform Target { get; set; }
        public Vector3 AvoidancePoint { get; set; }
        public Vector3 DestinationPoint { get; set; }
        public IUnit TargetEnemyUnit { get; set; }
    }
}
