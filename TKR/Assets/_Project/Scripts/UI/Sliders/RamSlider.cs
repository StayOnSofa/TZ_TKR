using System.Collections.Generic;
using _Project.DataServices;
using Project.UI;

namespace _Project.UI
{
    public class RamSlider : HardwareSlider
    {
        public override IEnumerable<Hardware> GetData()
        {
            var service = DataService.Instance.GetService<HardwareDataService>();
            return service.GetHardware<RAM>();
        }
    }
}
