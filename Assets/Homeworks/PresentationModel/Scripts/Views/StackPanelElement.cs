using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public sealed class StackPanelElement : MonoBehaviour
    {
        [SerializeField]
        private Text _description;

        [SerializeField]
        private Text _value;

        public void SetValue(string value)
        {
            _value.text = value;
        }

        public void SetDescription(string description)
        {
            _description.text = description;
        }
    }
}