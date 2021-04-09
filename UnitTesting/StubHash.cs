namespace UnitTesting
{
    public class StubHash : IHash
    {
        public string GetHashCode(string password)
        {
            return "91";
        }
    }
}
