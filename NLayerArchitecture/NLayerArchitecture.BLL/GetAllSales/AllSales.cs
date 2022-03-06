using NLayerArchitecture.BLL.Repository;
using NLayerArchitecture.DTO;
using System.Data.SqlClient;

namespace NLayerArchitecture.BLL.GetAllSales
{
    public class AllSales : IAllSales
    {
        private readonly ICallProcedure<Sale> _callProcedure;

        public AllSales(ICallProcedure<Sale> callProcedure)
        {
            _callProcedure = callProcedure;
        }

        public List<Sale> GetAllSales()
        {
            var output = "@jsonOutput";

            SqlParameter[] parameters = {
                new SqlParameter(output, System.Data.SqlDbType.NVarChar, -1)
            };

            parameters[0].Direction = System.Data.ParameterDirection.Output;

            return _callProcedure.GetListObjectByJson("GetAllSales", parameters, output);
        }
    }
}
