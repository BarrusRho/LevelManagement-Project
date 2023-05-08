using UnityEngine;

namespace LevelManagement.UI
{
    public class SettingsMenu : MenuBase<SettingsMenu>
    {
        public void OnMasterVolumeChanged(float volume)
        {
            
        }

        public void OnSFXVolumeChanged(float volume)
        {
            
        }

        public void OnMusicVolumeChanged(float volume)
        {
            
        }
        
        public override void OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
        }
    }
}
