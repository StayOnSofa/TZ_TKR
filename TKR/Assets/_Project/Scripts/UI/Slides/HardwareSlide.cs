using System;
using System.Collections;
using System.Collections.Generic;
using _Project.DataServices;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI
{
    public class HardwareSlide : Slide
    {
        [SerializeField] private Text _hardwareType;
        [SerializeField] private Text _hardwareName;
        [SerializeField] private Text _hardwareUsage;
        
        public void Create(Hardware hardware)
        {
            Type type = hardware.GetType(); 
            
            _hardwareType.text = type.Name;
            _hardwareName.text = hardware.Name;
            _hardwareUsage.text = hardware.Type.ToString();
        }
    }
}
