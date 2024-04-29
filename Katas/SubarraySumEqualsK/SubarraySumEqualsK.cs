using System;
using System.Collections.Generic;
using UnityEngine;

// The Sliding Window technique involves moving a fixed or variable-sized window across a collection
// to efficiently find subarrays or substrings that meet specific conditions.
// See: https://www.geeksforgeeks.org/window-sliding-technique/
public class SubarraySumEqualsK {
    // List solution
    public static List<int> FindSublistThatSumsToK(List<int> numbers, int K) {
        int start = 0, sum = 0;

        for (int end = 0; end < numbers.Count; end++) {
            sum += numbers[end];

            while (sum > K && start <= end) {
                sum -= numbers[start];
                start++;
            }

            if (sum == K) {
                return numbers.GetRange(start, end - start + 1);
            }
        }

        return new List<int>();
    }

    // Array solution
    public static int[] FindSubarrayThatSumsToK(int[] numbers, int K) {
        int start = 0, sum = 0;

        for (int end = 0; end < numbers.Length; end++) {
            sum += numbers[end];
            
            while (sum > K && start <= end) {
                sum -= numbers[start];
                start++;
            }

            if (sum == K) {
                return numbers[start..(end + 1)];
            }
        }

        return Array.Empty<int>();
    }

    public void Test() {
        // Test case for List
        List<int> numbersList = new List<int> { 1, 2, 3, 4, 5 };
        int targetKList = 9;
        var sublist = FindSublistThatSumsToK(numbersList, targetKList);
        Debug.Log("Sublist that sums to " + targetKList + ": [" + string.Join(", ", sublist) + "]");

        // Test case for Array
        int[] numbersArray = { 1, 2, 3, 4, 5 };
        int targetKArray = 9;
        var subarray = FindSubarrayThatSumsToK(numbersArray, targetKArray);
        Debug.Log("Subarray that sums to " + targetKArray + ": [" + string.Join(", ", subarray) + "]");
    }
}
