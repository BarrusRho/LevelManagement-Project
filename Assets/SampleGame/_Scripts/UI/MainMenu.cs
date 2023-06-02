using System;
using System.Collections;
using LevelManagement.Management;
using LevelManagement.Utility;
using TMPro;
using UnityEngine;

namespace LevelManagement.UI
{
    public class MainMenu : MenuBase<MainMenu>
    {
        private DataManager _dataManager;
        
        [SerializeField] private float _playDelay = 0.5f;
        [SerializeField] private TransitionFader _transitionFaderPrefab;
        [SerializeField] private TMP_InputField _inputField;

        protected override void Awake()
        {
            base.Awake();

            _dataManager = FindObjectOfType<DataManager>();
        }

        private void Start()
        {
            LoadData();
        }

        private void LoadData()
        {
            if (_dataManager != null && _inputField != null)
            {
                _dataManager.Load();
                
                _inputField.text = _dataManager.PlayerName;
            }
        }

        public void OnPlayerNameValueChanged(string playerName)
        {
            if (_dataManager != null)
            {
                _dataManager.PlayerName = playerName;
            }
        }

        public void OnPlayerNameEndEdit()
        {
            if (_dataManager != null)
            {
                _dataManager.Save();
            }
        }

        public void OnPlayButtonPressed()
        {
            StartCoroutine(nameof(OnPlayButtonPressedRoutine));
        }

        private IEnumerator OnPlayButtonPressedRoutine()
        {
            TransitionFader.PlayTransition(_transitionFaderPrefab);
            LevelLoadManager.LoadNextLevel();
            yield return new WaitForSeconds(_playDelay);
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