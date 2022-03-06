using NLayerArchitecture.DTO;

namespace NLayerArchitecture.BLL.GetSalesByName
{
    public interface ISales
    {
        List<Sale> GetSalesByName(string name);
    }
}
