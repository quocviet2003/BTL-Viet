using DataModel;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
namespace API_BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachController : ControllerBase
    {
        private IKhachBusiness _khachBusiness;
        public KhachController(IKhachBusiness khachBusiness)
        {
            _khachBusiness = khachBusiness;
        }

        [Route("get_all")]
        [HttpGet]
        public List<KhachModel> GetAll()
        {
            return _khachBusiness.GetAll();
        }


        [Route("get_by_id")]
        [HttpGet]
        public KhachModel GetDatabyID(string id)
        {
            return _khachBusiness.GetDatabyID(id);
        }


        [Route("Create")]
        [HttpPost]
        public KhachModel CreateItem([FromBody] KhachModel model) 
        {
            _khachBusiness.Create(model);
            return model;
        
        }

        [Route("Update")]
        [HttpPost]
        public KhachModel UpdateItem([FromBody] KhachModel model)
        {
            _khachBusiness.Update(model);
            return model;
        }

        [Route("Delete")]
        [HttpPost]
        public IActionResult DeleteItem(string id)
        {
            bool result = _khachBusiness.Delete(id);
            if (result)
            {
                return Ok("Xóa thành công");
            }
            else
            {
                return BadRequest("Không tìm thấy khách hàng hoặc xóa không thành công");
            }
        }



        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten_khach = "";
                if (formData.Keys.Contains("ten_khach") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_khach"]))) { ten_khach = Convert.ToString(formData["ten_khach"]); }
                string dia_chi = "";
                if (formData.Keys.Contains("dia_chi") && !string.IsNullOrEmpty(Convert.ToString(formData["dia_chi"]))) { dia_chi = Convert.ToString(formData["dia_chi"]); }
                long total = 0;
                var data = _khachBusiness.Search(page, pageSize, out total, ten_khach, dia_chi);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
