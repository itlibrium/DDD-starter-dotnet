using System;

namespace MyCompany.Crm.Sales.Clients
{
    public readonly struct ClientId : IEquatable<ClientId>
    {
        public Guid Value { get; }

        public static ClientId New() => new ClientId(Guid.NewGuid());
        public static ClientId For(Guid value) => new ClientId(value);
        private ClientId(Guid value) => Value = value;

        public bool Equals(ClientId other) => Value.Equals(other.Value);
        public override bool Equals(object obj) => obj is ClientId other && Equals(other);
        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => $"ClientId {Value.ToString()}";
    }
}