using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    [Serializable]
    public sealed class UserInfoView
    {
        [field: SerializeField]
        public EditableText NameText { get; private set; }

        [field: SerializeField]
        public SwappableImage AvatarImage { get; private set; }

        [field: SerializeField]
        public EditableText DescriptionText { get; private set; }

        [field: SerializeField]
        public PlayerLevelView PlayerLevel { get; private set; }
    }
}
