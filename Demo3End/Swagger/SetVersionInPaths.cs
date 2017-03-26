using System;
using System.Linq;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microsoft.Examples
{
    /// <summary>
    /// Replaces version placeholder in operation path to real version of operation.
    /// </summary>
    /// <seealso cref="IDocumentFilter" />
    internal class SetVersionInPaths : IDocumentFilter
    {
        /// <summary>
        /// Modifies paths to operation so that it contains real version value instead of placeholder.
        /// </summary>
        /// <param name="swaggerDoc">Swagger document.</param>
        /// <param name="context">Swagger document context.</param>
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            var version = swaggerDoc.Info.Version;
            swaggerDoc.Paths = swaggerDoc.Paths
                .ToDictionary(
                    path => path.Key.Replace("{version}", version),
                    path => path.Value
                );
        }
    }
}