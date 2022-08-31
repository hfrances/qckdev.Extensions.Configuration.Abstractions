using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace qckdev.Extensions.Configuration.Abstractions.Test
{
    [TestClass]
    public class ConfigurationHelperTest
    {
        [TestMethod]
        public void ApplyVariablesOnDictionaryTest()
        {
            var dictionary = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase)
            {
                { "Url", "%baseurl%/api/" },
                { "DefaultConnection", "Server=*****;Database=*****;User Id=%SQLUSR%;Password=%SQLPWD%;MultipleActiveResultSets=true;" },
                { "ServerConnection", "Server=%SQLSRV%;Database=%SQLDB%;Integrated Security=True;" },
                { "Fake1", null },
                { "Fake2", "" },
                { "Fake3", "a" },
                { "Fake4", "prueba" },
                { "Fake5", "%" },
                { "Fake6", "User Id:%SQLUSR%;Password=%SQLPWD%;Other=%SQLOTHER%;" },
                { "BASEURL", "https://midns-dev.midominio.com" },
                { "SQLUSR", "myuser" },
                { "SQLPWD", "mypwd" },
                { "SQLSRV", "SERVER.domain.LOC" },
                { "SQLDB", "MYDATABASE" }
            };
            var expected = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase)
            {
                { "Url", "https://midns-dev.midominio.com/api/" },
                { "DefaultConnection", "Server=*****;Database=*****;User Id=myuser;Password=mypwd;MultipleActiveResultSets=true;" },
                { "ServerConnection", "Server=SERVER.domain.LOC;Database=MYDATABASE;Integrated Security=True;" },
                { "Fake1", null },
                { "Fake2", "" },
                { "Fake3", "a" },
                { "Fake4", "prueba" },
                { "Fake5", "%" },
                { "Fake6", "User Id:myuser;Password=mypwd;Other=%SQLOTHER%;" },
                { "BASEURL", "https://midns-dev.midominio.com" },
                { "SQLUSR", "myuser" },
                { "SQLPWD", "mypwd" },
                { "SQLSRV", "SERVER.domain.LOC" },
                { "SQLDB", "MYDATABASE" }
            };

            ConfigurationHelper.ApplyVariables(dictionary, (key, value) => dictionary[key] = value);
            foreach (var pair in dictionary)
            {
                Assert.AreEqual(expected[pair.Key], pair.Value, $"Key: {pair.Key}");
            }
        }

        [TestMethod]
        public void ApplyEnvironmentVariablesTest()
        {
            var configuration = new ConfigurationMock(new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase)
            {
                { "Url", "%baseurl%/api/" },
                { "DefaultConnection", "Server=*****;Database=*****;User Id=%SQLUSR%;Password=%SQLPWD%;MultipleActiveResultSets=true;" },
                { "ServerConnection", "Server=%SQLSRV%;Database=%SQLDB%;Integrated Security=True;" },
                { "Fake1", null },
                { "Fake2", "" },
                { "Fake3", "a" },
                { "Fake4", "prueba" },
                { "Fake5", "%" },
                { "Fake6", "User Id:%SQLUSR%;Password=%SQLPWD%;Other=%SQLOTHER%;" },
                { "BASEURL", "https://midns-dev.midominio.com" },
                { "SQLUSR", "myuser" },
                { "SQLPWD", "mypwd" },
                { "SQLSRV", "SERVER.domain.LOC" },
                { "SQLDB", "MYDATABASE" }
            });
            var expected = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase)
            {
                { "Url", "https://midns-dev.midominio.com/api/" },
                { "DefaultConnection", "Server=*****;Database=*****;User Id=myuser;Password=mypwd;MultipleActiveResultSets=true;" },
                { "ServerConnection", "Server=SERVER.domain.LOC;Database=MYDATABASE;Integrated Security=True;" },
                { "Fake1", null },
                { "Fake2", "" },
                { "Fake3", "a" },
                { "Fake4", "prueba" },
                { "Fake5", "%" },
                { "Fake6", "User Id:myuser;Password=mypwd;Other=%SQLOTHER%;" },
                { "BASEURL", "https://midns-dev.midominio.com" },
                { "SQLUSR", "myuser" },
                { "SQLPWD", "mypwd" },
                { "SQLSRV", "SERVER.domain.LOC" },
                { "SQLDB", "MYDATABASE" }
            };

            configuration.ApplyEnvironmentVariables();
            foreach (var pair in configuration.InnerCollection)
            {
                Assert.AreEqual(expected[pair.Key], pair.Value, $"Key: {pair.Key}");
            }
        }
    }
}