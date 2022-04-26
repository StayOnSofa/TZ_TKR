using System.Collections.Generic;
using System.Linq;
using _Project.DataServices;
using TMPro;
using UnityEngine;

namespace _Project.UI
{
    public class PageHardwareTypeResult : Page
    {
        [SerializeField] private TextMeshProUGUI _hardwareType;
        
        public void Pick(IEnumerable<Hardware> hardwares)
        {
            Pick();
            
            int type = 0;
            
            foreach (var hardware in hardwares)
            {
                type += (int)hardware.Type;
            }

            type /= hardwares.Count();

            _hardwareType.text = ((HardwareType) type).ToString();
        }
    }
}