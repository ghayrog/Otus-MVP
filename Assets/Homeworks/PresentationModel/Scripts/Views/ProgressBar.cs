using System;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    [Serializable]
    public sealed class ProgressBar
    {
        [SerializeField]
        private Text _text;

        [SerializeField]
        private Image _progressImage;

        [SerializeField]
        private Sprite _notFilledSprite;

        [SerializeField]
        private Sprite _filledSprite;

        public void SetProgress(string text, float fillAmount)
        {
            _text.text = text;
            
            var normalizedAmount = fillAmount;
            if (normalizedAmount < 0)
            { 
                normalizedAmount = 0;
            }
            if (normalizedAmount > 1)
            { 
                normalizedAmount = 1;
            }
            _progressImage.sprite = (fillAmount < 1)? _notFilledSprite: _filledSprite;
            _progressImage.fillAmount = normalizedAmount;
        }


    }
}