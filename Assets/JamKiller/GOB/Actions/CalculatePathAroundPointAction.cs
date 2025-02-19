using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class CalculatePathAroundPointAction : BaseAction
    {
        public CalculatePathAroundPointAction(IUnit ownerUnit) : base(ownerUnit) { }

        public override void Execute(GoalContext context, float deltaTime)
        {
            Debug.Log("Выполняется CalculatePathAroundPointAction");

            DebugExtension.DebugWireSphere(context.DestinationPoint, Color.yellow, 1f, 1000f);
            DebugExtension.DebugWireSphere(_ownerUnit.GetPosition(), Color.yellow, 1f, 1000f);

            Vector3 center = context.AvoidancePoint;
            Vector3 finishPoint = context.DestinationPoint;
            Vector3 startPoint = _ownerUnit.GetPosition();

            float startRadius = Vector3.Distance(startPoint, center);
            float finishRadius = Vector3.Distance(finishPoint, center);

            Vector3 to = (finishPoint - center).normalized;
            Vector3 from = (startPoint - center).normalized;

            float startAngle = Mathf.Atan2(from.z, from.x);
            float finishAngle = Mathf.Atan2(to.z, to.x);

            if (finishAngle < startAngle)
                finishAngle += Mathf.PI * 2;

            int numberOfPoints = 10;
            Vector3[] path = new Vector3[numberOfPoints];

            for (int i = 0; i < numberOfPoints; i++)
            {
                float t = (float)i / (numberOfPoints - 1);
                float angle = Mathf.Lerp(startAngle, finishAngle, t);
                float radius = Mathf.Lerp(startRadius, finishRadius, t);

                float x = center.x + radius * Mathf.Cos(angle);
                float z = center.z + radius * Mathf.Sin(angle);
                Vector3 p = new Vector3(x, center.y, z);

                path[i] = p;

                DebugExtension.DebugWireSphere(p, Color.red, 1f, 1000f);
            }

            context.Path = path;
            Status = ExecuteStatus.Completed;
        }
    }
}
