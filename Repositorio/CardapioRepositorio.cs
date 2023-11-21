using DeliveryApp.Data;
using DeliveryApp.Models;

namespace DeliveryApp.Repositorio
{
    public class CardapioRepositorio : ICardapioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public CardapioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public CardapioModel AdicionarItem(CardapioModel item)
        {
            _bancoContext.Cardapio.Add(item);
            _bancoContext.SaveChanges();
            return item;
        }
    }
}