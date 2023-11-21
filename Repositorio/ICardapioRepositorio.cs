using DeliveryApp.Models;

namespace DeliveryApp.Repositorio
{
    public interface ICardapioRepositorio
    {
        List<CardapioModel> BuscarTodos();
        
        CardapioModel AdicionarItem(CardapioModel item);
    }
}
