using System;
using UnityEngine;

public static class MiceAndHoles {
    public static int MinimizeMaxDistance(int[] mice, int[] holes) {
        int n = mice.Length;

        Array.Sort(mice);
        Array.Sort(holes);

        int maxDistance = 0;

        for (int i = 0; i < n; i++) {
            int distance = Math.Abs(mice[i] - holes[i]);
            maxDistance = Math.Max(maxDistance, distance);
        }

        return maxDistance;
    }

    public static void Test() {
        int[] mice1 = { 1, 4, 9, 15 };
        int[] holes1 = { 10, -5, 0, 16 };
        Debug.Assert(MinimizeMaxDistance(mice1, holes1) == 6);

        int[] mice2 = { 1, 2, 3 };
        int[] holes2 = { 3, 2, 1 };
        Debug.Assert(MinimizeMaxDistance(mice2, holes2) == 0);

        int[] mice3 = { -10, 5, 0 };
        int[] holes3 = { -5, 5, 10 };
        Debug.Assert(MinimizeMaxDistance(mice3, holes3) == 5);

        int[] mice4 = { 2, 8, 3 };
        int[] holes4 = { 4, 7, 5 };
        Debug.Assert(MinimizeMaxDistance(mice4, holes4) == 2);

        Debug.Log("All test cases passed!");
    }
}