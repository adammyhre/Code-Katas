using System;
using UnityEngine;

public static class PathCounter {
    static long BinomialCoefficient(int n, int k) {
        if (k > n - k) {
            k = n - k;
        }

        long result = 1;
        for (int i = 0; i < k; i++) {
            result *= n - i;
            result /= i + 1;
        }

        return result;
    }

    public static long CountUniquePaths(int N, int M) {
        if (N <= 0 || M <= 0)
            throw new ArgumentException("Matrix dimensions must be positive integers.");

        return BinomialCoefficient(N + M - 2, N - 1);
    }

    public static void Test() {
        Debug.Assert(CountUniquePaths(2, 2) == 2, "Test failed for 2x2 matrix.");
        Debug.Assert(CountUniquePaths(5, 5) == 70, "Test failed for 5x5 matrix.");
        Debug.Assert(CountUniquePaths(3, 4) == 10, "Test failed for 3x4 matrix.");
        Debug.Log("All tests passed.");
    }
}