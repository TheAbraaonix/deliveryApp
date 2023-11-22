using DeliveryApp.Models;

namespace DeliveryApp.Repositorio.Cardapio
{
    public interface ICardapioRepositorio
    {
        CardapioModel ListarPorId(int id);

        List<CardapioModel> BuscarTodos();

        CardapioModel AdicionarItem(CardapioModel item);

        CardapioModel AtualizarItem(CardapioModel item);

        bool DeletarItem(int id);
    }
}
