using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using JamKiller.Player;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Transform _handItemPreview;
    [SerializeField] private float _lookSens = 0.08f;

    public override void InstallBindings()
    {
        Container
            .Bind<Player>()
            .FromComponentInHierarchy()
            .AsSingle()
            .WhenInjectedInto<PlayerMotionHandler>();

        Container
            .Bind<PlayerMotionHandler>()
            .FromComponentInHierarchy()
            .AsSingle()
            .WhenInjectedInto<PlayerMotionInputHandler>();

        Container
            .Bind<PlayerActionHandler>()
            .FromComponentInHierarchy()
            .AsSingle()
            .WhenInjectedInto<PlayerActionInputHandler>();

        Container
            .BindInterfacesAndSelfTo<PlayerMotionInputHandler>()
            .AsSingle()
            .WithArguments(_lookSens);

        Container.BindInterfacesAndSelfTo<PlayerActionInputHandler>()
            .AsSingle()
            .WithArguments(_handItemPreview);

    }
}
