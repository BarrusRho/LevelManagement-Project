using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement.UI
{
    public class SettingsMenu : MenuBase<SettingsMenu>
    {
        [SerializeField] private Slider _masterVolumeSlider;
        [SerializeField] private Slider _sfxVolumeSlider;
        [SerializeField] private Slider _musicVolumeSlider;

        private const string MASTER_VOLUME = "MasterVolume";
        private const string SFX_VOLUME = "SFXVolume";
        private const string MUSIC_VOLUME = "MusicVolume";

        protected override void Awake()
        {
            base.Awake();
            LoadPlayerPrefs();
        }

        public void OnMasterVolumeChanged(float volume)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME, volume);
        }

        public void OnSFXVolumeChanged(float volume)
        {
            PlayerPrefs.SetFloat(SFX_VOLUME, volume);
        }

        public void OnMusicVolumeChanged(float volume)
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME, volume);
        }
        
        public override void OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            PlayerPrefs.Save();
        }

        public void LoadPlayerPrefs()
        {
            _masterVolumeSlider.value = PlayerPrefs.GetFloat(MASTER_VOLUME);
            _sfxVolumeSlider.value = PlayerPrefs.GetFloat(SFX_VOLUME);
            _musicVolumeSlider.value = PlayerPrefs.GetFloat(MUSIC_VOLUME);
        }
    }
}
