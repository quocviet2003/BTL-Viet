using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataModel;

namespace BusinessLogicLayer
{
    public class HoaDonBu:IHoaDonBusiness
    {
        private IHoaDonData _res;
        public HoaDonBu(IHoaDonData res)
        {
            _res = res;
        }

        public List<HoaDonModel> GetAll()
        {
            return _res.GetAll();
        }
    }
}
