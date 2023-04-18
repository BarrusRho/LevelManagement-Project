using System;
using System.Collections;
using System.Collections.Generic;
using LevelManagement.Management;
using SampleGame;
using UnityEngine;

namespace LevelManagement.UI
{
    [RequireComponent(typeof(Canvas))]
    public class Menu : MonoBehaviour
    {
        private GameManager _gameManager;
        private MenuManager _menuManager;

        private void Start()
        {
            _gameManager = GameManager.Instance;
            _menuManager = MenuManager.Instance;
        }

        public void OnPlayButtonPressed()
        {
            if (_gameManager != null)
            {
                _gameManager.LoadNextLevel();
            }
        }

        public void OnSettingsButtonPressed()
        {
            var settingsMenu = transform.parent.Find("SettingsMenuCanvas(Clone)").GetComponent<Menu>();

            if (_menuManager != null && settingsMenu != null)
            {
                _menuManager.OpenMenu(settingsMenu);
            }
        }

        public void OnCreditsButtonPressed()
        {
            var creditsMenu = transform.parent.Find("CreditsMenuCanvas(Clone)").GetComponent<Menu>();

            if (_menuManager != null && creditsMenu != null)
            {
                _menuManager.OpenMenu(creditsMenu);
            }
        }

        public void OnBackButtonPressed()
        {
            if (_menuManager != null)
            {
                _menuManager.CloseMenu();
            }
        }
    }
}