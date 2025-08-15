using GerenciamentoLivro.Domain.Notifications;

namespace GerenciamentoLivro.Domain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handler(Notificacao notificacao);
    }
}
