using UnityEngine;

public class FibonacciSequence 
{
    // Using Binet's formula to calculate n-th fibonacci number
    // https://en.wikipedia.org/wiki/Fibonacci_sequence#Binet's_formula
    public static int Binet(int n) {
        if (n <= 1) return n;

        var sqrt5 = Mathf.Sqrt(5);
        var phi = (1 + sqrt5) / 2; 
        return (int) Mathf.Round(Mathf.Pow(phi, n) / sqrt5); 
    }

    // Iteratively calculate the n-th fibonacci number
    public static int Fib(int n) {
        if (n <= 1) return n;
        
        int a = 0, b = 1;

        for (int i = 1; i < n; i++) {
            b = a + b;
            a = b - a;
        }

        return b;
    }

    public static void Test() {
        TestBinetMethod();
        TestFibMethod();
    }

    static void TestBinetMethod() {
        AssertEqual(Binet(0), 0);
        AssertEqual(Binet(1), 1);
        AssertEqual(Binet(2), 1);
        AssertEqual(Binet(3), 2);
        AssertEqual(Binet(10), 55);
    }

    static void TestFibMethod() {
        AssertEqual(Fib(0), 0);
        AssertEqual(Fib(1), 1);
        AssertEqual(Fib(2), 1);
        AssertEqual(Fib(3), 2);
        AssertEqual(Fib(10), 55);
    }

    static void AssertEqual(int actual, int expected) {
        if (actual != expected) {
            Debug.LogError("Expected " + expected + " but got " + actual);
        }
    }
}