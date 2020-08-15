using GenericSystem.Infra.CrossCutting.Util.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.CrossCutting.Util
{
    internal class SystemConfiguration : ISystemConfiguration
    {
        private readonly IConfiguration _configuration;

        public SystemConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string ConnectionString
        {
            get
            {
                string value = _configuration.GetConnectionString("SqlConnection");

                if (value != null)
                {
                    return value;
                }

                return string.Empty;
            }
        }

        public string JwtIssuer
        {
            get
            {
                string value = _configuration.GetSection("Jwt")["Issuer"];

                if (value != null)
                {
                    return value;
                }

                return string.Empty;
            }
        }

        public int JwtExpires
        {
            get
            {
                int.TryParse(_configuration.GetSection("Jwt")["Expires"], out int value);

                return value;
            }
        }

        public int CookieExpires
        {
            get
            {
                int.TryParse(_configuration.GetSection("Cookie")["Expires"], out int value);

                return value;
            }
        }

        public string JwtKey
        {
            get
            {
                string value = _configuration.GetSection("Jwt")["Key"];

                if (value != null)
                {
                    return value;
                }

                return string.Empty;
            }
        }

        public string UrlGenericSystemApi
        {
            get
            {
                string value = _configuration.GetSection("AppSettings")["UrlGenericSystemApi"];

                if (value != null)
                {
                    return value;
                }

                return string.Empty;
            }
        }
    }
}
