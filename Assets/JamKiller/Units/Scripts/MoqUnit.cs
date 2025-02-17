using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.GOB;

namespace JamKiller.Units
{
    public class MoqUnit : MonoBehaviour, IUnit
    {

        [SerializeField] private TeamId _team;

        public void Attack()
        {
            throw new System.NotImplementedException();
        }

        public TeamId GetTeamId()
        {
            return _team;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public bool IsPlayerOwner()
        {
            return true;
        }

        public bool IsReachedTarget()
        {
            throw new System.NotImplementedException();
        }

        public void StartMoveToTarget(Transform point)
        {
            throw new System.NotImplementedException();
        }

        public void StopMoveToTarget()
        {
            throw new System.NotImplementedException();
        }

        Vector3 IUnit.GetPosition()
        {
            return transform.position;
        }

    }
}
