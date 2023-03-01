using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models;

namespace WEB_API_HealTime.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly DataContext _context;

        [HttpPost("AddEstoque")]
        public async Task<IActionResult> AddEstoque()
        {
            try
            {
                Estoque novoestoque = new NovoEstoque();
    


            }
            catch
            {

            }
        }

        /*[HttpPost]
        public async Task<IActionResult> AddMedEstoque()
        {

        }*/

    }
}
