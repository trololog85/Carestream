using System;
using System.Collections.Generic;

namespace Carestream.AdmTramas.Utils
{
    public class Combo
    {
        public Char Cod { get; private set; }
        public String Nombre { get; private set; }
        public String sCod { get; private set; }

        public static List<Combo> ListaFormatos()
        {
            var lst = new List<Combo>();

            var cmb = new Combo {Cod = 'N', Nombre = "Numérico"};

            lst.Add(cmb);

            cmb = new Combo {Cod = 'A', Nombre = "Alfanumerico"};

            lst.Add(cmb);

            cmb = new Combo {Cod = 'F', Nombre = "Fecha"};

            lst.Add(cmb);

            return lst;
        }

        public static List<Combo> ListaTipoProceso()
        {
            var lst = new List<Combo>();

            var cmb = new Combo {Cod = 'I', Nombre = "Import"};

            lst.Add(cmb);

            cmb = new Combo {Cod = 'E', Nombre = "Export"};

            lst.Add(cmb);

            return lst;
        }

        public static List<Combo> ListaIndicadorOperaciones()
        {
            var lst = new List<Combo>();

            var cmb = new Combo {Cod = '1', Nombre = "Empresa"};

            lst.Add(cmb);

            cmb = new Combo {Cod = '2', Nombre = "Cierre del Libro"};

            lst.Add(cmb);

            cmb = new Combo {Cod = '0', Nombre = "Cierre de Operaciones"};

            lst.Add(cmb);

            return lst;
        }

        public static List<Combo> ListaIndicadordeMoneda()
        {
            var lst = new List<Combo>();

            var cmb = new Combo {sCod = "PEN", Nombre = "Nuevos Soles"};

            lst.Add(cmb);

            cmb = new Combo {sCod = "USD", Nombre = "US Dólares"};

            lst.Add(cmb);

            return lst;
        }

        public static List<Combo> ListaIndicadorLibroRegistro()
        {
            var lst = new List<Combo>();

            var cmb = new Combo {Cod = '1', Nombre = "Con información"};

            lst.Add(cmb);

            cmb = new Combo {Cod = '0', Nombre = "Sin información"};

            lst.Add(cmb);

            return lst;
        }

        public static List<Combo> ListaMeses()
        {
            var lst = new List<Combo>();

            var cmb = new Combo {sCod = "1", Nombre = "Enero"};

            lst.Add(cmb);

            cmb = new Combo {sCod = "2", Nombre = "Febrero"};

            lst.Add(cmb);

            cmb = new Combo {sCod = "3", Nombre = "Marzo"};

            lst.Add(cmb);

            cmb = new Combo {sCod = "4", Nombre = "Abril"};

            lst.Add(cmb);

            cmb = new Combo {sCod = "5", Nombre = "Mayo"};

            lst.Add(cmb);

            cmb = new Combo {sCod = "6", Nombre = "Junio"};

            lst.Add(cmb);

            cmb = new Combo {sCod = "7", Nombre = "Julio"};

            lst.Add(cmb);

            cmb = new Combo {sCod = "8", Nombre = "Agosto"};

            lst.Add(cmb);

            cmb = new Combo {sCod = "9", Nombre = "Septiembre"};

            lst.Add(cmb);

            cmb = new Combo {sCod = "10", Nombre = "Octubre"};

            lst.Add(cmb);

            cmb = new Combo {sCod = "11", Nombre = "Noviembre"};

            lst.Add(cmb);

            cmb = new Combo {sCod = "12", Nombre = "Diciembre"};

            lst.Add(cmb);

            return lst;
        }

        public static List<Combo> VersionPLE()
        {
            var lst = new List<Combo>();

            var cmb = new Combo {sCod = "3.0",Nombre = "3.0"};

            lst.Add(cmb);

            cmb = new Combo { sCod = "3.1", Nombre = "3.1" };

            lst.Add(cmb);

            cmb = new Combo { sCod = "4.0", Nombre = "4.0" };

            lst.Add(cmb);

            return lst;
        }
    }
}
