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

        public CardapioModel ListarPorId(int id)
        {
            return _bancoContext.Cardapio.FirstOrDefault(x => x.Id == id);
        }

        public List<CardapioModel> BuscarTodos()
        {
            return _bancoContext.Cardapio.ToList();
        }

        public CardapioModel AdicionarItem(CardapioModel item)
        {
            _bancoContext.Cardapio.Add(item);
            _bancoContext.SaveChanges();
            return item;
        }

        public CardapioModel AtualizarItem(CardapioModel item)
        {
            CardapioModel itemDb = ListarPorId(item.Id);

            if(itemDb ==  null)
            {
                throw new Exception("Houve um erro na atualização do item do cardápio.");
            }

            itemDb.Nome = item.Nome;
            itemDb.Categoria = item.Categoria;
            itemDb.Preco = item.Preco;

            _bancoContext.Cardapio.Update(itemDb);
            _bancoContext.SaveChanges();
            return itemDb;
        }

        public bool DeletarItem(int id)
        {
            CardapioModel itemDb = ListarPorId(id);

            if (itemDb == null)
            {
                throw new Exception("Houve um erro na deleção do item do cardápio.");
            }


            _bancoContext.Cardapio.Remove(itemDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}