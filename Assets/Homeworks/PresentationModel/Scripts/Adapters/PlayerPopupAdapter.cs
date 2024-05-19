using System;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerPopupAdapter : IInitializable, IDisposable
    {
        private readonly PlayerPopup _playerPopup;

        private readonly PlayerLevel _playerLevel;

        private readonly UserInfoAdapter _userInfoAdapter;

        private readonly PlayerStatsAdapter _playerStatsAdapter;

        public PlayerPopupAdapter(UserInfo userInfo, PlayerLevel playerLevel, CharacterInfo characterInfo, PlayerPopup playerPopup)
        {
            _playerLevel = playerLevel;
            _playerPopup = playerPopup;
            _userInfoAdapter = new UserInfoAdapter(userInfo, _playerPopup.UserInfo, playerLevel);
            _playerStatsAdapter = new PlayerStatsAdapter(characterInfo, _playerPopup.StatsInfo);
        }

        public void Initialize()
        {
            _playerPopup.CloseButton.onClick.AddListener(OnCloseButtonClickHandler);
            _playerPopup.LevelUpButton.Button.onClick.AddListener(OnLevelUpButtonClick);

            _playerLevel.OnExperienceChanged += OnExperienceChangeHandler;
            _playerLevel.OnLevelUp += OnLevelUpHandler;
            OnExperienceChangeHandler(_playerLevel.CurrentExperience);

            _userInfoAdapter.Initialize();
            _playerStatsAdapter.Initialize();
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

            _userInfoAdapter.Dispose();
            _playerStatsAdapter.Dispose();
        }
    }
}