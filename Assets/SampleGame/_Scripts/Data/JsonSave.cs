using System;
using System.Text;
using System.Security.Cryptography;
using UnityEngine;
using System.IO;

namespace LevelManagement.Data
{
    public class JsonSave
    {
        private static readonly string _filename = "saveData1.sav";

        public static string GetSaveFilename()
        {
            return $"{Application.persistentDataPath}/{_filename}";
        }

        public void Save(SaveData data)
        {
            data.hashValue = String.Empty;
            var json = JsonUtility.ToJson(data);
            data.hashValue = GetSHA256(json);
            json = JsonUtility.ToJson(data);
            var saveFilename = GetSaveFilename();
            var filestream = new FileStream(saveFilename, FileMode.Create);

            using StreamWriter writer = new StreamWriter(filestream);
            writer.Write(json);
        }

        public bool Load(SaveData data)
        {
            var loadFilename = GetSaveFilename();
            if (File.Exists(loadFilename))
            {
                using StreamReader reader = new StreamReader(loadFilename);
                var json = reader.ReadToEnd();

                if (IsDataChecked(json))
                {
                    JsonUtility.FromJsonOverwrite(json, data);
                }
                else
                {
                    Debug.LogWarning($"JsonSave Load: Invalid Hash");
                }

                return true;
            }

            return false;
        }

        public void Delete()
        {
            File.Delete(GetSaveFilename());
        }

        private bool IsDataChecked(string json)
        {
            SaveData tempSaveData = new SaveData();
            JsonUtility.FromJsonOverwrite(json, tempSaveData);

            var oldHash = tempSaveData.hashValue;
            tempSaveData.hashValue = String.Empty;

            var tempJson = JsonUtility.ToJson(tempSaveData);
            var newHash = GetSHA256(tempJson);

            return (oldHash == newHash);
        }

        public string GetHexStringFromHash(byte[] hashValue)
        {
            string hexString = String.Empty;

            foreach (var value in hashValue)
            {
                hexString += value.ToString("x2");
            }

            return hexString;
        }

        private string GetSHA256(string text)
        {
            byte[] textToBytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed mySHA256 = new SHA256Managed();

            byte[] hashValue = mySHA256.ComputeHash(textToBytes);

            return GetHexStringFromHash(hashValue);
        }
    }
}
