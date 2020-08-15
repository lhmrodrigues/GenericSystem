using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.CrossCutting.Util.Interface
{
    public interface ISystemConfiguration
    {
        /// <summary>
        /// Connection to the Azure Database
        /// </summary>
        string ConnectionString { get; }

        /// <summary>
        /// JWT key for token auth
        /// </summary>
        string JwtKey { get; }

        /// <summary>
        /// JWT issuer
        /// </summary>
        string JwtIssuer { get; }

        /// <summary>
        /// JWT token expiration date
        /// </summary>
        int JwtExpires { get; }

        /// <summary>
        /// Cookie expiration date
        /// </summary>
        int CookieExpires { get; }

        /// <summary>
        /// URL for Cpnucleo API
        /// </summary>
        string UrlGenericSystemApi { get; }

    }
}
