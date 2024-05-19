using System;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{

    public sealed class UserInfoAdapter : IInitializable, IDisposable
    {
        private readonly UserInfo _userInfo;
        
        private readonly UserInfoView _userInfoView;

        private readonly PlayerLevelAdapter _playerLevelAdapter;

        public UserInfoAdapter(UserInfo userInfo, UserInfoView userInfoView, PlayerLevel playerLevel)
        {
            _userInfo = userInfo;
            _userInfoView = userInfoView;
            _playerLevelAdapter = new PlayerLevelAdapter(playerLevel, userInfoView.PlayerLevel);
        }

        public void Initialize()
        {
            _userInfo.OnNameChanged += OnUserNameChangeHandler;
            _userInfo.OnDescriptionChanged += OnUserDescriptionChangeHandler;
            _userInfo.OnIconChanged += OnUserIconChangeHandler;

            OnUserNameChangeHandler(_userInfo.Name);
            OnUserDescriptionChangeHandler(_userInfo.Description);
            OnUserIconChangeHandler(_userInfo.Icon);

            _playerLevelAdapter.Initialize();
        }

        private void OnUserNameChangeHandler(string newName)
        {
            _userInfoView.NameText.SetText($"@{newName}");
        }

        private void OnUserDescriptionChangeHandler(string newDescription)
        {
            _userInfoView.DescriptionText.SetText($"{newDescription}");
        }

        private void OnUserIconChangeHandler(Sprite sprite)
        {
            _userInfoView.AvatarImage.SwapImage(sprite);
        }

        public void Dispose()
        {
            _userInfo.OnNameChanged -= OnUserNameChangeHandler;
            _userInfo.OnDescriptionChanged -= OnUserDescriptionChangeHandler;
            _userInfo.OnIconChanged -= OnUserIconChangeHandler;

            _playerLevelAdapter.Dispose();
        }
    }
}