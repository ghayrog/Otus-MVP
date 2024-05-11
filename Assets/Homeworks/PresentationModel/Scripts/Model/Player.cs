using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField]
        public UserInfo UserInfo { get; private set; }

        [field: SerializeField]
        public PlayerLevel PlayerLevel { get; private set; }

        [field: SerializeField]
        public CharacterInfo CharacterInfo { get; private set; }

        [SerializeField]
        private PlayerData _initialPlayerData;

        [Inject]
        public void Construct(UserInfo userInfo, PlayerLevel playerLevel, CharacterInfo characterInfo)
        { 
            UserInfo = userInfo;
            PlayerLevel = playerLevel;
            CharacterInfo = characterInfo;
            LoadPlayerData();
        }

        [Button]
        private void LoadPlayerData()
        {
            UserInfo.ChangeName(_initialPlayerData.Name);
            UserInfo.ChangeDescription(_initialPlayerData.Description);
            UserInfo.ChangeIcon(_initialPlayerData.Icon);
            foreach (CharacterStat stat in _initialPlayerData.Stats)
            {
                CharacterInfo.AddStat(stat);
            }
        }
    }
}