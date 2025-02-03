using System.Text;

public class EncryptionService
{
    // Enkel krypteringsmetod (Rövarspråket)
    public string Encrypt(string text)
    {
        StringBuilder encryptedText = new StringBuilder();
        foreach (var c in text)
        {
            if ("aeiouåäö".Contains(char.ToLower(c)))
            {
                encryptedText.Append(c);
                encryptedText.Append('o');
                encryptedText.Append(char.ToLower(c));
            }
            else
            {
                encryptedText.Append(c);
            }
        }
        return encryptedText.ToString();
    }

    // Enkel avkrypteringsmetod (Rövarspråket)
    public string Decrypt(string text)
    {
        StringBuilder decryptedText = new StringBuilder();
        int i = 0;
        while (i < text.Length)
        {
            decryptedText.Append(text[i]);
            if ("aeiouåäö".Contains(char.ToLower(text[i])) && i + 2 < text.Length && text[i + 2] == text[i])
            {
                i += 3;  // Hoppa över 'o' och den upprepade bokstaven
            }
            else
            {
                i++;
            }
        }
        return decryptedText.ToString();
    }
}
