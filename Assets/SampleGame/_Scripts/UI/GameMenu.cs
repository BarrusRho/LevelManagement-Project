using System.Collections;
using System.Collections.Generic;
using LevelManagement.Management;
using UnityEngine;

namespace LevelManagement.UI
{
    public class GameMenu : MenuBase<GameMenu>
    {
        public void OnPauseButtonPressed()
        {
            Time.timeScale = 0f;

            PauseMenu.OpenMenu();
        }
    }
}
