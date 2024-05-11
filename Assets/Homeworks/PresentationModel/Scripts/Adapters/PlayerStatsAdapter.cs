using System;
using Zenject;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerStatsAdapter : IInitializable, IDisposable
    { 
        private readonly CharacterInfo _characterInfo;
        private readonly PlayerPopup _playerPopup;

        public PlayerStatsAdapter(CharacterInfo characterInfo, PlayerPopup playerPopup)
        {
            _characterInfo = characterInfo;
            _playerPopup = playerPopup;
        }

        public void Initialize()
        {
            _characterInfo.OnStatAdded += OnStatAddedHandler;
            _characterInfo.OnStatRemoved += OnStatRemovedHandler;
            OnStatRemovedHandler(null);
        }

        private void OnStatRemovedHandler(CharacterStat stat)
        {
            _playerPopup.ClearStats();
            foreach (CharacterStat characterStat in _characterInfo.GetStats())
            {
                _playerPopup.AddPlayerStat($"{characterStat.Name}:", characterStat.Value.ToString());
            }
        }

        private void OnStatAddedHandler(CharacterStat stat)
        {
            _playerPopup.AddPlayerStat($"{stat.Name}:", stat.Value.ToString());
        }

        public void Dispose()
        {
            _characterInfo.OnStatAdded -= OnStatAddedHandler;
            _characterInfo.OnStatRemoved -= OnStatRemovedHandler;
        }
    }
}