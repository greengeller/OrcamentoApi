﻿using OrcamentoApi.Domain.Entities;

namespace OrcamentoApi.Domain.Models
{
    public class Vendedor : BaseEntity
    {
        public Vendedor()
        {            
        }        
        public Vendedor(int id, string nome)
        {
            Id = id;
            Nome = nome;           
        }
        public string Nome { get; set; }
        public override string ToString()
        {
            return " Id " + Id + " Nome " + Nome;
        }
    }
}
