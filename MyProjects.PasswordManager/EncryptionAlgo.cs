using System.Text;

namespace MyProject.PasswordManager;
public class EncryptionUtiliy
{
    private static readonly string _originalChars = "!#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]^_`abcdefghijklmnopqrstuvwxyz{|}~";
    private static readonly string _decryptedChars = "lABC01#$%&'()*+,-KLMNOP=>^_345ZJVWijkFG`abDE![tuvXYcdf]?@I6eHzo./{pqrsghwnQRSTxy|}~789:;<mU2";

    public static string Encrypt(string password)
    {
        var sb = new StringBuilder();
        foreach (var ch in password)
        {
            var charIndex = _originalChars.IndexOf(ch);
            sb.Append(_decryptedChars[charIndex]);
        }
        return sb.ToString();
    }
    public static string Decrypt(string password)
    {
        var sb = new StringBuilder();
        foreach (var ch in password)
        {
            var charIndex = _decryptedChars.IndexOf(ch);
            sb.Append(_originalChars[charIndex]);
        }
        return sb.ToString();
    }
}
