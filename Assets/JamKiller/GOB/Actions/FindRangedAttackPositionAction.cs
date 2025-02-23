using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class FindRangedAttackPositionAction : BaseAction
    {
        public FindRangedAttackPositionAction(IUnit ownerUnit) : base(ownerUnit) { }

        public override void Execute(GoalContext context, float deltaTime)
        {
            IUnit enemy = context.TargetEnemyUnit;
            Vector3 enemyPosition = enemy.GetPosition();
            int angle = Random.Range(0, 360);
            Quaternion rot = Quaternion.Euler(0, angle, 0);
            Vector3 offsetFromEnemy = rot * Vector3.right * _ownerUnit.GetOptimalRangedAttackDistance();
            Vector3 rangedAttackPosition = enemyPosition + offsetFromEnemy;
            context.DestinationPoint = rangedAttackPosition;
            Status = ExecuteStatus.Completed;
        }
    }
}
