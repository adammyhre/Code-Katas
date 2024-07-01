using UnityEngine;

public static class PartitionMultiset {
    public static bool CanPartition(int[] nums) {
        int totalSum = 0;
        foreach (var num in nums) totalSum += num;

        // If total sum is odd, it's not possible to partition into two equal subsets
        if (totalSum % 2 != 0) return false;

        int targetSum = totalSum / 2;
        bool[] dp = new bool[targetSum + 1];
        dp[0] = true;

        foreach (var num in nums) {
            for (int i = targetSum; i >= num; i--) {
                dp[i] = dp[i] || dp[i - num];
            }
        }

        return dp[targetSum];
    }

    public static void Test() {
        int[] multiset1 = { 15, 5, 20, 10, 35, 15, 10 };
        int[] multiset2 = { 15, 5, 20, 10, 35 };

        Debug.Log("Test Case 1: " + CanPartition(multiset1)); // Expected: True
        Debug.Log("Test Case 2: " + CanPartition(multiset2)); // Expected: False
    }
}