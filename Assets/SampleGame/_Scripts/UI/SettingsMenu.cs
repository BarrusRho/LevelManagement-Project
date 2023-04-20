using UnityEngine;

namespace LevelManagement.UI
{
    public class SettingsMenu : MenuBase
    {
        private static SettingsMenu _instance;
        public static SettingsMenu Instance => _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }
        
        public override void OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
        }
    }
}
