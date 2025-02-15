using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace JamKiller.HandItem
{
    public class HandItemFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<HandItemFactory>().AsSingle();

            Container.Bind<ThrowHandItem>().FromComponentInHierarchy().AsSingle();
        }
    }
}
