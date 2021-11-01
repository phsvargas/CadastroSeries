using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroSeries.Enum;

namespace CadastroSeries.Classes
{
    public class Serie : EntidadeBase
    {
        public Genero Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }

        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public int RetornaId()
        {
            return Id;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public override string ToString()
        {
            string retorna = "";
            retorna += "Gênero: " + this.Genero + Environment.NewLine;
            retorna += "Titulo: " + this.Titulo + Environment.NewLine;
            retorna += "Descrição: " + this.Descricao + Environment.NewLine;
            retorna += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorna += "Excluido: " + this.Excluido;
            return retorna;
        }
    }
}
