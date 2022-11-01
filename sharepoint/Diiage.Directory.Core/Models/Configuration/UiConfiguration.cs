using Diiage.Directory.Core.Interfaces;

namespace Diiage.Directory.Core.Models.Configuration
{
    /// <summary>
    /// Defines the client SPA configuration.
    /// </summary>
    public class UiConfiguration : IModel
    {
        /// <summary>
        /// Gets or sets the application version.
        /// </summary>
        /// <value>
        /// The application version.
        /// </value>
        public string Version { get; set; }
    }
}
