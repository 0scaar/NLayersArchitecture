using NLayerArchitecture.BLL.Repository;
using NLayerArchitecture.DTO;
using System.Data.SqlClient;

namespace NLayerArchitecture.BLL.GetSalesByName
{
    public class Sales : ISales
    {
        private readonly ICallProcedure<Sale> _callProcedure;

        public Sales(ICallProcedure<Sale> callProcedure)
        {
            _callProcedure = callProcedure;
        }

        public List<Sale> GetSalesByName(string name)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@name", name)
            };

            return _callProcedure.GetListObject("GetSalesByName", parameters);
        }
    }
}