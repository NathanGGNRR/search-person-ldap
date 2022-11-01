using Diiage.Directory.Core.Interfaces;

namespace Diiage.Directory.Core.Models.Configuration
{
    /// <summary>
    /// UI remote configuration
    /// </summary>
    /// <seealso cref="Diiage.Directory.Core.Interfaces.IModel" />
    public class RemoteUiConfiguration : IModel
    {
        /// <summary>
        /// Gets or sets the application version.
        /// </summary>
        /// <value>
        /// The application version
        /// </value>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the upn.
        /// </summary>
        /// <value>
        /// The upn.
        /// </value>
        public string Upn { get; set; }

        /// <summary>
        /// Gets or sets the user Id.
        /// </summary>
        /// <value>
        /// The user Id.
        /// </value>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }
    }
}
