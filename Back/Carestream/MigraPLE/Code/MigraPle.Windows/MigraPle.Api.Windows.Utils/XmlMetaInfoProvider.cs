using System.Collections.Generic;
using System.IO;
using System.Xml;
using MigraPle.Api.Windows.Utils.Entities;
using MigraPle.Api.Windows.Utils.Interfaces;

namespace MigraPle.Api.Windows.Utils
{
    public class XmlMetaInfoProvider : IMetaInfoProvider
    {
        public IEnumerable<Combo> GetMetaData(string sourceFile)
        {
            var lstOpciones = new List<Combo>();

            var path = Path.Combine(Common.GetCurrentPath(@"\Resources\MetaFiles\"), sourceFile);

            var document = new XmlDocument();
            document.Load(path);

            var mainNodes = document.DocumentElement;

            Combo element;

            foreach (XmlNode node in mainNodes.ChildNodes)
            {
                element = new Combo
                {
                    sCod = node.ChildNodes[0].InnerText,
                    Nombre = node.ChildNodes[1].InnerText
                };

                lstOpciones.Add(element);
            }

            return lstOpciones;
        }
    }
}