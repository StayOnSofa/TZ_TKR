using UnityEngine;
using UnityEngine.Events;

namespace _Project.UI
{
    public class Page : MonoBehaviour
    {
        [SerializeField] public UnityEvent OnPick;

        private PageSlider _pageSlider;

        public void Init(PageSlider pageSlider)
        {
            _pageSlider = pageSlider;
        }

        public void Pick()
        {
            _pageSlider?.Pick(this);
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}