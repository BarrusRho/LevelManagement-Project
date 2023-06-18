using UnityEngine;

namespace LevelManagement.Missions
{
    public class MissionSelector : MonoBehaviour
    {
        [SerializeField] protected MissionList _missionList;
        protected int _currentMissionIndex;

        public int CurrentMissionIndex => _currentMissionIndex;

        public void ClampIndex()
        {
            if (_missionList.TotalMissions == 0)
            {
                Debug.LogWarning("Mission Selector: missing scriptable object");
                return;
            }

            if (_currentMissionIndex >= _missionList.TotalMissions)
            {
                _currentMissionIndex = 0;
            }

            if (_currentMissionIndex < 0)
            {
                _currentMissionIndex = _missionList.TotalMissions - 1;
            }
        }

        public void SetIndex(int index)
        {
            _currentMissionIndex = index;
            ClampIndex();
        }

        public void IncrementIndex()
        {
            SetIndex(_currentMissionIndex +1);
        }

        public void DecrementIndex()
        {
            SetIndex(_currentMissionIndex - 1);
        }

        public MissionsSpecs GetMissionSpecs(int index)
        {
            return _missionList.GetMission(index);
        }

        public MissionsSpecs GetCurrentMission()
        {
            return _missionList.GetMission(_currentMissionIndex);
        }
    }
}
