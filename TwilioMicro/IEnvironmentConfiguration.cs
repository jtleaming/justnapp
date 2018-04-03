using Microsoft.Extensions.Configuration;

namespace TwilioMicro
{
    public interface IEnvironmentConfiguration
    {
        string SID { get; set; }
        string AUTH { get; set; }
        string D_NUMBER { get; set; }
        string O_NUMBER { get; set; }

    }

    public class EnvironmentConfiguration : IEnvironmentConfiguration
    {
        public EnvironmentConfiguration(IConfiguration configuration)
        {
            SID  = configuration["ENVIRONMENT_VARIABLES:T_ID"];
            AUTH  = configuration["ENVIRONMENT_VARIABLES:T_AUTH"];
            D_NUMBER = configuration["ENVIRONMENT_VARIABLES:D_NUM"];
            O_NUMBER = configuration["ENVIRONMENT_VARIABLES:O_NUM"];
        }
        public string SID { get; set; }
        public string AUTH { get; set; }
        public string D_NUMBER { get; set; }
        public string O_NUMBER { get; set; }
    }
}