using System;
using System.Collections;
using System.Collections.Generic;
using LevelManagement.UI;
using UnityEditorInternal;
using UnityEngine;
using System.Reflection;

namespace LevelManagement.Management
{
    public class MenuManager : MonoBehaviour
    {
        private static MenuManager _instance;
        public static MenuManager Instance => _instance;

        [Header("Menu Prefabs")] 
        [SerializeField] private MainMenu _mainMenuPrefab;
        [SerializeField] private SettingsMenu _settingsMenuPrefab;
        [SerializeField] private CreditsMenu _creditsMenuPrefab;
        [SerializeField] private PauseMenu _pauseMenuPrefab;
        [SerializeField] private GameMenu _gameMenuPrefab;
        [SerializeField] private WinMenu _winMenuPrefab;
        [SerializeField] private Transform _menuParent;

        private Stack<MenuBase> _menuStack = new Stack<MenuBase>();

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;

                InitialiseMenus();
                
                DontDestroyOnLoad(this.gameObject);
            }
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

        private void InitialiseMenus()
        {
            if (_menuParent == null)
            {
                var menuParentObject = new GameObject("Menus");
                _menuParent = menuParentObject.transform;
            }
            
            DontDestroyOnLoad(_menuParent.gameObject);
            
            var myFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
            FieldInfo[] fields = this.GetType().GetFields(myFlags); 

            foreach (var field in fields)
            {
                var menuPrefab = field.GetValue(this) as MenuBase;
                if (menuPrefab != null)
                {
                    var menuInstance = Instantiate(menuPrefab, _menuParent);

                    if (menuPrefab != _mainMenuPrefab)
                    {
                        menuInstance.gameObject.SetActive(false);
                    }
                    else
                    {
                        OpenMenu(menuInstance);
                    }
                }

            }
        }

        public void OpenMenu(MenuBase menuBaseInstance)
        {
            if (menuBaseInstance == null)
            {
                Debug.LogWarning($"MenuManager OpenMenu() error: Invalid Menu");
                return;
            }

            if (_menuStack.Count > 0)
            {
                foreach (var menu in _menuStack)
                {
                    menu.gameObject.SetActive(false);
                }
            }
            
            menuBaseInstance.gameObject.SetActive(true);

            _menuStack.Push(menuBaseInstance);
        }

        public void CloseMenu()
        {
            if (_menuStack.Count == 0)
            {
                Debug.LogWarning($"MenuManager CloseMenu() error: No menus in stack");
                return;
            }

            var topMenu = _menuStack.Pop();
            topMenu.gameObject.SetActive(false);

            if (_menuStack.Count > 0)
            {
                var nextMenu = _menuStack.Peek();
                nextMenu.gameObject.SetActive(true);
            }
        }
    }
}