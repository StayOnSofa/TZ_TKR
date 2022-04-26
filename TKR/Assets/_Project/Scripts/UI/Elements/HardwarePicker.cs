using _Project.DataServices;
using Project.UI;
using UnityEngine;

namespace _Project.UI
{
    public class HardwarePicker : MonoBehaviour
    {
        [SerializeField] private PageHardwareTypeResult _resultPage;
        
        [SerializeField] private HardwareSlide _motherBoardSlide;
        [SerializeField] private HardwareSlide _cpuSlide;
        [SerializeField] private HardwareSlide _videoCardSlide;
        [SerializeField] private HardwareSlide _ramCardSlide;
        [SerializeField] private HardwareSlide _driveCardSlide;
        
        [SerializeField] private HardwareSlider _motherBoardSlider;
        [SerializeField] private HardwareSlider _cpuSlider;
        [SerializeField] private HardwareSlider _videCardSlider;
        [SerializeField] private HardwareSlider _ramSlider;
        [SerializeField] private HardwareSlider _driveSlider;

        private MotherBoard _motherBoard;
        private CPU _cpu;
        private VideoCard _videoCard;
        private RAM _ram;
        private Drive _drive;

        [SerializeField] private GameObject _greenLight;

        private void Start()
        {
            _motherBoardSlider.OnPickHardware += (hardware) =>
            {
                _motherBoard = hardware as MotherBoard;
                _motherBoardSlide.Create(_motherBoard);
                _motherBoardSlide.SetActive(true);
                
                TryBuild();
            };
            
            
            _cpuSlider.OnPickHardware += (hardware) =>
            {
                _cpu = hardware as CPU;
                _cpuSlide.Create(_cpu);
                _cpuSlide.SetActive(true);
                
                TryBuild();
            };
            
            _videCardSlider.OnPickHardware += (hardware) =>
            {
                _videoCard = hardware as VideoCard;
                _videoCardSlide.Create(_videoCard);
                _videoCardSlide.SetActive(true);
                
                TryBuild();
            };
            
            _ramSlider.OnPickHardware += (hardware) =>
            {
                _ram = hardware as RAM;
                _ramCardSlide.Create(_ram);
                _ramCardSlide.SetActive(true);

                TryBuild();
            };
            
            _driveSlider.OnPickHardware += (hardware) =>
            {
                _drive = hardware as Drive;
                _driveCardSlide.Create(_drive);
                _driveCardSlide.SetActive(true);
                
                TryBuild();
            };
        }

        private bool HasEverything()
        {
            return (_motherBoard != null && _cpu != null && _videoCard != null && _ram != null && _drive != null);
        }

        public void PushResult()
        {
            if (HasEverything())
            {
                _resultPage.Pick(new Hardware[]{_motherBoard, _cpu, _videoCard, _ram, _drive});
            }
        }

        private void TryBuild()
        {
            _greenLight.SetActive(false);
            
            if (HasEverything())
            {
                if (_motherBoard.Compatibility(_cpu))
                {
                    if (_motherBoard.Compatibility(_videoCard))
                    {
                        if (_motherBoard.Compatibility(_drive))
                        {
                            if (_motherBoard.Compatibility(_ram))
                            {
                                _greenLight.SetActive(true);
                            }
                        }
                    }
                }
            }
        }
    }
}