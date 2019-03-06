using AnignoraDataTypes.Configurations;

namespace SamplesProviders.Configuration
{
    public class MockSamplesProvidersConfig : IConfiguration
    {
        public void SetDefaults()
        {
            SampleIntervalMs = 10;
        }

        public int SampleIntervalMs { get; set; }
    }
}