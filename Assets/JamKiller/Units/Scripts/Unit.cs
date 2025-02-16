using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.GOB;
using UnityEngine.AI;

namespace JamKiller.Units
{
    // todo: Перенести IUnit из GOB в Enemies
    public class Unit : MonoBehaviour, IUnit
    {
        [SerializeField] private NavMeshAgent _agent;
        [Range(0.2f, 1f)]
        [SerializeField] private float _timeBetweenPathUpdate = 0.5f;

        private float _timer; 

        public Vector3 GetPosition()
        {
            throw new System.NotImplementedException();
        }

        public bool MoveToPoint(Vector3 point)
        {
            if (_timer < _timeBetweenPathUpdate)
            {
                _agent.SetDestination(point);
                _timer = _timeBetweenPathUpdate;
            }

            return (_agent.pathPending == false) && (_agent.remainingDistance <= _agent.stoppingDistance + 0.1f);  
        }
    }
}
