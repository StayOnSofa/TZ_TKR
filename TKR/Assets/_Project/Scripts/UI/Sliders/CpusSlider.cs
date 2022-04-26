using System.Collections.Generic;
using _Project.DataServices;

namespace Project.UI
{
    public class CpusSlider : HardwareSlider
    {
        public override IEnumerable<Hardware> GetData()
        {            
            var service = DataService.Instance.GetService<HardwareDataService>();
            return service.GetHardware<CPU>();
        }
    }
}
