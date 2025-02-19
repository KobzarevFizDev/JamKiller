using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.GOB;
using UnityEngine.AI;
using JamKiller.Units;

namespace JamKiller.Units
{
    // todo: Нужна декомпозиция логики
    public class Unit : MonoBehaviour, IUnit
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private UnitAnimation _unitAnimation;

        [Range(1, 10)]
        [SerializeField] private float _optimalRangedAttackDistance;

        [Range(10, 100)]
        [SerializeField] private int _maxHealth = 100;
        [Range(10, 100)]
        [SerializeField] private int _criticalHealth = 20;

        [Range(0.2f, 1f)]
        [SerializeField] private float _timeBetweenPathUpdate = 0.5f;
        [Range(0.2f, 1f)]
        [SerializeField] private float _timeBetweenAttack = 0.5f;

        private float _timerUpdatePath;
        private float _timerAttack;

        private int _currentHealth;
        private int _numberAttackWithoutChanging;

        private Transform _target;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

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
                _numberAttackWithoutChanging++;
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

        public void StartMoveToPoint(Vector3 point)
        {
            _target = null;
            _agent.SetDestination(point);
            _agent.isStopped = false;
        }

        public void StartMoveByPath(Vector3[] path)
        {
            StartCoroutine(MoveByPathRoutine(path));
        }

        private IEnumerator MoveByPathRoutine(Vector3[] path)
        {
            for (int currentPoint = 0; currentPoint < path.Length; currentPoint++)
            {
                Debug.Log($"Waypoint = {currentPoint + 1}/{path.Length}");

                Vector3 wayPoint = path[currentPoint];
                _agent.SetDestination(wayPoint);

                yield return new WaitUntil(() => _agent.remainingDistance <= _agent.stoppingDistance);
            }

            Debug.Log("Waypoint. Completed");

            _agent.ResetPath();
        }

        public void StopMove()
        {
            _target = null;
            _agent.isStopped = true;
        }
        public bool IsMoveCompleted()
        {
            return !_agent.pathPending &&
           (!_agent.hasPath || _agent.remainingDistance <= _agent.stoppingDistance);

            //return (_agent.pathPending == false) && (_agent.remainingDistance <= _agent.stoppingDistance + 0.1f);
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public bool IsSeriouslyInjured()
        {
            return _currentHealth <= _criticalHealth;
        }

        public float GetOptimalRangedAttackDistance()
        {
            return _optimalRangedAttackDistance;
        }

        public int GetNumberAttacksWithouChangingPosition()
        {
            return _numberAttackWithoutChanging;
        }
    }
}

