using System;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerPopupButtonsAdapter : IInitializable, IDisposable
    {
        private readonly PlayerLevel _playerLevel;
        private readonly PlayerPopup _playerPopup;

        public PlayerPopupButtonsAdapter(PlayerPopup playerPopup, PlayerLevel playerLevel)
        {
            _playerPopup = playerPopup;
            _playerLevel = playerLevel;
        }

        public void Initialize()
        {
            _playerPopup.CloseButton.onClick.AddListener(OnCloseButtonClickHandler);
            _playerPopup.LevelUpButton.Button.onClick.AddListener(OnLevelUpButtonClick);

            _playerLevel.OnExperienceChanged += OnExperienceChangeHandler;
            _playerLevel.OnLevelUp += OnLevelUpHandler;
            OnExperienceChangeHandler(_playerLevel.CurrentExperience);
        }

        private void OnLevelUpHandler()
        {
            OnExperienceChangeHandler(_playerLevel.CurrentExperience);
        }

        private void OnExperienceChangeHandler(int experience)
        {
            if (_playerLevel.CanLevelUp())
            {
                _playerPopup.LevelUpButton.ActivateButton();
                _playerPopup.Show();
            }
            else
            {
                _playerPopup.LevelUpButton.GrayOut();
            }
        }

        private void OnCloseButtonClickHandler()
        {
            _playerPopup.Hide();
        }

        private void OnLevelUpButtonClick()
        {
            _playerLevel.LevelUp();
            OnExperienceChangeHandler(_playerLevel.CurrentExperience);
        }

        public void Dispose()
        {
            _playerPopup.CloseButton.onClick.RemoveListener(OnCloseButtonClickHandler);
            _playerPopup.LevelUpButton.Button.onClick.RemoveListener(OnLevelUpButtonClick);
            _playerLevel.OnExperienceChanged -= OnExperienceChangeHandler;
            _playerLevel.OnLevelUp -= OnLevelUpHandler;

        }
    }
}