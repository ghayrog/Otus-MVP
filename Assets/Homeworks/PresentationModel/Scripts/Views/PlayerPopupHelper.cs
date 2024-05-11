using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerPopupHelper : MonoBehaviour
    {
        [SerializeField]
        private PlayerPopup _popup;

        [SerializeField]
        private string _description;

        [SerializeField]
        private string _value;

        [Button]
        private void AddPlayerStat()
        { 
            _popup.AddPlayerStat(_description, _value);
        }

        [Button]
        private void ShowPopup()
        {
            _popup.Show();
        }
    }
}
