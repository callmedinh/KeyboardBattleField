using DefaultNamespace;
using UI;
using UnityEngine;

namespace Core
{
    public class GameManager : Singleton<GameManager>
    {
        public AudioData audioLoop;
        public PlayerController playerController;
        public GameObject playerPrefab;
        private void Start()
        {
            SoundManager.Instance.PlayMusic(audioLoop);
            UIManager.Instance.ShowView(ScreenType.PrePlay);
            GameEvents.TypeCheckComplete += TypeCheckComplete;
        }

        private void TypeCheckComplete()
        {
            InitGamePlayer();
        }

        private void InitGamePlayer()
        {
            UIManager.Instance.ShowView(ScreenType.Gameplay);
        }
    }
}