using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace MyCompany.Crm.TechnicalStuff.Api.Versioning
{
    internal class EndpointVersioningProcessor : IOperationProcessor
    {
        private readonly string _versionParameterName;

        public EndpointVersioningProcessor(string versionParameterName) => _versionParameterName = versionParameterName;

        public bool Process(OperationProcessorContext context)
        {
            if (OperationIsForSingleVersion(context, out var version))
            {
                SetApiVersionInPath(context, version);
                RemoveApiVersionParameter(context);
                return true;
            }
            return true;
        }

        private static bool OperationIsForSingleVersion(OperationProcessorContext context, out string version)
        {
            var mapToApiVersionAttributes = context.MethodInfo
                .GetCustomAttributes<MapToApiVersionAttribute>()
                .ToArray();
            if (mapToApiVersionAttributes.Length == 1)
            {
                version = mapToApiVersionAttributes[0].Versions[0].ToString();
                return true;
            }
            if (mapToApiVersionAttributes.Length == 0)
            {
                var apiVersionAttributes = context.ControllerType
                    .GetCustomAttributes<ApiVersionAttribute>()
                    .ToArray();
                if (apiVersionAttributes.Length == 1)
                {
                    version = apiVersionAttributes[0].Versions[0].ToString();
                    return true;
                }
                if (apiVersionAttributes.Length == 0)
                {
                    version = null;
                    return false;
                }
            }
            throw new DesignError($"Operation {context.OperationDescription.Path} is mapped to more than one version");
        }

        private void SetApiVersionInPath(OperationProcessorContext context, string version) =>
            context.OperationDescription.Path =
                $"{context.OperationDescription.Path}?{_versionParameterName}={version}";

        private void RemoveApiVersionParameter(OperationProcessorContext context)
        {
            var parameters = context.OperationDescription.Operation.Parameters;
            var apiVersionParameter = parameters.FirstOrDefault(
                p => p.Name.Equals(_versionParameterName, StringComparison.OrdinalIgnoreCase));
            if (apiVersionParameter != null)
                parameters.Remove(apiVersionParameter);
        }
    }
}