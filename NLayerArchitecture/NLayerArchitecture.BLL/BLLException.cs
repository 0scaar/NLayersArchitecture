namespace NLayerArchitecture.BLL
{
    public class BLLException : Exception
    {
        internal BLLException(string businessMessage)
            : base(businessMessage)
        { }
    }
}
