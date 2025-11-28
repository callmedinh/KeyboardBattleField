using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace UI
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private UIBaseView prePlayView;
        [SerializeField] private UIBaseView gameplayView;
        private readonly Dictionary<ScreenType, UIBaseView> _views = new();
        private UIBaseView _currentView;
        protected override void Awake()
        {
            base.Awake();
            _views.Add(ScreenType.PrePlay, prePlayView);
            _views.Add(ScreenType.Gameplay, gameplayView);
            foreach (var view in _views) view.Value.Hide();
        }

        public void ShowView(ScreenType viewType)
        {
            if (_views.TryGetValue(viewType, out var view))
            {
                if (_currentView != null) _currentView.Hide();
                _currentView = view;
                _currentView.Show();
            }
        }


        public void ShowPopup(ScreenType viewType)
        {
            if (_views.TryGetValue(viewType, out var view)) view.Show();
        }

        public void HidePopup(ScreenType viewType)
        {
            if (_views.TryGetValue(viewType, out var view)) view.Hide();
        }
    }

    public enum ScreenType
    {
       
        PrePlay,
        Gameplay
    }
}