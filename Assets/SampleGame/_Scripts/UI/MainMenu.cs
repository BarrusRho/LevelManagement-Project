using System;
using System.Collections;
using LevelManagement.Management;
using LevelManagement.Utility;
using UnityEditor;
using UnityEngine;

namespace LevelManagement.UI
{
    public class MainMenu : MenuBase<MainMenu>
    {
        [SerializeField] private float _playDelay = 0.5f;
        [SerializeField] private TransitionFader _transitionFaderPrefab;
        
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