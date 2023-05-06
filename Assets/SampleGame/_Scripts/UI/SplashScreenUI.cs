using System;
using System.Collections;
using LevelManagement.Management;
using LevelManagement.Utility;
using UnityEngine;

namespace LevelManagement.UI
{
    [RequireComponent(typeof(ScreenFader))]
    public class SplashScreenUI : MonoBehaviour
    {
        [SerializeField] private ScreenFader _screenFader;

        [SerializeField] private float _delay = 1f;

        private void Awake()
        {
            _screenFader = GetComponent<ScreenFader>();
        }

        private void Start()
        {
            _screenFader.FadeOn();
        }

        public void FadeAndLoad()
        {
            StartCoroutine(nameof(FadeAndLoadRoutine));
        }

        private IEnumerator FadeAndLoadRoutine()
        {
            yield return new WaitForSeconds(_delay);
            _screenFader.FadeOff();
            LevelLoadManager.LoadMainMenu();
            yield return new WaitForSeconds(_screenFader.FadeDuration);
            Destroy(this.gameObject);
        }
    }
}
