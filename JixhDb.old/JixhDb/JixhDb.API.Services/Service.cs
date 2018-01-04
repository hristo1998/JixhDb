namespace JixhDb.API.Services
{
    using JixhDb.Data.Contracts;
    using JixhDb.Data;
    public abstract class Service
    {
        protected Service()
        {
            this.Context = new UnitOfWork();
        }

        protected IUnitOfWork Context { get; }
    }
}
