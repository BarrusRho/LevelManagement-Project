using UnityEngine;

namespace LevelManagement.UI
{
    public class CreditsMenu : MenuBase
    {
        private static CreditsMenu _instance;
        public static CreditsMenu Instance => _instance;

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