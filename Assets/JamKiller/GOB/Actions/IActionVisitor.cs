using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamKiller.GOB
{
    public interface IActionVisitor 
    {
        public bool Visit(MoveToPointAction action, ActionContext context, float deltaTime);
        public bool Visit(FindCoverAction action, ActionContext context);
    }
}
