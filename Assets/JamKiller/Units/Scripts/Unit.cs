using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.GOB;
using UnityEngine.AI;
using JamKiller.Units;

namespace JamKiller.Units
{
    public class Unit : MonoBehaviour, IUnit
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private UnitAnimation _unitAnimation;
        [Range(0.2f, 1f)]
        [SerializeField] private float _timeBetweenPathUpdate = 0.5f;
        [Range(0.2f, 1f)]
        [SerializeField] private float _timeBetweenAttack = 0.5f;

        private float _timerUpdatePath;
        private float _timerAttack;

        private Transform _target;

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        private void Update()
        {
            UpdatePathIfNeccessary();
        }

        private void UpdatePathIfNeccessary()
        {
            if (_target == null)
                return;

            _timerUpdatePath += Time.deltaTime;
            if (_timerUpdatePath > _timeBetweenPathUpdate)
            {
                _timerUpdatePath -= _timeBetweenPathUpdate;
                _agent.SetDestination(_target.position);
            }
        }


        public void Attack()
        {
            _timerAttack += Time.deltaTime;
            if(_timerAttack > _timeBetweenAttack)
            {
                Debug.Log("Анимация атаки");
                _timerAttack -= _timeBetweenAttack;
            }

        }

        public TeamId GetTeamId()
        {
            return TeamId.Player;
        }

        public void StartMoveToTarget(Transform target)
        {
            _target = target;
            _agent.SetDestination(target.position);
            _agent.isStopped = false;
        }

        public void StopMoveToTarget()
        {
            _target = null;
            _agent.isStopped = true;
        }
        public bool IsReachedTarget()
        {
            return (_agent.pathPending == false) && (_agent.remainingDistance <= _agent.stoppingDistance + 0.1f);
        }

        public Transform GetTransform()
        {
            return transform;
        }
    }
}
