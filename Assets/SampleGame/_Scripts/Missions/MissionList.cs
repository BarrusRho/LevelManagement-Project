using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Missions
{
    [CreateAssetMenu(fileName = "MissionsList", menuName = "Missions/Create MissionsList", order = 1)]
    public class MissionList : ScriptableObject
    {
        [SerializeField] private List<MissionsSpecs> _missionsList;

        public int TotalMissions => _missionsList.Count;

        public MissionsSpecs GetMission(int index)
        {
            return _missionsList[index];
        }
    }
}