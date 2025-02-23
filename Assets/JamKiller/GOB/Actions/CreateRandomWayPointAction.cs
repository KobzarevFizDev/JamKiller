using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class CreateRandomWayPointAction : BaseAction
    {
        private const float _radius = 40f;
        public CreateRandomWayPointAction(IUnit ownerUnit) : base(ownerUnit) { }

        public override void Execute(GoalContext context, float deltaTime)
        {
            Vector3 unitPos = _ownerUnit.GetPosition();
            float angle = Random.Range(0, 360);
            Quaternion rot = Quaternion.Euler(0, angle, 0);
            Vector3 offset = rot * Vector3.right * _radius;
            NavMeshHit hit;
            NavMesh.SamplePosition(unitPos + offset, out hit, _radius, NavMesh.AllAreas);
            context.DestinationPoint = hit.position;

            Status = ExecuteStatus.Completed;
        }
    }
}
