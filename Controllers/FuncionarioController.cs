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
        public async Task<ActionResult<List<ServiceResponse<FuncionarioModel>>>> GetFuncionarios()
        {
            var funcionarios = await _funcionarioInterface.GetFuncionarios();
            return Ok(funcionarios);
        }

        [HttpPost("CriarFuncionario")]
        public async Task<ActionResult<List<ServiceResponse<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            var funcionarios = await _funcionarioInterface.CreateFuncionario(novoFuncionario);
            return Ok(funcionarios);
        }

        [HttpGet("GetFuncionarioById/{idFuncionario}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById(int idFuncionario)
        {
            var funcionario = await _funcionarioInterface.GetFuncionarioById(idFuncionario);
            return Ok(funcionario);
        }

        [HttpDelete("DeleteFuncionario/{id}")]
        public async Task<ActionResult<List<ServiceResponse<FuncionarioModel>>>> DeleteFuncionario(int id)
        {
            var funcionario = await _funcionarioInterface.DeleteFuncionario(id);
            return Ok(funcionario);
        }

        [HttpPut("InativaFuncionario/{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> InativaFuncionario(int id)
        {
            var funcionario = await _funcionarioInterface.InativaFuncionario(id);
            return Ok(funcionario);
        }
    }
}
