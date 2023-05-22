using LevelManagement.Management;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement.UI
{
    public class SettingsMenu : MenuBase<SettingsMenu>
    {
        private DataManager _dataManager;

        [SerializeField] private Slider _masterVolumeSlider;
        [SerializeField] private Slider _sfxVolumeSlider;
        [SerializeField] private Slider _musicVolumeSlider;

        private const string MASTER_VOLUME = "MasterVolume";
        private const string SFX_VOLUME = "SFXVolume";
        private const string MUSIC_VOLUME = "MusicVolume";

        protected override void Awake()
        {
            base.Awake();

            _dataManager = FindObjectOfType<DataManager>();
        }

        private void Start()
        {
            LoadData();
        }

        public void OnMasterVolumeChanged(float volume)
        {
            if (_dataManager != null)
            {
                _dataManager.MasterVolume = volume;
            }
            //PlayerPrefs.SetFloat(MASTER_VOLUME, volume);
        }

        public void OnSFXVolumeChanged(float volume)
        {
            if (_dataManager != null)
            {
                _dataManager.SfxVolume = volume;
            }

            //PlayerPrefs.SetFloat(SFX_VOLUME, volume);
        }

        public void OnMusicVolumeChanged(float volume)
        {
            if (_dataManager != null)
            {
                _dataManager.MusicVolume = volume;
            }
            //PlayerPrefs.SetFloat(MUSIC_VOLUME, volume);
        }

        public override void OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            //PlayerPrefs.Save();

            if (_dataManager != null)
            {
                _dataManager.Save();
            }
        }

        public void LoadData()
        {
            if (_dataManager == null || _masterVolumeSlider == null || _sfxVolumeSlider == null ||
                _musicVolumeSlider == null)
            {
                return;
            }
            
            _dataManager.Load();

            _masterVolumeSlider.value = _dataManager.MasterVolume;
            _sfxVolumeSlider.value = _dataManager.SfxVolume;
            _musicVolumeSlider.value = _dataManager.MusicVolume;

            /*_masterVolumeSlider.value = PlayerPrefs.GetFloat(MASTER_VOLUME);
            _sfxVolumeSlider.value = PlayerPrefs.GetFloat(SFX_VOLUME);
            _musicVolumeSlider.value = PlayerPrefs.GetFloat(MUSIC_VOLUME);*/
        }
    }
}