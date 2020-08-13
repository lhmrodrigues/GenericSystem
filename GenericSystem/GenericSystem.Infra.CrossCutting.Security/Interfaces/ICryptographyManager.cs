using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.CrossCutting.Security.Interfaces
{
    public interface ICryptographyManager
    {
        //void CryptPbkdf2(string item, out string itemCrypt, out string salt);

        bool VerifyPbkdf2(string item, string itemCrypt, string salt);
    }
}
