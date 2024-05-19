using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    [Serializable]
    public sealed class StatsInfoView
    {
        [SerializeField]
        private StackPanel _leftStackPanel;

        [SerializeField]
        private StackPanel _rightStackPanel;

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


    }
}
