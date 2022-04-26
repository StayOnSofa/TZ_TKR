using System.Collections.Generic;
using UnityEngine;

namespace _Project.DataServices
{
    public class HardwareDataService : Service
    {
        private const string c_HardwareDataPath = "HardwareData";
        
        private IEnumerable<Hardware> _hardwares;

        public IEnumerable<Hardware> GetHardwares()
        {
            if (_hardwares == null)
            {
                var textFile = Resources.Load<TextAsset>(c_HardwareDataPath);
                string text = textFile.text;

                _hardwares = GetService<HardwareDataParser>().ParseHardwareData(text);
            }

            return _hardwares;
        }

        public IEnumerable<T> GetHardware<T>() where T : Hardware
        {
            foreach (var hardware in GetHardwares())
            {
                if (hardware is T)
                {
                    yield return hardware as T;
                }
            }
        }

        public IEnumerable<APU> GetAPUs()
        {
            return GetHardware<APU>();
        }

        public IEnumerable<CPU> GetCPUs()
        {
            return GetHardware<CPU>();
        }

        public IEnumerable<MotherBoard> GetMotherBoards()
        {
            return GetHardware<MotherBoard>();
        }

        public IEnumerable<RAM> GetRAMs()
        {
            return GetHardware<RAM>();
        }
        
        public IEnumerable<Drive> GetDrives()
        {
            return GetHardware<Drive>();
        }

        public IEnumerable<VideoCard> GetVideoCards()
        {
            return GetHardware<VideoCard>();
        }
    }
}