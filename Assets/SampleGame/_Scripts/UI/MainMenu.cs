using System;
using UnityEngine;

namespace LevelManagement.UI
{
    public class MainMenu : MenuBase
    {
        private static MainMenu _instance;
        public static MainMenu Instance => _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
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
            var settingsMenu = SettingsMenu.Instance;

            if (_menuManager != null && settingsMenu != null)
            {
                _menuManager.OpenMenu(settingsMenu);
            }
        }

        public void OnCreditsButtonPressed()
        {
            var creditsMenu = CreditsMenu.Instance;

            if (_menuManager != null && creditsMenu != null)
            {
                _menuManager.OpenMenu(creditsMenu);
            }
        }

        public override void OnBackButtonPressed()
        {
            Application.Quit();
        }
    }
}