using DataAccessLayer.Abstract;
using EntityLayer.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodsTnved.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        public readonly IGoodRepository _abstractDapperRepository;
        public GoodsController(IGoodRepository abstractDapperRepository)

        {
            _abstractDapperRepository = abstractDapperRepository;
          
        }
        [HttpGet]
        public async Task<IActionResult> Get(string code)
        {
            if(code == null || code.Length!=10)
            {
                return BadRequest("Code  can not be null and length must be 10");
            }
            var goods =await _abstractDapperRepository.GetByCode(code);

            return Ok(goods);


            
        }
    }
}
