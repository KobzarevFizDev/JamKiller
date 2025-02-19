using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.AI;
using Unity.AI.Navigation;

namespace JamKiller.Location
{
    public class NavMeshSurfaceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<NavMeshSurface>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}
