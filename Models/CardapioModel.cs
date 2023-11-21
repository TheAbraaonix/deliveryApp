using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Models
{
    public class CardapioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do item.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite a categoria do item.")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "Digite o preço do item.")]
        public double Preco {  get; set; }
    }
}
