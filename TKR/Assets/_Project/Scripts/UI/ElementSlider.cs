using System.Collections.Generic;
using _Project.UI;
using UnityEngine;

namespace Project.UI
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class ElementSlider : MonoBehaviour
    {
        private List<Slide> _slides = new List<Slide>();
        private void Clear()
        {
            foreach (var slide in _slides)
            {
                if (slide != null)
                {
                    Destroy(slide.gameObject);
                }
            }

            _slides.Clear();
        }

        public T AddSlide<T>(T slidePrefab) where T : Slide
        {
            T slide = Instantiate(slidePrefab, transform);
            slide.transform.localScale = Vector3.one;

            _slides.Add(slide);

            return slide;
        }

        public abstract void CreateSlides();
        
        public void Build()
        {
            Clear();
            CreateSlides();
        }
    }
}
