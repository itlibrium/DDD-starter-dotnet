using System;
using System.Collections.Generic;

namespace MyCompany.ECommerce.TechnicalStuff.ProcessModel
{
    public class MessageTypes
    {
        private readonly Dictionary<string, Type> _id2Type = new();
        private readonly Dictionary<Type, string> _type2Id = new();

        public void Register<TMessage>(string typeId, IReadOnlyCollection<string> alternativeTypeIds)
            where TMessage : Message
        {
            if (_id2Type.ContainsKey(typeId))
                ThrowDuplicatedTypeId(typeId, typeof(TMessage));
            foreach (var alternativeTypeId in alternativeTypeIds)
            {
                if (_id2Type.ContainsKey(alternativeTypeId))
                    ThrowDuplicatedTypeId(alternativeTypeId, typeof(TMessage));
            }
            if (_type2Id.ContainsKey(typeof(TMessage)))
                throw new DesignError($"Duplicated type registration for {typeof(TMessage).Name}");
            
            _id2Type.Add(typeId, typeof(TMessage));
            foreach (var alternativeTypeId in alternativeTypeIds)
                _id2Type.Add(alternativeTypeId, typeof(TMessage));
            _type2Id.Add(typeof(TMessage), typeId);
        }

        private void ThrowDuplicatedTypeId(string typeId, Type typeToRegister)
        {
            var alreadyRegisteredType = _id2Type[typeId];
            throw new DesignError($"Duplicated type id for {typeToRegister.Name} and {alreadyRegisteredType.Name}");
        }

        public string GetTypeIdFor<TMessage>(TMessage message)
        {
            if (!_type2Id.TryGetValue(typeof(TMessage), out var typeId))
                throw new DesignError($"Missing type id for: {typeof(TMessage).Name}");
            return typeId;
        }

        public Type GetMessageTypeFor(string typeId)
        {
            if (!_id2Type.TryGetValue(typeId, out var type))
                throw new DesignError($"Missing type for type id: {typeId}");
            return type;
        }

        public Type GetHandlerTypeFor(string typeId)
        {
            if (!_id2Type.TryGetValue(typeId, out var type))
                throw new DesignError($"Missing handler type for type id: {typeId}");
            return type;
        }
    }
}