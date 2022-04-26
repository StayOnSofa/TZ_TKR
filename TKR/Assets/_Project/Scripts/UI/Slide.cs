using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class Slide : MonoBehaviour
    {
        private Button _button;
        
        public Button GetButton()
        {
            if (_button == null)
            {
                return GetComponent<Button>();
            }

            return _button;
        }
        
        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        private void OnDestroy()
        {
            GetButton().onClick.RemoveAllListeners();
        }
    }
}