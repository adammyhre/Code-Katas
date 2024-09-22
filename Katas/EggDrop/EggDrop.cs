using UnityEngine;

public static class EggDrop {

    public static int CalculateEggDrop(int n, int k) {
        int[,] dp = new int[n + 1, k + 1];

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= k; j++) {
                dp[i, j] = j;
            }
        }

        for (int i = 2; i <= n; i++) {
            for (int j = 1; j <= k; j++) {
                dp[i, j] = int.MaxValue;
                for (int x = 1; x <= j; x++) {
                    int res = 1 + Mathf.Max(dp[i - 1, x - 1], dp[i, j - x]);
                    dp[i, j] = Mathf.Min(dp[i, j], res);
                }
            }
        }

        return dp[n, k];
    }

    public static void Test() {
        int n1 = 1, k1 = 5;
        Debug.Assert(CalculateEggDrop(n1, k1) == 5, "Test 1 Failed");

        int n2 = 2, k2 = 10;
        Debug.Assert(CalculateEggDrop(n2, k2) == 4, "Test 2 Failed");

        int n3 = 3, k3 = 14;
        Debug.Assert(CalculateEggDrop(n3, k3) == 4, "Test 3 Failed");

        Debug.Log("All tests passed!");
    }
}