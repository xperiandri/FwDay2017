using System;
using System.Linq;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microsoft.Examples
{
    /// <summary>
    /// Removes version parameter used by ASP.NET API Versioning.
    /// </summary>
    /// <seealso cref="Swashbuckle.AspNetCore.SwaggerGen.IOperationFilter" />
    internal class RemoveVersionParameters : IOperationFilter
    {
        /// <summary>
        /// Removes version parameter from <paramref name="operation"/>.
        /// </summary>
        /// <param name="operation">Operation.</param>
        /// <param name="context">Operation context.</param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            // Remove version parameter from all Operations
            var versionParameter = operation.Parameters?.SingleOrDefault(p => p.Name == "version");
            if (versionParameter != null)
                operation.Parameters.Remove(versionParameter);
        }
    }
}