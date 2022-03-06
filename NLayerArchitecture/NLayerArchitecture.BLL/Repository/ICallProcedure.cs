using System.Data.SqlClient;

namespace NLayerArchitecture.BLL.Repository
{
    public interface ICallProcedure<T>
    {
        List<T> GetListObject(string sp, SqlParameter[] parameters);
        List<T> GetListObjectByJson(string sp, SqlParameter[] parameters, string output);
    }
}
