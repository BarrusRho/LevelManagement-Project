using UnityEngine;

namespace LevelManagement.UI
{
    public class MainMenu : MenuBase
    {
        public void OnPlayButtonPressed()
        {
            if (_gameManager != null)
            {
                _gameManager.LoadNextLevel();
            }
        }

        public void OnSettingsButtonPressed()
        {
            var settingsMenu = transform.parent.Find("SettingsMenuCanvas(Clone)").GetComponent<MenuBase>();

            if (_menuManager != null && settingsMenu != null)
            {
                _menuManager.OpenMenu(settingsMenu);
            }
        }

        public void OnCreditsButtonPressed()
        {
            var creditsMenu = transform.parent.Find("CreditsMenuCanvas(Clone)").GetComponent<MenuBase>();

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
