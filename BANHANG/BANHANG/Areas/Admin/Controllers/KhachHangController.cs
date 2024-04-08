using BANHANG.Models.DAO;
using GUIs.Support;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BANHANG.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly Lazy<KhachHangDAO> _khachHangDAO;
        public KhachHangController(Lazy<KhachHangDAO> khachHangDAO)
        {
            _khachHangDAO = khachHangDAO;
        }
        [HttpGet]
        public async Task<IActionResult> ShowList(String name,int index,int size)
        {
            KhachHangDAO khachHangDAO = _khachHangDAO.Value;
            int total = 0;
            var query=khachHangDAO.Search(out total, name, index, size);
            string pages = Support.InTrang(total, index, size);
            var result = new
            {
                data = query,
                page = pages
            };
            return Ok(result);
        }
        

    }
}
