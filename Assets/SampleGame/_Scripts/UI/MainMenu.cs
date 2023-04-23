using System;
using LevelManagement.Management;
using UnityEditor;
using UnityEngine;

namespace LevelManagement.UI
{
    public class MainMenu : MenuBase<MainMenu>
    {
        public void OnPlayButtonPressed()
        {
            if (_gameManager != null)
            {
                _gameManager.LoadNextLevel();
            }

            if (MenuManager.Instance != null && GameMenu.Instance != null)
            {
                MenuManager.Instance.OpenMenu(GameMenu.Instance);
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