using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerPopup : MonoBehaviour
    {
        [field: SerializeField]
        public EditableText NameText { get; private set; }

        [field: SerializeField]
        public EditableText LevelText { get; private set; }

        [field: SerializeField]
        public SwappableImage AvatarImage { get; private set; }

        [field: SerializeField]
        public EditableText DescriptionText { get; private set; }

        [field: SerializeField]
        public ProgressBar ExperienceProgressBar { get; private set; }

        [SerializeField]
        private StackPanel _leftStackPanel;

        [SerializeField]
        private StackPanel _rightStackPanel;

        [field: SerializeField]
        public Button CloseButton { get; private set; }

        [field: SerializeField]
        public GrayableButton LevelUpButton { get; private set; }

        private bool _isRightStackActive = true;

        public StackPanelElement AddPlayerStat(string description, string value)
        {
            _isRightStackActive = !_isRightStackActive;
            if (_isRightStackActive)
            {
                return _rightStackPanel.AddStackElement(description, value);
            }
            return _leftStackPanel.AddStackElement(description, value);
        }

        public void ClearStats()
        { 
            _leftStackPanel.ClearStackPanel();
            _rightStackPanel.ClearStackPanel();
        }

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
