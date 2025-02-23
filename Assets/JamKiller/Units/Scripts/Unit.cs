using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.GOB;
using UnityEngine.AI;
using JamKiller.Units;
using Unity.AI.Navigation;
using Zenject;

namespace JamKiller.Units
{
    // todo: Нужна декомпозиция логики
    public class Unit : MonoBehaviour, IUnit
    {
        private enum MovementType { None, FollowTarget, MoveToPoint, MoveByPath }

        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private UnitAnimation _unitAnimation;
        [SerializeField] private EnemySensor _enemySensor;

        [Range(1, 10)]
        [SerializeField] private float _optimalRangedAttackDistance;

        [Range(10, 100)]
        [SerializeField] private int _maxHealth = 100;
        [Range(10, 100)]
        [SerializeField] private int _criticalHealth = 20;

        [Range(0.2f, 1f)]
        [SerializeField] private float _timeBetweenPathUpdate = 0.5f;
        [Range(0.2f, 10f)]
        [SerializeField] private float _timeBetweenAttack = 5f;

        private float _timerUpdatePath;
        private float _timerAttack;

        private int _currentHealth;
        private int _numberAttackWithoutChanging;

        private Transform _target;
        private Vector3[] _path;
        private Vector3 _destinationPoint;

        private MovementType _movementType;

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
            if (_movementType == MovementType.FollowTarget)
            {

                _timerUpdatePath += Time.deltaTime;
                if (_timerUpdatePath > _timeBetweenPathUpdate)
                {
                    _timerUpdatePath -= _timeBetweenPathUpdate;
                    _agent.SetDestination(_target.position);
                }
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
                _unitAnimation.PlaySpellFire();
            }

        }

        public TeamId GetTeamId()
        {
            return TeamId.Player;
        }

        public void StartMoveToTarget(Transform target)
        {
            _movementType = MovementType.FollowTarget;
            _target = target;
            _agent.SetDestination(target.position);
            _agent.isStopped = false;
            _numberAttackWithoutChanging = 0;
        }

        public void StartMoveToPoint(Vector3 point)
        {
            _movementType = MovementType.MoveToPoint;
            _destinationPoint = point;
            _agent.SetDestination(point);
            _agent.isStopped = false;
            _numberAttackWithoutChanging = 0;
        }

        public void StartMoveByPath(Vector3[] path)
        {
            _movementType = MovementType.MoveByPath;
            _numberAttackWithoutChanging = 0;
            _path = path;
            StartCoroutine(MoveByPathRoutine(path));
        }

        private IEnumerator MoveByPathRoutine(Vector3[] path)
        {
            for (int currentPoint = 0; currentPoint < path.Length; currentPoint++)
            {
                Vector3 wayPoint = path[currentPoint];
                _agent.SetDestination(wayPoint);

                yield return new WaitUntil(() => !_agent.pathPending);

                DebugExtension.DebugWireSphere(wayPoint, Color.yellow, 1f, 5f);

                yield return new WaitUntil(() => _agent.remainingDistance <= 0.5f);
            }

            _agent.ResetPath();
        }

        public void StopMove()
        {
            _target = null;
            _agent.isStopped = true;
            _movementType = MovementType.None;
        }
        public bool IsMoveCompleted()
        {
            if (_movementType == MovementType.None)
                return false;

            Vector3 destinationPoint = default;
            switch (_movementType)
            {
                case MovementType.FollowTarget:
                    destinationPoint = _target.position;
                    break;

                case MovementType.MoveByPath:
                    destinationPoint = _path[^1];
                    break;

                case MovementType.MoveToPoint:
                    destinationPoint = _destinationPoint;
                    break;

                default:
                    throw new System.ArgumentException("Incorrect movement type");
            }

            Vector3 a = new Vector3(destinationPoint.x, 0, destinationPoint.z);
            Vector3 b = new Vector3(transform.position.x, 0, transform.position.z);


            DebugExtension.DebugWireSphere(a, Color.red, 1f);
            DebugExtension.DebugWireSphere(b, Color.red, 1f);
            Debug.Log($"Left to target = {Vector3.Distance(a, b) }");

            return Vector3.Distance(a, b) < 1f;
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

        public bool CheckEnemy(out IUnit enemyUnit)
        {
            enemyUnit = null;
            if(_enemySensor.CheckEnemy(TeamId.PC, out enemyUnit))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}

