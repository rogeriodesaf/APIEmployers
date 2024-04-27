using Microsoft.EntityFrameworkCore;
using WebApiFuncionarios.DataContext;
using WebApiFuncionarios.Model;

namespace WebApiFuncionarios.Service
{
    public class FuncionarioService : IFuncionarioInterface
    {
        readonly ApplicationDbContext _context;
        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> resposta = new ServiceResponse<List<FuncionarioModel>>();

            try
            {

                var funcionario = new FuncionarioModel();
                {
                    funcionario = novoFuncionario;
                }


                if (funcionario is null)
                {
                    resposta.Mensagem = "Não foi possivel criar um novo funcionário";
                    return resposta;
                }



                _context.Funcionarios.Add(funcionario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Funcionarios.ToListAsync();
                resposta.Mensagem = "Funcionário adicionado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Sucesso = false;
                return resposta;
            }

        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> resposta = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                var funcionario = await  _context.Funcionarios.FirstOrDefaultAsync(a => a.Id == id);
                if(funcionario is null)
                {
                    resposta.Mensagem = "Funcionário não localizado";
                    resposta.Sucesso = false;
                }

                _context.Remove(funcionario);
                await _context.SaveChangesAsync();

                resposta.Dados= await _context.Funcionarios.ToListAsync();
                resposta.Mensagem = "Funcionario removido com sucesso";
                resposta.Sucesso = true;
                return resposta;
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionarioModel>> resposta = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                var funcionarios = await _context.Funcionarios.ToListAsync();

                if (funcionarios.Count == 0)
                {
                    resposta.Mensagem = "Não há dados na lista";
                    return resposta;
                }

                resposta.Dados = await _context.Funcionarios.ToListAsync();
                resposta.Mensagem = "Dados retornados com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }

        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> resposta = new ServiceResponse<FuncionarioModel>();

            try
            {
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(funcionarioBanco => funcionarioBanco.Id == id);
                if(funcionario == null)
                {
                    resposta.Mensagem = "Funcionário não localizado";
                    resposta.Sucesso = false;
                }

                resposta.Dados = funcionario;
                resposta.Mensagem = "funcionario localizado!";
                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Sucesso= false;
                return resposta;
            }
        }


        public Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            throw new NotImplementedException();
        }
    }
}


