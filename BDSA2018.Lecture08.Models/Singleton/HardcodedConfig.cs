﻿namespace BDSA2018.Lecture08.Models.Singleton
{
    public class HardcodedConfig : IConfig
    {
        public string ClientId => "11cd234e-4bf1-43ca-8607-c0022a92cba1";

        public string ClientSecret => "";

        public static HardcodedConfig Instance { get; }

        static HardcodedConfig()
        {
            Instance = new HardcodedConfig();
        }

        private HardcodedConfig()
        {
        }
    }
}
