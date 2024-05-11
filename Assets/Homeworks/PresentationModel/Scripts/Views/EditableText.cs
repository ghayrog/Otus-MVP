using System;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    [Serializable]
    public sealed class EditableText
    {
        [SerializeField]
        private Text _text;

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}