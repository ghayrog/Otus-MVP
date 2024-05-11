using System;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class UserInfoAdapter : IInitializable, IDisposable
    {
        private readonly UserInfo _userInfo;
        private readonly PlayerPopup _playerPopup;

        public UserInfoAdapter(UserInfo userInfo, PlayerPopup playerPopup)
        {
            _userInfo = userInfo;
            _playerPopup = playerPopup;
        }

        public void Initialize()
        {
            _userInfo.OnNameChanged += OnUserNameChangeHandler;
            _userInfo.OnDescriptionChanged += OnUserDescriptionChangeHandler;
            _userInfo.OnIconChanged += OnUserIconChangeHandler;

            OnUserNameChangeHandler(_userInfo.Name);
            OnUserDescriptionChangeHandler(_userInfo.Description);
            OnUserIconChangeHandler(_userInfo.Icon);
        }

        private void OnUserNameChangeHandler(string newName)
        {
            _playerPopup.NameText.SetText($"@{newName}");
        }

        private void OnUserDescriptionChangeHandler(string newDescription)
        {
            _playerPopup.DescriptionText.SetText($"{newDescription}");
        }

        private void OnUserIconChangeHandler(Sprite sprite)
        {
            _playerPopup.AvatarImage.SwapImage(sprite);
        }

        public void Dispose()
        {
            _userInfo.OnNameChanged -= OnUserNameChangeHandler;
            _userInfo.OnDescriptionChanged -= OnUserDescriptionChangeHandler;
            _userInfo.OnIconChanged -= OnUserIconChangeHandler;
        }
    }
}