using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.UI
{
    public class PageSlider : MonoBehaviour
    {
        [SerializeField] public UnityEvent<Page> OnPagePicked;
        [SerializeField] private List<Page> _pages = new List<Page>();

        private void Start()
        {
            foreach (var page in _pages)
            {
                page.Init(this);
            }
        }

        private void OnValidate()
        {
            _pages.Clear();

            foreach (Transform tChild in transform)
            {
                GameObject child = tChild.gameObject;
                
                if (child.TryGetComponent(out Page page))
                {
                    _pages.Add(page);
                }
            }
        }

        public void SetActivePages(bool active)
        {
            foreach (var page in _pages)
            {
                page.SetActive(active);
            }
        }

        public void Pick(Page page)
        {
            if (_pages.Contains(page))
            {
                SetActivePages(false);
                page.SetActive(true);

                OnPagePicked?.Invoke(page);
            }
        }
    }
}