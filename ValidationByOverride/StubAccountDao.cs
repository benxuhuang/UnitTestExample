namespace ValidationByOverride
{
    public class StubAccountDao : AccountDao
    {
        public override string GetPassword(string id)
        {
            return "91";
        }
    }
}