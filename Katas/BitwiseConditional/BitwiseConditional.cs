using UnityEngine;

public class BitwiseConditional {
    public static int ConditionalReturn(int x, int y, int b) {
        return (x & -b) | (y & ~(~b + 1));
    }

    public static void Test() {
        Debug.Log(ConditionalReturn(5, 10, 1) == 5 ? "Test 1 Passed" : "Test 1 Failed");
        Debug.Log(ConditionalReturn(5, 10, 0) == 10 ? "Test 2 Passed" : "Test 2 Failed");
        Debug.Log(ConditionalReturn(-5, 7, 1) == -5 ? "Test 3 Passed" : "Test 3 Failed");
        Debug.Log(ConditionalReturn(-5, 7, 0) == 7 ? "Test 4 Passed" : "Test 4 Failed");
        Debug.Log(ConditionalReturn(0, 0, 1) == 0 ? "Test 5 Passed" : "Test 5 Failed");
    }
}