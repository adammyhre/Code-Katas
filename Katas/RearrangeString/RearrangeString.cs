using System.Collections.Generic;
using UnityEngine;

public static class RearrangeString {
    public static string Reorder(string s) {
        if (string.IsNullOrEmpty(s)) return "None";

        // Count the frequency of each character
        var frequencyMap = new Dictionary<char, int>();
        foreach (var c in s) {
            frequencyMap.TryAdd(c, 0);
            frequencyMap[c]++;
        }

        // Initialize max heap based on the character frequencies
        var maxHeap = new PriorityQueue<char>();
        foreach (var entry in frequencyMap) {
            maxHeap.Add((new Key(-entry.Value, entry.Key), entry.Key));
        }

        var result = string.Empty;
        (Key, char)? prev = null;

        while (maxHeap.Count > 0) {
            var current = maxHeap.Min;
            maxHeap.Remove(current.Item2);

            // Append current character to result
            result += current.Item2;

            // Decrease the frequency
            var currentFrequency = -current.Item1.k1 - 1;

            // Push the previous character back to the heap if it still has a remaining count
            if (prev.HasValue && prev.Value.Item1.k1 < 0) {
                maxHeap.Add(prev.Value);
            }

            // Update the previous character as the current character
            prev = (new Key(-currentFrequency, current.Item2), current.Item2);
        }

        // Check if the result length matches the input length
        return result.Length != s.Length ? "None" : result;
    }

    public static void Test() {
        string[] testInputs = { "aaabbc", "aaab", "a", "", "aaaabb", "aabb", "aa", "ababab" };

        foreach (string input in testInputs) {
            var result = Reorder(input);
            Debug.Log($"Input: \"{input}\" => Output: \"{result}\"");
        }
    }
}