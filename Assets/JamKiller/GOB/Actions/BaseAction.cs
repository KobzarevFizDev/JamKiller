using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamKiller.GOB
{
    public abstract class BaseAction
    {
        public ExecuteStatus Status { get; set; }
        public abstract void Accept(IActionVisitor visitor, ActionContext context, float deltaTime);
    }
}
