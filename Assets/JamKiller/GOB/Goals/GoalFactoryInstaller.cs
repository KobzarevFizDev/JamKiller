using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace JamKiller.GOB
{
    public class GoalFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<GoalFactory>()
                .AsSingle();
        }
    }
}
