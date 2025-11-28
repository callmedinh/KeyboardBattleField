using System.Collections;
using UnityEngine;

namespace Keyboards
{
    public class KeyController : MonoBehaviour
    {
        public KeySo keySo;
        private SpriteRenderer _sr;

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
        }
        IEnumerator WaitAndResetKey(float delay)
        {
            this.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            yield return new WaitForSeconds(delay);
            SetKeyState(false);
        }
        public void SetKeyState(bool isPressed)
        {
            if (_sr == null || keySo == null) return;

            if (isPressed)
            {
                _sr.sprite = keySo.selectedSprite;
                StartCoroutine(WaitAndResetKey(0.2f));
            }
            else
            {
                _sr.sprite = keySo.normalSprite;
                this.transform.localScale = Vector3.one;
            }
        }
    }
}