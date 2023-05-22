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

        public static void OpenMenu()
        {
            if (MenuManager.Instance != null && Instance != null)
            {
                MenuManager.Instance.OpenMenu(Instance);
            }
        }
    }

    [RequireComponent(typeof(Canvas))]
    public abstract class MenuBase : MonoBehaviour
    {
        public virtual void OnBackButtonPressed()
        {
            if (MenuManager.Instance != null)
            {
                MenuManager.Instance.CloseMenu();
            }
        }
    }
}