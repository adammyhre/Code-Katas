using System;
using System.Collections.Generic;
using UnityEngine;

public class FormLargestInteger {
    public static string FormLargest(List<int> numbers) {
        var strNumbers = new List<string>();
        
        foreach (var number in numbers) {
            strNumbers.Add(number.ToString());
        }

        strNumbers.Sort((a, b) => string.Compare((b + a), a + b, StringComparison.Ordinal));
        var largestNumber = string.Join("", strNumbers);

        return largestNumber.StartsWith("0") ? "0" : largestNumber;
    }

    public static void Test() {
        var numbers1 = new List<int> { 10, 7, 76, 415 };
        Debug.Assert(FormLargest(numbers1) == "77641510");

        var numbers2 = new List<int> { 3, 30, 34, 5, 9 };
        Debug.Assert(FormLargest(numbers2) == "9534330");

        var numbers3 = new List<int> { 1, 20, 23, 4, 8 };
        Debug.Assert(FormLargest(numbers3) == "8423201");

        var numbers4 = new List<int> { 0, 0, 0, 0 };
        Debug.Assert(FormLargest(numbers4) == "0");

        var numbers5 = new List<int> { 12, 121 };
        Debug.Assert(FormLargest(numbers5) == "12121");

        var numbers6 = new List<int> { 824, 938, 1399, 5607, 6973, 5703, 9609, 4398, 8247 };
        Debug.Assert(FormLargest(numbers6) == "9609938824824769735703560743981399");

        Debug.Log("All test cases passed!");
    }
}