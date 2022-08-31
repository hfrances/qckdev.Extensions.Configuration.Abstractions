using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace qckdev.Extensions.Configuration.Abstractions.Test
{
    sealed class ConfigurationMock : IConfiguration
    {

        public IDictionary<string, string?> InnerCollection { get; }


        public ConfigurationMock(IDictionary<string, string?> collection)
        {
            this.InnerCollection = collection;
        }

        public string this[string key]
        {
            get => InnerCollection[key] ?? string.Empty;
            set => InnerCollection[key] = value;
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            return InnerCollection.Select(x => new ConfigurationSectionMock(x.Key, x.Key, x.Value ?? string.Empty));
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            throw new NotImplementedException();
        }
    }
}
