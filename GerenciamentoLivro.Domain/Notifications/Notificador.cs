using GerenciamentoLivro.Domain.Interfaces;

namespace GerenciamentoLivro.Domain.Notifications
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }

        public void Handler(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }
    }
}
