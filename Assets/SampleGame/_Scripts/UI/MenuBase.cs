using LevelManagement.Management;
using SampleGame;
using UnityEngine;

namespace LevelManagement.UI
{
    [RequireComponent(typeof(Canvas))]
    public abstract class MenuBase : MonoBehaviour
    {
        protected GameManager _gameManager;
        protected MenuManager _menuManager;

        private void Start()
        {
            _gameManager = GameManager.Instance;
            _menuManager = MenuManager.Instance;
        }

        public virtual void OnBackButtonPressed()
        {
            if (_menuManager != null)
            {
                _menuManager.CloseMenu();
            }
        }
    }
}