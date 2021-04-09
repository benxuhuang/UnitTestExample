namespace ValidationByOverride
{
    public class MyValidation : Validation
    {
        protected override AccountDao GetAccountDao()
        {
            return new StubAccountDao();
        }

        protected override Hash GetHash()
        {
            return new StubHash();
        }
    }
}
