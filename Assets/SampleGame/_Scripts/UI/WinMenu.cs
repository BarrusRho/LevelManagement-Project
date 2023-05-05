using LevelManagement.Management;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement.UI
{
    public class WinMenu : MenuBase<WinMenu>
    {
        [SerializeField] private int _mainMenuIndex = 0;
        
        public void OnNextLevelButtonPressed()
        {
            base.OnBackButtonPressed();
            LevelLoadManager.LoadNextLevel();
        }

        public void OnRestartButtonPressed()
        {
            base.OnBackButtonPressed();
            LevelLoadManager.ReloadCurrentLevel();
        }

        public void OnMainMenuButtonPressed()
        {
            LevelLoadManager.LoadMainMenu();
            MainMenu.OpenMenu();
        }
    }
}
