using System;
using System.Collections;
using System.Collections.Generic;
using LevelManagement.Management;
using LevelManagement.Missions;
using LevelManagement.Utility;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace LevelManagement.UI
{
    [RequireComponent(typeof(MissionSelector))]
    public class MissionSelectMenu : MenuBase<MissionSelectMenu>
    {
        [SerializeField] protected TextMeshProUGUI _missionNameText;
        [SerializeField] protected TextMeshProUGUI _missionDescriptionText;
        [SerializeField] protected Image _missionPreviewImage;

        [SerializeField] protected float _playDelay = 0.5f;
        [SerializeField] protected TransitionFader _transitionFaderPrefab;

        protected MissionSelector _missionSelector;
        protected MissionsSpecs _currentMission;

        protected override void Awake()
        {
            base.Awake();
            _missionSelector = GetComponent<MissionSelector>();
            UpdateMissionInfo();
        }

        private void OnEnable()
        {
            UpdateMissionInfo();
        }

        public void UpdateMissionInfo()
        {
            _currentMission = _missionSelector.GetCurrentMission();

            if (_currentMission == null) return;
            _missionNameText.text = _currentMission.MissionName;
            _missionDescriptionText.text = _currentMission.MissionDescription;
            _missionPreviewImage.sprite = _currentMission.Image;
            _missionPreviewImage.color = Color.white;
        }

        public void OnNextMissionButtonPressed()
        {
            _missionSelector.IncrementIndex();
            UpdateMissionInfo();
        }

        public void OnPreviousMissionButtonPressed()
        {
            _missionSelector.DecrementIndex();
            UpdateMissionInfo();
        }

        public void OnPlayButtonPressed()
        {
            StartCoroutine(OnPlayButtonPressedRoutine(_currentMission?.SceneName));
        }
        
        private IEnumerator OnPlayButtonPressedRoutine(string sceneName)
        {
            TransitionFader.PlayTransition(_transitionFaderPrefab);
            LevelLoadManager.LoadLevel(sceneName);
            yield return new WaitForSeconds(_playDelay);
            GameMenu.OpenMenu();
        }
    }
}
