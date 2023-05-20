
namespace LevelManagement.Data
{
    public class SaveData
    {
        public string playerName;
        private readonly string _defaultPlayerName = "Player";

        public float masterVolume, sfxVolume, musicVolume;

        public SaveData()
        {
            playerName = _defaultPlayerName;
            masterVolume = 0f;
            sfxVolume = 0f;
            musicVolume = 0f;
        }
    }
}
