using System;
using LevelManagement.Data;
using UnityEngine;

namespace LevelManagement.Management
{
    public class DataManager : MonoBehaviour
    {
        private SaveData _saveData;
        private JsonSave _jsonSave;

        public float MasterVolume
        {
            get { return _saveData.masterVolume; }
            set { _saveData.masterVolume = value; }
        }

        public float SfxVolume
        {
            get { return _saveData.sfxVolume; }
            set { _saveData.sfxVolume = value; }
        }

        public float MusicVolume
        {
            get { return _saveData.musicVolume; }
            set { _saveData.musicVolume = value; }
        }

        public string PlayerName
        {
            get { return _saveData.playerName; }
            set { _saveData.playerName = value; }
        }

        private void Awake()
        {
            _saveData = new SaveData();
            _jsonSave = new JsonSave();
        }

        public void Save()
        {
            _jsonSave.Save(_saveData);
        }

        public void Load()
        {
            _jsonSave.Load(_saveData);
        }
    }
}
