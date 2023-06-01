using System.Data;
using JetBrains.Annotations;
using Marten;
using Marten.Services;

namespace MyCompany.ECommerce.TechnicalStuff.Marten
{
    [UsedImplicitly]
    public class LightweightSessionFactory : ISessionFactory
    {
        private readonly IDocumentStore _store;

        public LightweightSessionFactory(IDocumentStore store) => _store = store;

        public IQuerySession QuerySession() => _store.QuerySession();

        public IDocumentSession OpenSession() => _store.OpenSession(new SessionOptions
        {
            Tracking = DocumentTracking.None,
            IsolationLevel = IsolationLevel.ReadCommitted
        });
    }
}