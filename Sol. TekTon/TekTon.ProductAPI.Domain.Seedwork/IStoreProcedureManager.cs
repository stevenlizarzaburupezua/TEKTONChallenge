using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekTon.ProductAPI.Domain.Seedwork.Data;

namespace TekTon.ProductAPI.Domain.Seedwork
{
    public interface IStoreProcedureManager
    {
        void Exec(string name, Dictionary<string, object> parameters);

        string ExecScalar(string name, Dictionary<string, object> parameters);

        string ExecScalarOutPut(string name, Dictionary<string, object> parameters, Dictionary<string, object> outputParameters);

        Task ExecAsync(string name, Dictionary<string, object> parameters);

        List<T> Exec<T>(string name, Dictionary<string, object> parameters) where T : RawDTO;
        List<T> ExecFnc<T>(string name, Dictionary<string, object> parameters) where T : RawDTO;

        Task<List<T>> ExecAsync<T>(string name, Dictionary<string, object> parameters) where T : RawDTO;

        List<Dictionary<string, object>> ExecDynamic(string name, Dictionary<string, object> parameters);
    }
}
