public class RunLengthEncoding {
    public static string Encode(string input) {
        if (string.IsNullOrEmpty(input)) return string.Empty;

        StringBuilder result = new StringBuilder();
        char prevChar = input[0];
        int count = 1;

        for (int i = 1; i < input.Length; i++) {
            if (input[i] == prevChar) {
                count++;
            }
            else {
                result.Append(count).Append(prevChar);
                prevChar = input[i];
                count = 1;
            }
        }

        result.Append(count).Append(prevChar);

        return result.ToString();
    }

    public static string Decode(string encoded) {
        if (string.IsNullOrEmpty(encoded)) return string.Empty;

        StringBuilder result = new StringBuilder();
        int count = 0;

        foreach (char c in encoded) {
            if (char.IsDigit(c)) {
                count = (count * 10) + (c - '0');
            }
            else {
                result.Append(c, count);
                count = 0;
            }
        }

        return result.ToString();
    }

    public void Test() {
        string encoded = Encode("AAAABBBCCDAA");
        Debug.Log("Encoded: " + encoded);

        string decoded = Decode(encoded);
        Debug.Log("Decoded: " + decoded);
    }
}