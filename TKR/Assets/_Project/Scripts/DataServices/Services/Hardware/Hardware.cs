namespace _Project.DataServices
{ 
    public enum HardwareType
    {
        All,
        Gaming,
        Low,
        Middle,
        MiddleLow,
    }

    public abstract class Hardware
    {
        public readonly string Name;
        public readonly HardwareType Type;

        public Hardware(string name, HardwareType type)
        {
            Name = name;
            Type = type;
        }
    }

    public class MotherBoard : Hardware
    {
        public readonly string Socket;
        public readonly string RamType;
        public readonly string VideoCardInterface;
        public readonly string DriveInterface;
        
        public MotherBoard(string name, HardwareType type, string socket, string ramType, string videoInterface, string driveInterface) : base(name, type)
        {
            Socket = socket;
            RamType = ramType;
            VideoCardInterface = videoInterface;
            DriveInterface = driveInterface;
        }

        public bool Compatibility(CPU cpu)
        {
            return (cpu.Socket.Equals(Socket));
        }
        
        public bool Compatibility(Drive drive)
        {
            return (DriveInterface.Contains(drive.DataInterface));
        }
        
        public bool Compatibility(VideoCard videoCard)
        {
            string cutHeader = VideoCardInterface.Replace("PCI-E", "");
            string[] versions = cutHeader.Split("/");

            foreach (var v in versions)
            {
                string vCutHeader = videoCard.VideoCardInterface.Replace("PCI-E", "");
                if (v.Equals(vCutHeader))
                {
                    return true;
                }
            }

            return false;
        }
        
        public bool Compatibility(RAM ram)
        {
            return (ram.RamType.Equals(RamType));
        }
    }
    
    public class APU : Hardware
    {
        public readonly string Socket;
        
        public APU(string name, HardwareType type, string  socket) : base(name, type)
        {
            Socket = socket;
        }
    }

    public class CPU : Hardware
    {
        public readonly string Socket;
        
        public CPU(string name, HardwareType type, string socket) : base(name, type)
        {
            Socket = socket;
        }
    }

    public class RAM : Hardware
    {
        public readonly string RamType;
        public readonly string RamCapacity;
        
        public RAM(string name, HardwareType type, string ramType, string ramCapacity) : base(name, type)
        {
            RamCapacity = ramCapacity;
            RamType = ramType;
        }
        
        public RAM(string name, HardwareType type, string ramType) : base(name, type)
        {
            RamCapacity = "";
            RamType = ramType;
        }
    }
    
    public class VideoCard : Hardware
    {
        public readonly string VideoCardInterface;

        public VideoCard(string name, HardwareType type, string videoCardInterface) : base(name, type)
        {
            VideoCardInterface = videoCardInterface;
        }
    }

    public abstract class Drive : Hardware
    {
        public readonly string Capacity;
        public readonly string DataInterface;
        
        public Drive(string name, HardwareType type, string dataInterface, string capacity) : base(name, type)
        {
            DataInterface = dataInterface;
            Capacity = capacity;
        }
    }
    
    public class SSD : Drive
    {
        public SSD(string name, HardwareType type, string dataInterface, string capacity) : base(name, type, dataInterface, capacity)
        {
            return;
        }
        
        public SSD(string name, HardwareType type, string dataInterface) : base(name, type, dataInterface, "")
        {
            return;
        }
    }
    
    public class HDD : Drive
    {
        public HDD(string name, HardwareType type, string dataInterface, string capacity) : base(name, type, dataInterface, capacity)
        {
            return;
        }
        
        public HDD(string name, HardwareType type, string dataInterface) : base(name, type, dataInterface, "")
        {
            return;
        }
    }
}