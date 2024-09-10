using System.Collections.Generic;
using UnityEngine;

public static class GreatestCommonDenominator {
    public static int FindGCD(int[] numbers) {
        if (numbers == null || numbers.Length == 0) return 0;

        var gcd = numbers[0];
        for (var i = 1; i < numbers.Length; i++) {
            gcd = ComputeGCD(gcd, numbers[i]);
        }

        return gcd;
    }

    static int ComputeGCD(int a, int b) {
        return b == 0 ? Mathf.Abs(a) : ComputeGCD(b, a % b);
    }

    [RuntimeInitializeOnLoadMethod]
    static void TestFindGCD() {
        Debug.Assert(FindGCD(new int[] { 42, 56, 14 }) == 14, "Test Case 1 Failed");
        Debug.Assert(FindGCD(new int[] { 18, 27, 9 }) == 9, "Test Case 2 Failed");
        Debug.Assert(FindGCD(new int[] { 100, 75, 25 }) == 25, "Test Case 3 Failed");
        Debug.Assert(FindGCD(new int[] { 7, 13 }) == 1, "Test Case 4 Failed");
        Debug.Assert(FindGCD(new int[] { }) == 0, "Test Case 5 Failed");
        Debug.Assert(FindGCD(new int[] { 12 }) == 12, "Test Case 6 Failed");

        Debug.Log("All test cases passed!");
    }
}