using System.Collections.Generic;
using MigraPle.Api.Windows.Utils.Entities;

namespace MigraPle.Api.Windows.Utils.Interfaces
{
    public interface IMetaInfoProvider
    {
        IEnumerable<Combo> GetMetaData(string sourceFile);
    }
}