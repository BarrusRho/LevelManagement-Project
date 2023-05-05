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
            LevelLoadManager.LoadNextLevel();
            GameMenu.OpenMenu();
        }

        public void OnSettingsButtonPressed()
        {
            SettingsMenu.OpenMenu();
        }

        public void OnCreditsButtonPressed()
        {
            CreditsMenu.OpenMenu();
        }

        public override void OnBackButtonPressed()
        {
            Application.Quit();
        }
    }
}