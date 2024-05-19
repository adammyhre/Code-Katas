using UnityEngine;

public class ReverseIntegerKata {
    public static int ReverseInteger(int x) {
        long result = 0;
        while (x != 0) {
            int lastDigit = x % 10;
            x /= 10;
            if (result > int.MaxValue / 10
                || (result == int.MaxValue / 10 && lastDigit > 7)
                || result < int.MinValue / 10
                || (result == int.MinValue / 10 && lastDigit < -8)) 
            {
                return 0;
            }

            result = result * 10 + lastDigit;
        }
        return (int)result;
    }

    public static void Test() {
        void TestReverseInteger(int input, int expected) {
            var result = ReverseInteger(input);
            Debug.Log($"Input: {input}, Expected: {expected}, Result: {(result == expected ? "Passed" : "Failed")}");
        }

        TestReverseInteger(123, 321);
        TestReverseInteger(-123, -321);
        TestReverseInteger(2000000000, 2);
        TestReverseInteger(-2000000000, -2);
        TestReverseInteger(1534236469, 0); // 9646324351 is greater than int.MaxValue
        TestReverseInteger(-1534236469, 0); // -9646324351 is less than int.MinValue
        TestReverseInteger(0, 0);
        TestReverseInteger(100, 1);
    }
}