using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserciziADO
{
    public class Persona
    {
        public Guid Persona_ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataDiNascita { get; set; }

        public Persona()
        {
            Persona_ID = Guid.NewGuid();
        }
        public Persona(string nome, string cognome, DateTime dataDiNascita)
        {
            Nome = nome;
            Cognome = cognome;
            DataDiNascita = dataDiNascita;
            Persona_ID = Guid.NewGuid();
        }

        public override string ToString()
        {
            return string.Format("Nome: {0}, Cognome: {1}, Data di nascita: {2:d}", Nome, Cognome, DataDiNascita);
        }
    }
}
