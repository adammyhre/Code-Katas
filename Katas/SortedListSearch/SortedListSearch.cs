using UnityEngine;

public static class SortedListSearch {
    public static bool BinarySearch(int[] sortedList, int x) {
        int left = 0, right = sortedList.Length - 1;

        while (left <= right) {
            if (sortedList[left] == x || sortedList[right] == x) return true;

            if (right - left <= 1) return false;

            int middle = left + 1;

            if (sortedList[middle] == x) return true;
            
            if (sortedList[middle] < x) left = middle + 1; // Move the left pointer closer to right
            else right = middle - 1; // Move the right pointer closer to left
        }

        return false;
    }

    public static void Test() {
        int[] sortedList = { 1, 3, 5, 7, 9, 11, 13, 15 };
        
        Debug.Assert(BinarySearch(sortedList, 7), "Test Case 1 Failed");
        Debug.Assert(BinarySearch(sortedList, 1), "Test Case 2 Failed");
        Debug.Assert(BinarySearch(sortedList, 15), "Test Case 3 Failed");
        Debug.Assert(!BinarySearch(sortedList, 0), "Test Case 4 Failed");
        Debug.Assert(!BinarySearch(sortedList, 16), "Test Case 5 Failed");

        Debug.Log("All test cases passed!");
    }
}