using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroSeries.Interfaces;

namespace CadastroSeries.Classes
{
    internal class SerieRepositorio : IRepositorio<Serie>
    {

        private List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaSerie.RemoveAt(id);
        }

        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count();
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}
