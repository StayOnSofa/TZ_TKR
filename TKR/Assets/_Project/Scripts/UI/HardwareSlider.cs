using System;
using System.Collections.Generic;
using _Project.DataServices;
using _Project.UI;
using UnityEngine;

namespace Project.UI
{
    public abstract class HardwareSlider : ElementSlider
    {
        [SerializeField] private HardwareSlide _slide;

        public Action<Hardware> OnPickHardware;
        
        private void OnEnable()
        {
            Build();
        }

        public abstract IEnumerable<Hardware> GetData();

        public override void CreateSlides()
        {
            var datas = GetData();

            foreach (var data in datas)
            {
                var oSlide = AddSlide(_slide);
                oSlide.Create(data);
                
                oSlide.GetButton().onClick.AddListener(() =>
                {
                    PickHardware(data);
                });
            }
        }

        private void PickHardware(Hardware hardware)
        {
            OnPickHardware?.Invoke(hardware);
        }
    }
}