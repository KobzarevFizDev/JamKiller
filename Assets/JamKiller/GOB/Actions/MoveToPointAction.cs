using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class MoveToPointAction : BaseAction
    {
        private bool _needToSearchEnemy;

        public MoveToPointAction(IUnit ownerUnit, bool needToSearchEnemy) : base(ownerUnit) 
        {
            _needToSearchEnemy = needToSearchEnemy;
        }


        public override void Execute(GoalContext context, float deltaTime)
        {
            if (_needToSearchEnemy)
            {
                if (_ownerUnit.CheckEnemy(out IUnit enemyUnit))
                    context.TargetEnemyUnit = enemyUnit;
                else
                    context.TargetEnemyUnit = null;
            }

            if (Status == ExecuteStatus.NotStarted)
            {
                _ownerUnit.StartMoveToPoint(context.DestinationPoint);
                Status = ExecuteStatus.InProgress;
            }
            else if (Status == ExecuteStatus.InProgress)
            {
                if (_ownerUnit.IsMoveCompleted())
                    Status = ExecuteStatus.Completed;
            }
        }
    }
}
