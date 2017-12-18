using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Open.Social.Utils.Cryptografia
{
    public class Cryptography
    {
        public string CypherValueByProjectConfiguration(string value, string saltValue, string cypherType = "sha512")
        {
            saltValue = (saltValue == null) ? string.Empty : saltValue;

            if (cypherType.ToLower() == "sha512" || cypherType.ToString() == "0") // default method
            {
                string strSenhaHash = "";

                SHA512 alg = SHA512.Create();

                if (saltValue.Length > 0)
                    value = string.Concat(saltValue.Substring(0, 18), value, saltValue.Substring(18));

                byte[] result = alg.ComputeHash(Encoding.ASCII.GetBytes(value));
                byte[] arrSenhaHash = alg.ComputeHash(result);

                //Convertendo para hexa
                foreach (byte b in result)
                {
                    strSenhaHash += String.Format("{0:x2}", b);
                }
                int qtd = Convert.ToInt32(strSenhaHash.Length);

                return strSenhaHash;
            }
            else if (cypherType.ToLower() == "sha1")
            {
                HashAlgorithm AlgoritimoHash = new SHA1Managed();

                string strSenhaHash = "";

                byte[] arrSenhaBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(value);
                byte[] arrSenhaHash = AlgoritimoHash.ComputeHash(arrSenhaBytes);

                //Convertendo para hexa
                foreach (byte b in arrSenhaHash)
                {
                    strSenhaHash += String.Format("{0:x2}", b);
                }
                int qtd = Convert.ToInt32(strSenhaHash.Length);

                return strSenhaHash;
            }
            else
                return string.Empty;
        }
    }
}

