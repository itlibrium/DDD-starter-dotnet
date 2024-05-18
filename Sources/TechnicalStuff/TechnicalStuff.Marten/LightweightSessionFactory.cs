using System.Data;
using JetBrains.Annotations;
using Marten;
using Marten.Services;

namespace MyCompany.ECommerce.TechnicalStuff.Marten;

[UsedImplicitly]
public class LightweightSessionFactory(IDocumentStore store) : ISessionFactory
{
    public IQuerySession QuerySession() => store.QuerySession();

    public IDocumentSession OpenSession() => store.OpenSession(new SessionOptions
    {
        Tracking = DocumentTracking.None,
        IsolationLevel = IsolationLevel.ReadCommitted
    });
}