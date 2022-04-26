using System.Collections.Generic;
using _Project.DataServices;

namespace Project.UI
{
    public class MotherBoardSlider : HardwareSlider
    {
        public override IEnumerable<Hardware> GetData()
        {            
            var service = DataService.Instance.GetService<HardwareDataService>();
            return service.GetMotherBoards();
        }
    }
}