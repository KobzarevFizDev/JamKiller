using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using JamKiller.Location;

namespace JamKiller
{
    public class CoverProviderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CoverProvider>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}
