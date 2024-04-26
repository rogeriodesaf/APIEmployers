using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFuncionarios.Model;
using WebApiFuncionarios.Service;

namespace WebApiFuncionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        readonly private IFuncionarioInterface _funcionarioInterface;
            public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
               _funcionarioInterface = funcionarioInterface;    
        }

        [HttpGet("GetFuncionarios")]
        public async Task<ActionResult<List<ServiceResponse<FuncionarioModel>>>>GetFuncionarios()
        {
            var funcionarios = await _funcionarioInterface.GetFuncionarios();
            return Ok(funcionarios);
        }
    }
}
