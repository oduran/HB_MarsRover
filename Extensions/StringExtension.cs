using System.Linq;
using System.Text;

namespace HB_MarsRover.Extensions
{
    public static class StringExtension
    {
        // Check string is null or empty
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        // Convert each string array elements to upper character
        public static string[] ToUpperArray(this string s)
        {
            s = s.ToUpperEng();
            return s.ToCharArray().Select(c => c.ToString()).ToArray();
        }

        // Convert string to upper character
        public static string ToUpper(this string str, bool useEnglish = false)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            if (str.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();

            foreach (char c in str)
            {
                if (useEnglish)
                {
                    switch (c.ToString())
                    {
                        case "i":
                        case "ı":
                        case "İ":
                            {
                                sb.Append("I");
                                break;
                            }
                        case "ğ":
                        case "Ğ":
                            {
                                sb.Append("G");
                                break;
                            }
                        case "ü":
                        case "Ü":
                            {
                                sb.Append("U");
                                break;
                            }
                        case "ş":
                        case "Ş":
                            {
                                sb.Append("S");
                                break;
                            }
                        case "ö":
                        case "Ö":
                            {
                                sb.Append("O");
                                break;
                            }
                        case "ç":
                        case "Ç":
                            {
                                sb.Append("C");
                                break;
                            }
                        default:
                            sb.Append(c.ToString().ToUpper());
                            break;

                    }
                }
                else
                {
                    sb.Append(c.ToString().ToUpper());
                }
            }

            return sb.ToString();
        }

        // Convert string to upper english character
        public static string ToUpperEng(this string str)
        {
            return str.ToUpper(true);
        }
    }
}
