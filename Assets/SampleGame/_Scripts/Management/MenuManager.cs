using System;
using System.Collections;
using System.Collections.Generic;
using LevelManagement.UI;
using UnityEngine;

namespace LevelManagement.Management
{
    public class MenuManager : MonoBehaviour
    {
        [Header("Menu Prefabs")] [SerializeField]
        private Menu _mainMenuPrefab;

        [SerializeField] private Menu _settingsMenuPrefab;
        [SerializeField] private Menu _creditsMenuPrefab;

        [SerializeField] private Transform _menuParent;

        private void Awake()
        {
            InitialiseMenus();
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
                        // TODO Add open main menu logic
                    }
                }
            }
        }
    }
}