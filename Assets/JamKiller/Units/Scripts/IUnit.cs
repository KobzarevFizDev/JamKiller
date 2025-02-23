using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamKiller.Units
{
    public interface IUnit
    {

        public bool CheckEnemy(out IUnit enemyUnit);

        public void StartMoveToTarget(Transform target);
        public void StartMoveToPoint(Vector3 point);
        public void StartMoveByPath(Vector3[] path);
        public void StopMove();
        // заменить на UniTask чтобы отслеживать прогресс
        public bool IsMoveCompleted();

        public float GetOptimalRangedAttackDistance();
        public int GetNumberAttacksWithouChangingPosition();
        public Transform GetTransform();

        public bool IsSeriouslyInjured();

        public Vector3 GetPosition();
        public TeamId GetTeamId();
        public void Attack();
    }
}
