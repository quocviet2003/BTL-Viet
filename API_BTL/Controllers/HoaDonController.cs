using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer;
using DataModel;
using BusinessLogicLayer.Interfaces;

namespace API_BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private IHoaDonBusiness _hoadonBusiness;
        public HoaDonController(IHoaDonBusiness hoadonBusiness)
        {
            _hoadonBusiness = hoadonBusiness;
        }

        [Route("get_all")]
        [HttpGet]
        public List<HoaDonModel> GetAll()
        {
            return _hoadonBusiness.GetAll();
        }
    }
}
