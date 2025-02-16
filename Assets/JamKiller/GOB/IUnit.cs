using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamKiller.GOB
{
    public interface IUnit
    {
        public bool MoveToPoint(Vector3 point);
        public Vector3 GetPosition();
    }
}
