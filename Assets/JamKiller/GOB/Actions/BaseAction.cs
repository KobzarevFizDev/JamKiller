using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Units;

namespace JamKiller.GOB
{
    public enum ExecuteStatus { NotStarted, InProgress, Completed }

    public abstract class BaseAction
    {
        public ExecuteStatus Status { get; set; }
        protected IUnit _ownerUnit;

        public BaseAction(IUnit ownerUnit)
        {
            _ownerUnit = ownerUnit;
        }

        public abstract void Execute(GoalContext context, float deltaTime);
    }
}
