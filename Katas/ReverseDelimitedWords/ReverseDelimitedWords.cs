using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MemoryLeak {
    public static class ReverseDelimitedWords {
        public static string ReverseWords(string input, HashSet<char> delimiters) {
            List<string> tokens = new();
            StringBuilder currentWord = new();

            // Tokenize input
            foreach (var c in input) {
                if (delimiters.Contains(c)) {
                    if (currentWord.Length > 0) {
                        tokens.Add(currentWord.ToString());
                        currentWord.Clear();
                    }

                    tokens.Add(c.ToString());
                }
                else {
                    currentWord.Append(c);
                }
            }

            if (currentWord.Length > 0) {
                tokens.Add(currentWord.ToString());
            }

            // Initialize result and find last word index
            StringBuilder result = new StringBuilder(input.Length);
            int lastWordIndex = tokens.Count - 1;

            while (lastWordIndex >= 0 && delimiters.Contains(tokens[lastWordIndex][0])) {
                lastWordIndex--;
            }

            // Reconstruct reversed words with delimiters
            foreach (var t in tokens) {
                if (delimiters.Contains(t[0])) {
                    result.Append(t);
                }
                else {
                    result.Append(tokens[lastWordIndex]);
                    lastWordIndex--;
                    while (lastWordIndex >= 0 && delimiters.Contains(tokens[lastWordIndex][0])) {
                        lastWordIndex--;
                    }
                }
            }

            return result.ToString();
        }

        public static void Test() {
            HashSet<char> delimiters = new HashSet<char> { '/', ':' };

            string input1 = "hello/world:here";
            string expected1 = "here/world:hello";
            Debug.Log($"Input: {input1}, Expected: {expected1}, Result: {ReverseWords(input1, delimiters)}");
            Debug.Assert(ReverseWords(input1, delimiters) == expected1, $"Test failed for input: {input1}");

            string input2 = "hello/world:here/";
            string expected2 = "here/world:hello/";
            Debug.Log($"Input: {input2}, Expected: {expected2}, Result: {ReverseWords(input2, delimiters)}");
            Debug.Assert(ReverseWords(input2, delimiters) == expected2, $"Test failed for input: {input2}");

            string input3 = "hello//world:here";
            string expected3 = "here//world:hello";
            Debug.Log($"Input: {input3}, Expected: {expected3}, Result: {ReverseWords(input3, delimiters)}");
            Debug.Assert(ReverseWords(input3, delimiters) == expected3, $"Test failed for input: {input3}");
        }
    }
}