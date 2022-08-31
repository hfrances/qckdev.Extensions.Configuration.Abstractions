using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace qckdev.Extensions.Configuration.Abstractions.Test
{
    sealed class ConfigurationSectionMock : IConfigurationSection
    {

        public string Path { get; }

        public string Key { get; }

        public string Value { get; set; }


        public ConfigurationSectionMock(string path, string key, string value)
        {
            this.Path = path;
            this.Key = key;
            this.Value = value;
        }

        public string this[string key]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            return Array.Empty<ConfigurationSectionMock>();
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
