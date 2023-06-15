using UnityEngine;
using System;

namespace LevelManagement.Missions
{
    [Serializable]
    public class MissionsSpecs
    {
        #region INSPECTOR

        [SerializeField] protected string _missionName;
        [SerializeField] [Multiline] protected string _missionDescription;
        [SerializeField] protected string _sceneName;
        [SerializeField] protected string _missionId;
        [SerializeField] protected Sprite _image;

        #endregion

        #region PROPERTIES

        public string MissionName => _missionName;
        public string MissionDescription => _missionDescription;
        public string SceneName => _sceneName;
        public string MissionId => _missionId;
        public Sprite Image => _image;

        #endregion
    }
}