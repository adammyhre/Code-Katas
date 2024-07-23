using System;
using UnityEngine;

public class PalindromeChecker {
    public static bool IsPalindrome(string input) {
        int left = 0, right = input.Length - 1;

        while (left < right) {
            while (left < right && !char.IsLetterOrDigit(input[left])) left++;
            while (left < right && !char.IsLetterOrDigit(input[right])) right--;

            if (char.ToLower(input[left]) != char.ToLower(input[right])) return false;

            left++;
            right--;
        }

        return true;
    }    

    public static void Test() {
        Debug.Assert(IsPalindrome("A man, a plan, a canal, Panama") == true, "Test 1 Failed");
        Debug.Assert(IsPalindrome("No 'x' in Nixon") == true, "Test 2 Failed");
        Debug.Assert(IsPalindrome("Hello, World!") == false, "Test 3 Failed");
        Debug.Assert(IsPalindrome("") == true, "Test 4 Failed");
        Debug.Assert(IsPalindrome(null) == true, "Test 5 Failed");

        Debug.Log("All tests passed");
    }
}
