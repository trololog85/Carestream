using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CareStream.Data.Access
{
    public class DAEstructura
    {
        public List<Estructura> Listar()
        {
            List<Estructura> lst = new List<Estructura>();

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                lst = ent.ListarEstructura().ToList<Estructura>();
            }

            return lst;
        }

        public void Guardar(Estructura obj)
        {
            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                ent.AddToEstructuras(obj);

                ent.SaveChanges();
            }
        }

        public Int32 ObtieneMaximoID()
        {
            Int32 id = 0;

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                id = Convert.ToInt32(ent.Estructura_ObtieneMaximoID().ElementAt(0).id);
            }

            return id;
        }

        public void Eliminar(Estructura obj)
        {
            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                object objEstructura;

                EntityKey key = ent.CreateEntityKey("Estructuras", obj);

                if (ent.TryGetObjectByKey(key, out objEstructura))
                {
                    ent.DeleteObject(objEstructura);

                    ent.SaveChanges();
                }
            }
        }
    }
}
