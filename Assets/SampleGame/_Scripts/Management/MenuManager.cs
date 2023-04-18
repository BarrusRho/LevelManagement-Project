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

        public static MenuManager Instance
        {
            get { return _instance; }
        }

        [Header("Menu Prefabs")] [SerializeField]
        private Menu _mainMenuPrefab;

        [SerializeField] private Menu _settingsMenuPrefab;
        [SerializeField] private Menu _creditsMenuPrefab;

        [SerializeField] private Transform _menuParent;

        private Stack<Menu> _menuStack = new Stack<Menu>();

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

            Menu[] menuPrefabs = { _mainMenuPrefab, _settingsMenuPrefab, _creditsMenuPrefab };

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

        public void OpenMenu(Menu menuInstance)
        {
            if (menuInstance == null)
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
            
            menuInstance.gameObject.SetActive(true);

            _menuStack.Push(menuInstance);
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