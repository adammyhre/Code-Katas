using UnityEngine;

public class WordSearch {
    static readonly int[][] Directions = {
        new[] { -1, 0 },
        new[] { 0, -1 },
        new[] { 1, 0 }, 
        new[] { 0, 1 }
    };

    public static bool Exist(char[,] board, string word) {
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);
        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                if (DoesWordExistFrom(board, word, row, col, 0)) {
                    return true;
                }
            }
        }

        return false;
    }

    static bool DoesWordExistFrom(char[,] board, string word, int row, int col, int index) {
        if (index == word.Length) return true;

        bool isCellInBoard = row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        bool isCellUnvisited = isCellInBoard && board[row, col] == word[index];
        if (!isCellUnvisited) return false;

        char temp = board[row, col];
        board[row, col] = '#'; // mark as visited

        foreach (var direction in Directions) {
            bool isFound = DoesWordExistFrom(board, word, row + direction[0], col + direction[1], index + 1);
            if (isFound) {
                board[row, col] = temp; // unmark
                return true;
            }
        }

        board[row, col] = temp; // unmark
        return false;
    }

    public static void Test() {
        char[,] board = {
            { 'F', 'A', 'C', 'I' },
            { 'O', 'B', 'Q', 'P' },
            { 'A', 'N', 'O', 'B' },
            { 'M', 'A', 'S', 'S' }
        };
        RunTest(board, "FOAM", true);
        RunTest(board, "MASS", true);
        RunTest(board, "FACI", true);
        RunTest(board, "BQP", true);
        RunTest(board, "NO", true);
        RunTest(board, "CAT", false);
    }

    static void RunTest(char[,] board, string word, bool expected) {
        bool result = Exist(board, word);
        Debug.Log(result == expected ? "Pass" : $"Fail: Expected {expected} but got {result} for word '{word}'");
    }
}