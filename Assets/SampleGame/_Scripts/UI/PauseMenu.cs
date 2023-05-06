using LevelManagement.Management;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement.UI
{
    public class PauseMenu : MenuBase<PauseMenu>
    {
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
            LevelLoadManager.LoadMainMenu();
            MainMenu.OpenMenu();
        }

        public void OnQuitButtonPressed()
        {
            Application.Quit();
        }
    }
}
