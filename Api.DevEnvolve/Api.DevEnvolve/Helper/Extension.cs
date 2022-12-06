using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;

namespace Api.DevEnvolve.Helper
{
    public static class Extension
    {
        /// <summary>
        /// Remove caracteres não numericos de uma string
        /// </summary>
        /// <returns>string</returns>
        public static string RemoveNonNumeric(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            return Regex.Replace(value, "[^0-9]", "");
        }

        /// <summary>
        /// Remove caracteres a mais da string
        /// </summary>
        /// <returns>string</returns>
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return value.Substring(0, Math.Min(value.Length, maxLength));
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static string ToNullSafeString(this object value)
        {
            return value == null ? String.Empty : value.ToString();
        }

        public interface PasswordEncoderHandler
        {
            String encodePlainPassword(String paramString);

            String encodeConnection(String paramString);

            String plainPassword(String paramString1, String paramString2);
        }

        public class DefaultSGUPasswordEncoderHandler : PasswordEncoderHandler
        {
            protected static char KEY_PADDING = 'K';

            protected static int LENGTH_WORD = 30;

            protected static String EMPTY_STR = " ";

            private String padr(String value, char stuff, int size)
            {
                StringBuilder buffer = new StringBuilder();
                if ((value != null))
                {
                    buffer.Append(value);
                    if ((value.Length < size))
                    {
                        for (int i = 0; (i
                                    < (size - value.Length)); i++)
                        {
                            buffer.Append(stuff);
                        }
                    }
                    //else
                    //{
                    //    buffer.setLength(size);
                    //}
                }

                return buffer.ToString();
            }

            public String encodeConnection(String passowrdStore)
            {
                String ascii3 = "#ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkl" +
                "mnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                if (((passowrdStore == null)
                            || passowrdStore.Equals("")))
                {
                    passowrdStore = " ";
                }

                passowrdStore = passowrdStore.ToUpper();
                String retorno = "";
                for (int i = 1; (i <= passowrdStore.Length); i++)
                {
                    char caracter = passowrdStore[(i - 1)];
                    int posicao = ascii3.IndexOf(caracter);
                    if ((posicao > 0))
                    {
                        if ((i == 1))
                        {
                            if (("0123456789".IndexOf(ascii3[((2 * posicao) + (i / i))]) != -1))
                            {
                                retorno = (retorno + 'x');
                            }
                            else
                            {
                                retorno = (retorno + ascii3[((2 * posicao) + (i / i))]);
                            }
                        }
                        else
                        {
                            retorno = retorno + ascii3[((2 * posicao) + (i / i))];
                        }
                    }
                    else
                    {
                        retorno = (retorno + ascii3[i]);
                    }
                }

                return retorno;
            }

            public String encodePlainPassword(String password)
            {
                password = this.padr(password.Trim(), 'K', 30);
                if (((password == null)
                            || password.Equals("")))
                {
                    password = " ";
                }

                String retorno = "";
                for (int i = 0; (i < password.Length); i++)
                {
                    int indice = (i + 1);
                    retorno = (retorno + ((char)((password[i]
                                + ((2 * indice)
                                + (indice / indice))))));
                }

                return retorno;
            }

            public String plainPassword(String username, String password)
            {
                username = username.ToUpper();
                password = password.ToUpper();
                return (username + password);
            }
        }

        public static class CustomClaimTypes
        {
            public const string id = "id";
        }
        public static long GetPrestadorId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(CustomClaimTypes.id);
            if (claim == null) return 0;
            return long.Parse(claim.Value);
        }
    }
}