namespace UnitTesting
{
    public class StubAccountDao : IAccountDao
    {
        public string GetPassword(string id)
        {
            return "91";
        }
    }
}
