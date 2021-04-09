namespace ValidationByOverride
{
    public class StubHash : Hash
    {
        public override string GetHashResult(string password)
        {
            return "91";
        }
    }
}