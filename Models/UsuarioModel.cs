﻿using DeliveryApp.Enums;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace DeliveryApp.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuário.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Selecione o tipo de usuário.")]
        public PerfilEnum Perfil {  get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário.")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
