using Diiage.Directory.Core.Interfaces;

namespace Diiage.Directory.Core.Models.Configuration
{
    /// <summary>
    /// Defines the application configuration.
    /// </summary>
    public class ApplicationConfiguration : IModel
    {
        /// <summary>
        /// Gets or sets the UI (SPA) configuration.
        /// </summary>
        /// <value>
        /// The UI configuration.
        /// </value>
        public UiConfiguration Ui { get; set; }
    }
}
