using System;
using System.Collections;
using System.Collections.Generic;
using LevelManagement.UI;
using UnityEditorInternal;
using UnityEngine;

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

            MenuBase[] menuPrefabs = { _mainMenuPrefab, _settingsMenuPrefab, _creditsMenuPrefab, _pauseMenuPrefab, _gameMenuPrefab };

            foreach (var menuPrefab in menuPrefabs)
            {
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