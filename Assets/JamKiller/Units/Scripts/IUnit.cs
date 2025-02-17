using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamKiller.Units
{
    public interface IUnit
    {
        public void StartMoveToTarget(Transform target);
        public void StopMoveToTarget();
        public bool IsReachedTarget();
        public Transform GetTransform();

        public Vector3 GetPosition();
        public TeamId GetTeamId();
        public void Attack();
    }
}
