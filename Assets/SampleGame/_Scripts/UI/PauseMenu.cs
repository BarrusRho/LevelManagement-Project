using LevelManagement.Management;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement.UI
{
    public class PauseMenu : MenuBase<PauseMenu>
    {
        [SerializeField] private int _mainMenuIndex = 0;
        
        public void OnResumeButtonPressed()
        {
            Time.timeScale = 1f;
            base.OnBackButtonPressed();
        }

        public void OnRestartButtonPressed()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            base.OnBackButtonPressed();
        }

        public void OnMainMenuButtonPressed()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(_mainMenuIndex);
            MainMenu.OpenMenu();
        }

        public void OnQuitButtonPressed()
        {
            Application.Quit();
        }
    }
}
