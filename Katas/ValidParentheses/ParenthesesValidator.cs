using UnityEngine;

public class ParenthesesValidator {
    public static int MinRemovalsRequired(string s) {
        if (string.IsNullOrEmpty(s)) return 0;
        
        int openCount = 0, removals = 0;

        foreach (char c in s) {
            if (c == '(') {
                openCount++;
            }
            else if (c == ')') {
                if (openCount > 0) {
                    openCount--;
                }
                else {
                    removals++;
                }
            }
        }

        return removals + openCount;
    }

    public static void Test() {
        Debug.Assert(MinRemovalsRequired("()())()") == 1, "Test 1 Failed");
        Debug.Assert(MinRemovalsRequired(")(") == 2, "Test 2 Failed");
        Debug.Assert(MinRemovalsRequired("(((") == 3, "Test 3 Failed");
        Debug.Assert(MinRemovalsRequired("(()))") == 1, "Test 4 Failed");
        Debug.Assert(MinRemovalsRequired("") == 0, "Test 5 Failed");

        Debug.Log("All tests passed.");
    }
}