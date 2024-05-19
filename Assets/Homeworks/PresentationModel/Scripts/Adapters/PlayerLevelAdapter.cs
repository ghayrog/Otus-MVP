using System;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevelAdapter : IInitializable, IDisposable
    {
        private readonly PlayerLevel _playerLevel;
        private readonly PlayerLevelView _playerLevelView;

        public PlayerLevelAdapter(PlayerLevel playerLevel, PlayerLevelView playerLevelView)
        {
            _playerLevel = playerLevel;
            _playerLevelView = playerLevelView;
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
            _playerLevelView.ExperienceProgressBar.SetProgress($"XP: {experience}/{_playerLevel.RequiredExperience}", fillAmount);
        }

        private void OnLevelUpHandler()
        {
            OnExperienceChangeHandler(_playerLevel.CurrentExperience);
            _playerLevelView.LevelText.SetText($"Level: {_playerLevel.CurrentLevel}");
        }

        public void Dispose()
        {
            _playerLevel.OnExperienceChanged -= OnExperienceChangeHandler;
            _playerLevel.OnLevelUp -= OnLevelUpHandler;
        }
    }
}