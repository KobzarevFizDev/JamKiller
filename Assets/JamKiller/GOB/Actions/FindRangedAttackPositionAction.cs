using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class FindRangedAttackPositionAction : BaseAction
    {
        public FindRangedAttackPositionAction(IUnit ownerUnit) : base(ownerUnit) { }

        // todo: У разных целей разный ActionContext !!!
        public Vector3 Find(IUnit enemy)
        {
            Vector3 enemyPosition = enemy.GetPosition();
            DebugExtension.DebugPoint(enemyPosition, Color.red);
            int angle = Random.Range(0, 360);
            Quaternion rot = Quaternion.Euler(0, angle, 0);
            Vector3 offsetFromEnemy = rot * Vector3.right * _ownerUnit.GetOptimalRangedAttackDistance();
            Vector3 attackPosition = enemyPosition + offsetFromEnemy;
            Debug.DrawLine(enemyPosition, attackPosition, Color.blue, 10f);
            return attackPosition;
        }

        public override void Execute(IActionVisitor visitor, ActionContext context, float deltaTime)
        {
            visitor.Visit(this, context);
        }
    }
}
