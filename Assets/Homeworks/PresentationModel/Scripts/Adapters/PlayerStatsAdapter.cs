using System;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerStatsAdapter : IInitializable, IDisposable
    { 
        private readonly CharacterInfo _characterInfo;

        private readonly StatsInfoView _statsInfoView;

        public PlayerStatsAdapter(CharacterInfo characterInfo, StatsInfoView statsInfoView)
        {
            _characterInfo = characterInfo;
            _statsInfoView = statsInfoView;
        }

        public void Initialize()
        {
            _characterInfo.OnStatAdded += OnStatAddedHandler;
            _characterInfo.OnStatRemoved += OnStatRemovedHandler;
            OnStatRemovedHandler(null);
        }

        private void OnStatRemovedHandler(CharacterStat stat)
        {
            _statsInfoView.ClearStats();
            foreach (CharacterStat characterStat in _characterInfo.GetStats())
            {
                _statsInfoView.AddPlayerStat($"{characterStat.Name}:", characterStat.Value.ToString());
            }
        }

        private void OnStatAddedHandler(CharacterStat stat)
        {
            _statsInfoView.AddPlayerStat($"{stat.Name}:", stat.Value.ToString());
        }

        public void Dispose()
        {
            _characterInfo.OnStatAdded -= OnStatAddedHandler;
            _characterInfo.OnStatRemoved -= OnStatRemovedHandler;
        }
    }
}