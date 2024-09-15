using System.Collections.Generic;
using UnityEngine;

public static class PythagoreanTriplet {
    public static bool ContainsPythagoreanTriplet(int[] numbers) {
        HashSet<int> squares = new HashSet<int>();
        foreach (int number in numbers) {
            squares.Add(number * number);
        }

        for (int i = 0; i < numbers.Length; i++) {
            for (int j = i + 1; j < numbers.Length; j++) {
                int a2 = numbers[i] * numbers[i];
                int b2 = numbers[j] * numbers[j];
                if (squares.Contains(a2 + b2)) {
                    return true;
                }
            }
        }

        return false;
    }

    public static void Test() {
        Debug.Assert(ContainsPythagoreanTriplet(new int[] { 3, 1, 4, 6, 5 }) == true, "Test 1 Failed");
        Debug.Assert(ContainsPythagoreanTriplet(new int[] { 10, 4, 6, 12, 5 }) == false, "Test 2 Failed");
        Debug.Assert(ContainsPythagoreanTriplet(new int[] { 8, 15, 17 }) == true, "Test 3 Failed");
        Debug.Assert(ContainsPythagoreanTriplet(new int[] { 7, 24, 25, 30 }) == true, "Test 4 Failed");
        Debug.Assert(ContainsPythagoreanTriplet(new int[] { 1, 2, 3 }) == false, "Test 5 Failed");

        Debug.Log("All Tests Passed!");
    }
}