﻿namespace ApiWebTrx.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string QuantidadeEstoque { get; set; } = string.Empty;
        public string CodigoDeBarras { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
    }
}
