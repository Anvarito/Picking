using System;
using System.ComponentModel;
using Menu;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class MenuSceneInstaller : MonoInstaller
    {
        [SerializeField] private MenuButtonListener _menuButtonListener;
        public override void InstallBindings()
        {
            Container.Bind<MenuButtonListener>().FromInstance(_menuButtonListener).NonLazy();
            Container.BindInterfacesAndSelfTo<LevelSelector>().AsSingle().NonLazy();
        }

    }
}