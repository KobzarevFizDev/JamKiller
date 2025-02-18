using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public class CalculatePathAroundPointAction : BaseAction
    {
        public CalculatePathAroundPointAction(IUnit ownerUnit) : base(ownerUnit) { }

        public override void Execute(ActionContext context, float deltaTime)
        {
            Vector3 center = context.AvoidancePoint;
            Vector3 finishPoint = context.DestinationPoint;
            Vector3 startPoint = _ownerUnit.GetPosition();

            float radius = Vector3.Distance(startPoint, finishPoint);

            Vector3 to = finishPoint - center;
            Vector3 from = startPoint - center;

            int numberOfPoints = 10;
            float startAngle = Mathf.Atan2(to.y, to.x);
            float finishAngle = Mathf.Atan2(from.y, from.x);

            if (finishAngle < startAngle)
                finishAngle += Mathf.PI * 2;

            Vector3[] path = new Vector3[numberOfPoints];
            for (int i = 0; i < numberOfPoints; i++)
            {
                float t = (float)i / numberOfPoints;
                float angle = Mathf.Lerp(startAngle, finishAngle, t);
                float x = center.x + radius * Mathf.Cos(angle);
                float z = center.z + radius * Mathf.Sin(angle);
                var p = new Vector3(x, center.y, z);
                path[i] = p;

                DebugExtension.DebugWireSphere(p, Color.red, 1f, 1000f);
            }
            context.Path = path;
            Status = ExecuteStatus.Completed;
        }
    }
}
