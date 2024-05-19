using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerPopup : MonoBehaviour
    {
        [field: SerializeField]
        public UserInfoView UserInfo { get; private set; }

        [field: SerializeField]
        public StatsInfoView StatsInfo { get; private set; }

        [field: SerializeField]
        public Button CloseButton { get; private set; }

        [field: SerializeField]
        public GrayableButton LevelUpButton { get; private set; }

        public void Show()
        { 
            gameObject.SetActive(true);
        }

        public void Hide()
        { 
            gameObject.SetActive(false);
        }
    }
}
