using Microsoft.Extensions.Configuration;

namespace RestApiExample.Utils
{
    internal static class ConfigUtil
    {
        public static string GetValueByName(string configKey)
        {
            var configTests = new ConfigurationBuilder()
                .AddJsonFile("Resources/testsconfig.json")
                .Build();
            IConfigurationSection section = configTests.GetSection(configKey);
            return section.Value;
        }
    }
}