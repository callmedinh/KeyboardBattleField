using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameplayView : UIBaseView
    {
        public Image heartImage;
        public Sprite fullHeart;
        public Sprite emptyHeart;
        private List<Image> _heartImageList = new();
        public PlayerController playerController;
        public Transform heartParent;

        private void OnEnable()
        {
            if (playerController == null)
            {
                playerController = FindFirstObjectByType<PlayerController>();
            }
            Init(3);
        }

        private void Start()
        {
            playerController.Health.OnHealthChanged += UpdateHearts;
        }

        private void Init(int maxHealth)
        {
            for (int i = 0; i < maxHealth; i++)
            {
                _heartImageList.Add(Instantiate(heartImage, heartParent) as Image);
            }
        }

        private void UpdateHearts(int currentHealth, int maxHealth)
        {
            for (int i = 0; i < maxHealth; i++)
            {
                if (i < currentHealth)
                {
                    _heartImageList[i].sprite = fullHeart;
                }
                else
                {
                    _heartImageList[i].sprite = emptyHeart;
                }
            }
        }
    }
}