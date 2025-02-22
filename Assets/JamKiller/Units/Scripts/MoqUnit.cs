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

        public int GetNumberAttacksWithouChangingPosition()
        {
            throw new System.NotImplementedException();
        }

        public float GetOptimalRangedAttackDistance()
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

        public bool IsMoveCompleted()
        {
            throw new System.NotImplementedException();
        }

        public bool IsSeriouslyInjured()
        {
            throw new System.NotImplementedException();
        }

        public void StartMoveToPoint(Vector3 point)
        {
            throw new System.NotImplementedException();
        }

        public void StartMoveToTarget(Transform point)
        {
            throw new System.NotImplementedException();
        }

        public void StopMove()
        {
            throw new System.NotImplementedException();
        }

        Vector3 IUnit.GetPosition()
        {
            return transform.position;
        }

        public void StartMoveByPath(Vector3[] path)
        {
            throw new System.NotImplementedException();
        }

        public Bounds GetNavMeshBounds()
        {
            throw new System.NotImplementedException();
        }

        public bool CheckEnemy(out IUnit enemyUnit)
        {
            throw new System.NotImplementedException();
        }
    }
}
