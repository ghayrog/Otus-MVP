using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    [Serializable]
    public sealed class GrayableButton
    {
        [field: SerializeField]
        public Button Button { get; private set; }

        [SerializeField]
        private Sprite _grayedOutSprite;

        [SerializeField]
        private Sprite _activeSprite;

        [Button]
        public void GrayOut()
        {
            Button.image.sprite = _grayedOutSprite;
            Button.enabled = false;
        }

        [Button]
        public void ActivateButton()
        {
            Button.image.sprite = _activeSprite;
            Button.enabled = true;
        }
    }
}
