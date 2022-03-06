using Newtonsoft.Json;
using NLayerArchitecture.BLL.Repository;
using System.Data;
using System.Data.SqlClient;

namespace NLayerArchitecture.DAL.Repositories
{
    public class CallProcedure<T> : ICallProcedure<T>
    {
        public List<T> GetListObject(string sp, SqlParameter[] parameters)
        {
            var dt = new DataTable();

            using (SqlConnection oConexion = new SqlConnection(Connection.stringConnection))
            {
                SqlCommand cmd = new SqlCommand(sp, oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);

                oConexion.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dt.Load(dr);
                        var dataSerialized = JsonConvert.SerializeObject(dt, Formatting.Indented);

                        if (!string.IsNullOrEmpty(dataSerialized))
                            return JsonConvert.DeserializeObject<List<T>>(dataSerialized);
                    }
                }
            }

            return new List<T>();
        }

        public List<T> GetListObjectByJson(string sp, SqlParameter[] parameters, string output)
        {
            using (SqlConnection oConexion = new SqlConnection(Connection.stringConnection))
            {
                oConexion.Open();

                using (SqlCommand cmd = new SqlCommand(sp, oConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);

                    cmd.ExecuteNonQuery();

                    var dataSerialized = cmd.Parameters[output].Value.ToString();
                    if (!string.IsNullOrEmpty(dataSerialized))
                        return JsonConvert.DeserializeObject<List<T>>(dataSerialized);
                }
            }

            return new List<T>();
        }
    }
}
