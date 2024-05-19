using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    [Serializable]
    public sealed class PlayerLevelView
    {
        [field: SerializeField]
        public EditableText LevelText { get; private set; }

        [field: SerializeField]
        public ProgressBar ExperienceProgressBar { get; private set; }
    }
}
