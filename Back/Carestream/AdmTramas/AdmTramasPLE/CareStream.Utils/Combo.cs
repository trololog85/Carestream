using System;
using System.Collections.Generic;
using System.Text;

namespace CareStream.Utils
{
    public class Combo
    {
        public Char Cod { get; set; }
        public String Nombre { get; set; }
        public String sCod { get; set; }

        public static List<Combo> ListaFormatos()
        {
            List<Combo> lst = new List<Combo>();

            Combo cmb = new Combo();
            cmb.Cod = 'N';
            cmb.Nombre = "Numérico";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.Cod = 'A';
            cmb.Nombre = "Alfanumerico";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.Cod = 'F';
            cmb.Nombre = "Fecha";

            lst.Add(cmb);

            return lst;
        }

        public static List<Combo> ListaTipoProceso()
        {
            List<Combo> lst = new List<Combo>();

            Combo cmb = new Combo();
            cmb.Cod = 'I';
            cmb.Nombre = "Import";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.Cod = 'E';
            cmb.Nombre = "Export";

            lst.Add(cmb);

            return lst;
        }

        public static List<Combo> ListaIndicadorOperaciones()
        {
            List<Combo> lst = new List<Combo>();

            Combo cmb = new Combo();
            cmb.Cod = '1';
            cmb.Nombre = "Empresa";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.Cod = '2';
            cmb.Nombre = "Cierre del Libro";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.Cod = '0';
            cmb.Nombre = "Cierre de Operaciones";

            lst.Add(cmb);

            return lst;
        }

        public static List<Combo> ListaIndicadordeMoneda()
        {
            List<Combo> lst = new List<Combo>();

            Combo cmb = new Combo();
            cmb.sCod = "PEN";
            cmb.Nombre = "Nuevos Soles";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.sCod = "USD";
            cmb.Nombre = "US Dólares";

            lst.Add(cmb);

            return lst;
        }

        public static List<Combo> ListaIndicadorLibroRegistro()
        {
            List<Combo> lst = new List<Combo>();

            Combo cmb = new Combo();
            cmb.Cod = '1';
            cmb.Nombre = "Con información";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.Cod = '0';
            cmb.Nombre = "Sin información";

            lst.Add(cmb);

            return lst;
        }

        public static List<Combo> ListaMeses()
        {
            List<Combo> lst = new List<Combo>();

            Combo cmb = new Combo();
            cmb.sCod = "1";
            cmb.Nombre = "Enero";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.sCod = "2";
            cmb.Nombre = "Febrero";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.sCod = "3";
            cmb.Nombre = "Marzo";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.sCod = "4";
            cmb.Nombre = "Abril";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.sCod = "5";
            cmb.Nombre = "Mayo";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.sCod = "6";
            cmb.Nombre = "Junio";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.sCod = "7";
            cmb.Nombre = "Julio";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.sCod = "8";
            cmb.Nombre = "Agosto";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.sCod = "9";
            cmb.Nombre = "Septiembre";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.sCod = "10";
            cmb.Nombre = "Octubre";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.sCod = "11";
            cmb.Nombre = "Noviembre";

            lst.Add(cmb);

            cmb = new Combo();
            cmb.sCod = "12";
            cmb.Nombre = "Diciembre";

            lst.Add(cmb);

            return lst;
        }
    }
}
