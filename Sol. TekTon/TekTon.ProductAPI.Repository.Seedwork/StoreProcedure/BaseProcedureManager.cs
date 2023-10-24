 
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekTon.ProductAPI.Domain.Seedwork.Data;
using TekTon.ProductAPI.Infrastructure.CrossCutting;

namespace TekTon.ProductAPI.Repository.Seedwork.StoreProcedure
{
    public abstract class BaseProcedureManager
    {
        protected string FormatValue(object value)
        {
            if (value == null) return "null";
            if (value is string) return $"'{value}'";
            if (value.ToString().IsNumeric()) return value.ToString();
            if (value is bool) return (bool)value ? "1" : "0";
            if (value is DateTime) return $"'{((DateTime)value).ToString("yyyy-MM-dd")}'";
            return $"'{value}'";
        }

        protected string MakeParameterList(IEnumerable<string> parameters, Func<string, string> transform)
        {
            if (parameters == null) return "";
            if (parameters.Count() == 0) return "";
            return string.Join(',', parameters.Select(f => transform(f)).ToList());
        }

        protected string MakeParameterListWithValues(Dictionary<string, object> parameters, Func<KeyValuePair<string, object>, string> transform)
        {
            if (parameters == null) return "";
            if (parameters.Count == 0) return "";
            return string.Join(',', parameters.Select(f => transform(f)).ToList());
        }
        protected SqlParameter MakeParameter(DbCommand command, string name, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            var par = new SqlParameter();
            par.ParameterName = ParameterNameFormat(name);
            par.Value = value;
            par.Direction = direction;
            return par;
        }

        protected SqlParameter MakeOutPutParameter(DbCommand command, string name, object value, ParameterDirection direction = ParameterDirection.Output)
        {
            var par = new SqlParameter();
            par.ParameterName = ParameterNameFormat(name);
            par.Value = value;
            par.Direction = direction;
            return par;
        }

        private SqlParameter[] MakeProcedureParameters(DbCommand command, Dictionary<string, object> parameters)
        {
            return parameters.Select(f => MakeParameter(command, f.Key, f.Value)).ToArray();
        }

        private SqlParameter[] MakeProcedureOutPutParameters(DbCommand command, Dictionary<string, object> parameters)
        {
            return parameters.Select(f => MakeOutPutParameter(command, f.Key, f.Value)).ToArray();
        }

        public void Procedure(string name, Dictionary<string, object> parameters = null)
        {
            using (var connection = GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = MakeProcedureCallWithValues(name, parameters);
                    command.Prepare();
                    command.CommandTimeout = 120;
                    command.ExecuteNonQuery();
                }
            }

            //_context.Database.ExecuteSqlCommand(MakeProcedureCallWithValues(name, parameters));
        }

        public List<T> Procedure<T>(string name, Dictionary<string, object> parameters) where T : RawDTO
        {
            DbDataReader reader;
            var result = new List<T>();
            using (var connection = GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = name;
                    command.Parameters.AddRange(MakeProcedureParameters(command, parameters ?? new Dictionary<string, object> { }));
                    command.Prepare();
                    command.CommandTimeout = 120;
                    reader = command.ExecuteReader();
                    if (!reader.HasRows) return result;
                    while (reader.Read())
                    {
                        var row = new List<RawDTOField>();
                        int i = 0;
                        while (i < reader.FieldCount)
                        {
                            var newField = new RawDTOField(reader.GetName(i), reader.GetValue(i));
                            row.Add(newField);
                            i++;
                        }
                        result.Add(RawDTO.FromRawData<T>(row));
                    }
                }
            }
            return result;
        }

        public List<T> ProcedureFnc<T>(string name, Dictionary<string, object> parameters) where T : RawDTO
        {
            DbDataReader reader;
            var result = new List<T>();
            using (var connection = GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    var cad = "select * from " + name + "(";
                    int j = 0;
                    foreach (var item in parameters)
                    {
                        if (j > 0) { cad = String.Concat(cad, ",'" + item.Value + "'"); } else { cad = String.Concat(cad, "'" + item.Value.ToString() + "'"); }; j++;


                    }
                    cad = String.Concat(cad, " ) ");
                    command.CommandText = cad;
                    //command.CommandType = CommandType.StoredProcedure;
                    //command.CommandText = name;// MakeProcedureCall(name, parameters.Select(f => f.Key).ToList());
                    //command.Parameters.AddRange(MakeProcedureParameters(command, parameters));
                    command.Prepare();
                    command.CommandTimeout = 120;
                    reader = command.ExecuteReader();
                    if (!reader.HasRows) return result;
                    while (reader.Read())
                    {
                        var row = new List<RawDTOField>();//[reader.FieldCount];
                        int i = 0;
                        while (i < reader.FieldCount)
                        {
                            var newField = new RawDTOField(reader.GetName(i), reader.GetValue(i));
                            row.Add(newField);
                            i++;
                        }
                        result.Add(RawDTO.FromRawData<T>(row));
                    }
                }
            }
            return result;
        }

        private object ProcedureScalar(string name, Dictionary<string, object> parameters)
        {
            using (var connection = GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = name;
                    command.Parameters.AddRange(MakeProcedureParameters(command, parameters));
                    command.Prepare();
                    command.CommandTimeout = 120;
                    return command.ExecuteScalar();
                }
            }
        }

        private object ProcedureScalarOutPut(string name, Dictionary<string, object> parameters, Dictionary<string, object> outputParameters)
        {
            using (var connection = GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = name;
                    command.Parameters.AddRange(MakeProcedureParameters(command, parameters));
                    command.Parameters.AddRange(MakeProcedureOutPutParameters(command, outputParameters));
                    command.Prepare();
                    command.CommandTimeout = 120;
                    command.ExecuteScalar();
                    object outputValue = Convert.ToInt32(command.Parameters["@NRO_ACTA_NUEVO"].Value);
                    return outputValue;
                }
            }
        }

        public List<Dictionary<string, object>> DynamicProcedure(string name, Dictionary<string, object> parameters)
        {
            DbDataReader reader;
            var result = new List<Dictionary<string, object>>();
            using (var connection = GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = name;
                    command.Parameters.AddRange(MakeProcedureParameters(command, parameters));
                    command.Prepare();
                    command.CommandTimeout = 120;
                    reader = command.ExecuteReader();
                    if (!reader.HasRows) return result;
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();
                        int i = 0;
                        while (i < reader.FieldCount)
                        {
                            row.Add(reader.GetName(i), reader.GetValue(i));
                            i++;
                        }
                        result.Add(row);
                    }
                }
            }

            return result;
        }


        #region PROCEDURES

        public void Exec(string name, Dictionary<string, object> parameters)
        {
            Procedure(name, parameters);
        }

        public string ExecScalar(string name, Dictionary<string, object> parameters)
        {
            return ProcedureScalar(name, parameters).ToString();
        }

        public string ExecScalarOutPut(string name, Dictionary<string, object> parameters, Dictionary<string, object> outputParameters)
        {
            return ProcedureScalarOutPut(name, parameters, outputParameters).ToString();
        }

        public async Task ExecAsync(string name, Dictionary<string, object> parameters)
        {
            await Task.Factory.StartNew(() => Exec(name, parameters));
        }

        public List<T> Exec<T>(string name, Dictionary<string, object> parameters) where T : RawDTO
        {
            return Procedure<T>(name, parameters);
        }

        public List<T> ExecFnc<T>(string name, Dictionary<string, object> parameters) where T : RawDTO
        {
            return ProcedureFnc<T>(name, parameters);
        }

        public async Task<List<T>> ExecAsync<T>(string name, Dictionary<string, object> parameters) where T : RawDTO
        {
            return await Task.Factory.StartNew(() => Exec<T>(name, parameters));
        }

        public List<Dictionary<string, object>> ExecDynamic(string name, Dictionary<string, object> parameters)
        {
            return DynamicProcedure(name, parameters);
        }

        #endregion

        public abstract string MakeProcedureCallWithValues(string name, Dictionary<string, object> parameters = null);
        public abstract string ParameterNameFormat(string name);
        public abstract DbConnection GetDbConnection();



    }
}
