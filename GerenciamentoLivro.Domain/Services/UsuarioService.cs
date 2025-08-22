using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;
using GerenciamentoLivro.Domain.Validations;

namespace GerenciamentoLivro.Domain.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(INotificador notificador, IUsuarioRepository usuarioRepository) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task Adicionar(Usuario usuario)
        {
            if (!ValidarEntidade(usuario, new UsuarioValidation()))
                return;

            await _usuarioRepository.AdicionarAsync(usuario);
        }
    }
}
