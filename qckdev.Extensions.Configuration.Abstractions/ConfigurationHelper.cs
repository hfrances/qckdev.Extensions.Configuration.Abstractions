﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace qckdev.Extensions.Configuration
{

    /// <summary>
    /// Provides helpful methods for application configuration properties.
    /// </summary>
    public static class ConfigurationHelper
    {

        /// <summary>
        /// Searches and replaces environment variables in the application configuration properties. 
        /// Environment variables are defined in the following format: '%VariableName%'.
        /// </summary>
        /// <param name="configuration">Application configuration properties to replace.</param>
        public static void ApplyEnvironmentVariables(this IConfiguration configuration)
        {
            ApplyVariables(
                configuration
                    .AsEnumerable()
                    .ToDictionary(
                        x => x.Key, y => y.Value,
                        StringComparer.OrdinalIgnoreCase
                    ),
                (key, value) => configuration[key] = value
            );
        }

        /// <summary>
        /// Searches variables in the application configuration properties.
        /// Variables are defined in the following format: '%VariableName%'.
        /// </summary>
        /// <param name="dictionary">Dictionary with all values and variables.</param>
        /// <param name="setValuePredicate">Defines what action to perform when some %VariableName% were found.</param>
        public static void ApplyVariables(IDictionary<string, string> dictionary, Action<string, string> setValuePredicate)
        {
            // https://regex101.com/r/bCmRKM/1
            // https://regex101.com/r/bCmRKM/2
            const string pattern = @"(?<substring1>[^%].?[^%]*)?(?:%(?<envar>\w+)%)(?<substring2>[^%].?[^%]*)?";
            var regex = new Regex(pattern);

            foreach (var item in dictionary.ToArray().Where(x => x.Value != null))
            {
                var matches = regex.Matches(item.Value);

                if (matches.OfType<Match>().Any())
                {
                    var list = new List<string>();

                    foreach (Match match in matches)
                    {
                        var substring1 = match.Groups["substring1"];
                        var variableName = match.Groups["envar"].Value;
                        var substring2 = match.Groups["substring2"];
                        string newValue;

                        if (dictionary.TryGetValue(variableName, out string @envar))
                        {
                            newValue = string.Concat(substring1, @envar, substring2);
                        }
                        else
                        {
                            newValue = match.Value;
                            System.Diagnostics.Debug.WriteLine($"Environment variable not found: '{variableName}'.");
                        }
                        list.Add(newValue);
                    }
                    setValuePredicate(item.Key, string.Concat(list));
                }
            }
        }

    }
}
