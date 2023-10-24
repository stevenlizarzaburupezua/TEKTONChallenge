using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekTon.ProductAPI.Domain.Seedwork;
using Microsoft.Extensions.Configuration;

namespace TekTon.ProductAPI.Repository.Seedwork.StoreProcedure
{
    public class SqlServerProcedureManager : BaseProcedureManager, IStoreProcedureManager
    {
        private readonly IConfiguration _configuration;
        public SqlServerProcedureManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string MakeSQLServerParameter(string name) => $"@{name}";
        private string MakeOracleParameterWithValue(KeyValuePair<string, object> parameter) => $" {MakeSQLServerParameter(parameter.Key)} => {FormatValue(parameter.Value)}";

        public override string MakeProcedureCallWithValues(string name, Dictionary<string, object> parameters = null)
        {
            return $"BEGIN {name}({MakeParameterListWithValues(parameters, MakeOracleParameterWithValue)});COMMIT;END;";
        }

        public override string ParameterNameFormat(string name)
        {
            return MakeSQLServerParameter(name);
        }

        public override DbConnection GetDbConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
