using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserciziADO
{
    public enum TipoLavoratore
    {
        Autonomo,
        Dipendente
    }
    public class Lavoratore : Persona
    {
        #region Properties
        public double Retribuzione { get; set; }
        public double RAL
        {
            get
            {
                return Retribuzione * GetMensilità();
            }
        }
        public DateTime? DataDiAssunzione { get; set; }
        public TipoLavoratore Tipo { get; set; }
        #endregion

        #region Costruttori
        public Lavoratore()
        {

        }
        public Lavoratore(string nome, string cognome, DateTime dataDiNascita, double retribuzione, DateTime? dataAssunzione, TipoLavoratore tipo, Guid persona_id)
            : base(nome, cognome, dataDiNascita)
        {
            Retribuzione = retribuzione;
            DataDiAssunzione = dataAssunzione;
            Tipo = tipo;
            Persona_ID = persona_id;
        }
        #endregion

        #region Metodi
        public int GetMensilità()
        {
            return Tipo == TipoLavoratore.Autonomo ? 12 : 13;
        }
        #endregion
    }
}
