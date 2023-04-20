using System;
using LevelManagement.Management;
using SampleGame;
using UnityEngine;

namespace LevelManagement.UI
{
    public abstract class MenuBase<T> : MenuBase where T : MenuBase<T>
    {
        private static T _instance;
        public static T Instance => _instance;

        protected virtual void Awake()
        {
            if (_instance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this as T;
            }
        }

        protected void OnDestroy()
        {
            _instance = null;
        }
    }

    [RequireComponent(typeof(Canvas))]
    public abstract class MenuBase : MonoBehaviour
    {
        protected GameManager _gameManager;
        protected MenuManager _menuManager;

        private void Start()
        {
            _gameManager = GameManager.Instance;
            _menuManager = MenuManager.Instance;
        }

        public virtual void OnBackButtonPressed()
        {
            if (_menuManager != null)
            {
                _menuManager.CloseMenu();
            }
        }
    }
}