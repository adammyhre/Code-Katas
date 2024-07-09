using UnityEngine;
using System.Text;

public class LookAndSaySequence {
    public string GenerateNthTerm(int N) {
        if (N <= 0) return "";

        string currentTerm = "1";

        for (int i = 1; i < N; i++) {
            currentTerm = GetNextTerm(currentTerm);
        }

        return currentTerm;
    }

    string GetNextTerm(string term) {
        StringBuilder nextTerm = new StringBuilder();
        int count = 1;

        for (int i = 1; i < term.Length; i++) {
            if (term[i] == term[i - 1]) {
                count++;
            }
            else {
                nextTerm.Append(count).Append(term[i - 1]);
                count = 1;
            }
        }

        nextTerm.Append(count).Append(term[^1]);

        return nextTerm.ToString();
    }

    public static void Test() {
        LookAndSaySequence sequence = new LookAndSaySequence();

        Debug.Assert(sequence.GenerateNthTerm(1) == "1");
        Debug.Assert(sequence.GenerateNthTerm(2) == "11");
        Debug.Assert(sequence.GenerateNthTerm(3) == "21");
        Debug.Assert(sequence.GenerateNthTerm(4) == "1211");
        Debug.Assert(sequence.GenerateNthTerm(5) == "111221");

        Debug.Log("All test cases passed!");
    }
}