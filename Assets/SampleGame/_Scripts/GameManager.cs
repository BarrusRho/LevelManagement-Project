using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

namespace SampleGame
{
    public class GameManager : MonoBehaviour
    {
        // reference to player
        private ThirdPersonCharacter _player;

        // reference to goal effect
        private GoalEffect _goalEffect;

        // reference to player
        private Objective _objective;

        private bool _isGameOver;
        public bool IsGameOver => _isGameOver;

        [SerializeField] private string _nextLevelName;
        [SerializeField] private int _nextLevelIndex;


        // initialize references
        private void Awake()
        {
            _player = Object.FindObjectOfType<ThirdPersonCharacter>();
            _objective = Object.FindObjectOfType<Objective>();
            _goalEffect = Object.FindObjectOfType<GoalEffect>();
        }

        // check for the end game condition on each frame
        private void Update()
        {
            if (_objective != null && _objective.IsComplete)
            {
                EndLevel();
            }
        }

        // end the level
        public void EndLevel()
        {
            if (_player != null)
            {
                // disable the player controls
                ThirdPersonUserControl thirdPersonControl =
                    _player.GetComponent<ThirdPersonUserControl>();

                if (thirdPersonControl != null)
                {
                    thirdPersonControl.enabled = false;
                }

                // remove any existing motion on the player
                Rigidbody rbody = _player.GetComponent<Rigidbody>();
                if (rbody != null)
                {
                    rbody.velocity = Vector3.zero;
                }

                // force the player to a stand still
                _player.Move(Vector3.zero, false, false);
            }

            // check if we have set IsGameOver to true, only run this logic once
            if (_goalEffect != null && !_isGameOver)
            {
                _isGameOver = true;
                _goalEffect.PlayEffect();
                LoadNextLevel();
            }
        }

        private void LoadLevel(string levelName)
        {
            var canLevelBeLoaded = Application.CanStreamedLevelBeLoaded(levelName);
            if (canLevelBeLoaded)
            {
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.LogWarning("GameManager: Load Level Error - Invalid string");
            }
        }

        private void LoadLevel(int levelIndex)
        {
            var totalSceneCount = SceneManager.sceneCountInBuildSettings;
            if (levelIndex >= 0 && levelIndex < totalSceneCount)
            {
                SceneManager.LoadScene(levelIndex);
            }
            else
            {
                Debug.LogWarning("GameManager: Load Level Error - Invalid index");
            }
        }

        public void ReloadCurrentLevel()
        {
            var currentScene = SceneManager.GetActiveScene();
            LoadLevel(currentScene.name);
            //LoadLevel(currentScene.buildIndex);
        }

        public void LoadNextLevel()
        {
            var currentScene = SceneManager.GetActiveScene();
            var currentSceneIndex = currentScene.buildIndex;
            var nextSceneIndex = currentSceneIndex + 1;
            var totalSceneCount = SceneManager.sceneCountInBuildSettings;
            if (nextSceneIndex == totalSceneCount)
            {
                nextSceneIndex = 0;
            }

            //var nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;

            LoadLevel(nextSceneIndex);
        }
    }
}