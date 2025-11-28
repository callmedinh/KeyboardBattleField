using UnityEngine;

namespace UI
{
    public abstract class UIBaseView : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
            OnShow();
        }

        public virtual void Hide()
        {
            OnHide();
            gameObject.SetActive(false);
        }

        protected virtual void OnShow()
        {
        }

        protected virtual void OnHide()
        {
        }
    }
}