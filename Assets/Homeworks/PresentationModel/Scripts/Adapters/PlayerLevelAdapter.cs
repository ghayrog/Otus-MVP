using System;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevelAdapter : IInitializable, IDisposable
    {
        private readonly PlayerLevel _playerLevel;
        private readonly PlayerPopup _playerPopup;

        public PlayerLevelAdapter(PlayerLevel playerLevel, PlayerPopup playerPopup)
        {
            _playerLevel = playerLevel;
            _playerPopup = playerPopup;
        }

        public void Initialize()
        {
            _playerLevel.OnExperienceChanged += OnExperienceChangeHandler;
            _playerLevel.OnLevelUp += OnLevelUpHandler;

            OnLevelUpHandler();
        }

        private void OnExperienceChangeHandler(int experience)
        {
            float fillAmount = (float)experience / _playerLevel.RequiredExperience;
            _playerPopup.ExperienceProgressBar.SetProgress($"XP: {experience}/{_playerLevel.RequiredExperience}", fillAmount);
        }

        private void OnLevelUpHandler()
        {
            OnExperienceChangeHandler(_playerLevel.CurrentExperience);
            _playerPopup.LevelText.SetText($"Level: {_playerLevel.CurrentLevel}");
        }

        public void Dispose()
        {
            _playerLevel.OnExperienceChanged -= OnExperienceChangeHandler;
            _playerLevel.OnLevelUp -= OnLevelUpHandler;
        }
    }
}