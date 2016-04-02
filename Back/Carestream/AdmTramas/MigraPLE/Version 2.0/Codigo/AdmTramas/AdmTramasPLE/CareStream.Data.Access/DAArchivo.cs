using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CareStream.Data.Access
{
    public class DAArchivo
    {
        public List<Archivo> Listar()
        {
            List<Archivo> lst = new List<Archivo>();
        
            using(BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                lst = ent.ListarArchivos().ToList<Archivo>();            
            }

            return lst;
        }

        public void Guardar(Archivo obj)
        {
            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                ent.AddToArchivoes(obj);

                ent.SaveChanges();
            }
        }

        public void Actualizar(Archivo obj)
        {
            BDTramaPLEEntities ent = new BDTramaPLEEntities();

            EntityKey key = ent.CreateEntityKey("Archivoes", obj);

            object ArchivoToModify;
        
            if(ent.TryGetObjectByKey(key,out ArchivoToModify))
            {
                ent.ApplyCurrentValues(key.EntitySetName,obj);
            }

            ent.SaveChanges();
        }

        public Int32 ObtieneArchivoxCod(String codigo)
        {
            Int32 id = 0;

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                id = Convert.ToInt32(ent.ArchivoGetIDxCod(codigo).ElementAt(0).Value);
            }

            return id;
        }

        public void Eliminar(Archivo obj)
        {
            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                object objArch;

                EntityKey key = ent.CreateEntityKey("Archivoes", obj);

                if (ent.TryGetObjectByKey(key, out objArch))
                {
                    ent.DeleteObject(objArch);

                    ent.SaveChanges();
                }
            }
        }
    }
}
