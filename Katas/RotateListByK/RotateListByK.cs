using System;
using System.Collections.Generic;
using UnityEngine;

class RotateListByK {
    // Rotate any IList<int> in place (both Arrays and List implement IList)
    static void Rotate<T>(IList<T> list, int k) {
        int n = list.Count;
        if (n == 0 || n == 1) return; // No rotation needed for empty or single-element lists

        k = ((k % n) + n) % n; // Normalize k to always be a positive offset within the list size

        list.Reverse(); // Reverse the entire list to reorder all elements
        list.Reverse(0, n - k - 1); // Reverse the first segment to its original order
        list.Reverse(n - k, n - 1); // Reverse the second segment to its original order
    }

    public void Test() {
        List<int> list = new List<int> { 1, 2, 3, 4, 5, 6 };
        int[] array = { 1, 2, 3, 4, 5, 6 };
        int k = 2;

        Rotate(list, k);
        Rotate(array, k);

        Debug.Log("List after rotating by " + k + ": " + string.Join(", ", list));
        Debug.Log("Array after rotating by " + k + ": " + string.Join(", ", array));

        // Test negative rotation
        int kNegative = -1;
        Rotate(list, kNegative);
        Rotate(array, kNegative);

        Debug.Log("List after rotating by " + kNegative + ": " + string.Join(", ", list));
        Debug.Log("Array after rotating by " + kNegative + ": " + string.Join(", ", array));
    }
}

static class Extensions {
    public static void Reverse<T>(this IList<T> list, int start = 0, int end = -1) {
        if (end == -1) end = list.Count - 1;

        while (start < end) {
            (list[start], list[end]) = (list[end], list[start]);
            start++;
            end--;
        }
    }
}