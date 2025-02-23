using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace JamKiller.Units
{
    public class UnitsProviderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<UnitsProvider>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}
