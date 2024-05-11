using System;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    [Serializable]
    public sealed class SwappableImage
    {
        [SerializeField]
        private Image _image;

        public void SwapImage(Sprite sprite)
        {
            _image.sprite = sprite;
        }
    }
}