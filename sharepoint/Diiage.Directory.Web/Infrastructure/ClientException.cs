using System;
using System.Collections;

namespace Diiage.Directory.Web.Infrastructure
{
    /// <summary>
    /// Exception pour sérialisation client.
    /// </summary>
    public class ClientException
    {
        /// <summary>
        /// Titre de l'erreur.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Identifiant technique de l'erreur.
        /// </summary>
        public Guid CorrelationId { get; set; }
        /// <summary>
        /// Données complémentaires associées à l'erreur.
        /// </summary>
        public IDictionary Data { get; set; }
    }
}
