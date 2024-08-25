using System.Collections.Generic;
using System;
using UnityEngine;

public static class InPlaceShuffle {
    public static void Shuffle<T>(IList<T> collection) {
        Debug.Assert(collection != null, "Collection cannot be null");
        
        int n = collection.Count;
        for (int i = n - 1; i > 0; i--) {
            int j = GetRandom(0, i);
            Swap(collection, i, j);
        }
    }

    static void Swap<T>(IList<T> collection, int i, int j) {
        T temp = collection[i];
        collection[i] = collection[j];
        collection[j] = temp;
    }

    public static int GetRandom(int floor, int ceiling) {
        return UnityEngine.Random.Range(floor, ceiling + 1);
    }

    public static void Test() {
        // Test case 1: Shuffle a simple array
        int[] array = { 1, 2, 3, 4, 5 };
        Shuffle(array);
        Debug.Log("Shuffled Array: " + string.Join(", ", array));

        // Test case 2: Shuffle a List
        List<int> list = new List<int> { 1, 2, 3, 4, 5 };
        Shuffle(list);
        Debug.Log("Shuffled List: " + string.Join(", ", list));

        // Test case 3: Test with a List of length 1 (edge case)
        List<int> singleElementList = new List<int> { 1 };
        Shuffle(singleElementList);
        Debug.Log("Shuffled Single Element List: " + string.Join(", ", singleElementList));

        // Test case 4: Test with an empty List (edge case)
        List<int> emptyList = new List<int>();
        Shuffle(emptyList);
        Debug.Log("Shuffled Empty List: " + string.Join(", ", emptyList));
    }
}