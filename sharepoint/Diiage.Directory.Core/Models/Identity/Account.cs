using Diiage.Directory.Core.Interfaces;

using System;

namespace Diiage.Directory.Core.Models.Identity
{
    public class Account : IModel
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Upn { get; set; }
    }
}
