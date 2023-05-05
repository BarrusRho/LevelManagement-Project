using System.Collections;
using System.Collections.Generic;
using LevelManagement.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement.Management
{
    public class LevelLoadManager : MonoBehaviour
    {
        private static int _mainMenuIndex = 0;
        
        public static void LoadLevel(string levelName)
        {
            var canLevelBeLoaded = Application.CanStreamedLevelBeLoaded(levelName);
            if (canLevelBeLoaded)
            {
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.LogWarning("LevelManager: Load Level Error - Invalid string");
            }
        }

        public static void LoadLevel(int levelIndex)
        {
            var totalSceneCount = SceneManager.sceneCountInBuildSettings;
            if (levelIndex >= 0 && levelIndex < totalSceneCount)
            {
                if (levelIndex == _mainMenuIndex)
                {
                    MainMenu.OpenMenu();
                }
                
                SceneManager.LoadScene(levelIndex);
            }
            else
            {
                Debug.LogWarning("LevelManager: Load Level Error - Invalid index");
            }
        }

        public static void ReloadCurrentLevel()
        {
            var currentScene = SceneManager.GetActiveScene();
            LoadLevel(currentScene.name);
            //LoadLevel(currentScene.buildIndex);
        }

        public static void LoadNextLevel()
        {
            var nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;

            LoadLevel(nextSceneIndex);
        }

        public static void LoadMainMenu()
        {
            LoadLevel(_mainMenuIndex);
        }
    }
}