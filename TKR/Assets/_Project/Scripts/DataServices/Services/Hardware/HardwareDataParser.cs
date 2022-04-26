using System;
using System.Collections.Generic;
using System.Linq;

namespace _Project.DataServices
{
    public class HardwareDataParser : Service
    {
        private const char с_SeparatingUnit = ',';
        
        private Type StringToHardwareType(string type)
        {
            switch (type)
            {
                case "APU":
                    return typeof(APU);
                case "Motherboard":
                    return typeof(MotherBoard);
                case "CPU":
                    return typeof(CPU);
                case "VC":
                    return typeof(VideoCard);
                case "HDD":
                    return typeof(HDD);
                case "RAM":
                    return typeof(RAM);
                case "SSD":
                    return typeof(SSD);
                default:
                    return typeof(MotherBoard);
            }
        }
        
        private HardwareType StringToHardwareClass(string type)
        {
            switch (type)
            {
                case "Gaming":
                    return HardwareType.Gaming;
                case "Low":
                    return HardwareType.Low;
                case "Middle":
                    return HardwareType.Middle;
                case "Middle/Low":
                    return HardwareType.MiddleLow;
                default:
                    return HardwareType.All;
            }
        }
        
        public IEnumerable<Hardware> ParseHardwareData(string csvData)
        {
            IEnumerable<IEnumerable<string>> datas = HardParseCSV(csvData);

            bool isHeader = true;
            
            foreach (IEnumerable<string> line in datas)
            {
                if (isHeader)
                {
                    isHeader = false;
                    continue;
                }

                string name = line.ElementAt(0);
                
                Type type = StringToHardwareType(line.ElementAt(1));
                HardwareType hardwareType = StringToHardwareClass(line.ElementAt(2));
                
                List<object> paramsList = new List<object>();
                
                paramsList.Add(name);
                paramsList.Add(hardwareType);

                for (int i = 3; i < 8; i++)
                {
                    string data = line.ElementAt(i);
                    if (data != null)
                    {
                        if (!string.IsNullOrEmpty(data.Replace(" ", "")))
                        {
                            paramsList.Add(data);
                        }
                    }
                }
                
                Hardware newService = null;

                try
                {
                    newService = (Hardware) Activator.CreateInstance(type, paramsList.ToArray());
                }
                catch
                {
                    throw new Exception("One or more critical parameters are invalid or missing of type " + type.ToString());
                }

                yield return newService;
            }
        }
        
        private IEnumerable<IEnumerable<string>> HardParseCSV(string data)
        {
            string[] values = data.Split("\n");
            
            foreach (var value in values)
            {
                yield return value.Split(с_SeparatingUnit);
            }
        }
    }
}