using System;
using System.Collections.Generic;
using UnityEngine;

public class Polygon {
    readonly List<(int x, int y)> points;

    public Polygon(List<(int, int)> points) {
        this.points = points;
    }

    // https://en.wikipedia.org/wiki/Point_in_polygon
    // Method to determine if a point is inside the polygon
    public bool IsPointInside((int x, int y) point) {
        int n = points.Count;
        bool result = false;

        // Loop through each edge of the polygon
        for (int i = 0, j = n - 1; i < n; j = i++) {
            // Check if the point is on an edge (return false if it is)
            if (IsPointOnEdge(point, points[i], points[j])) {
                return false;
            }

            // Check if a point is inside a polygon using ray-casting
            // Determine if the test point is between the y-coordinates of an edge (one point is above and one is below the test point)
            if (points[i].y > point.y != points[j].y > point.y &&
                // Find where the horizontal line through the test point intersects the edge
                // Check if the test point's x-coordinate is to the left of this intersection point
                point.x < (points[j].x - points[i].x) * (point.y - points[i].y) / (float)(points[j].y - points[i].y) + points[i].x)
            {
                // If the ray crosses an edge, flip the inside/outside state
                // Odd number of crossings means inside, even number means outside
                result = !result;
            }
        }

        return result;
    }

    // Check if point p is on the line segment from a to b
    bool IsPointOnEdge((int x, int y) p, (int x, int y) a, (int x, int y) b) {
        // Find the smallest and largest x and y values of a and b
        int minX = Math.Min(a.x, b.x);
        int maxX = Math.Max(a.x, b.x);
        int minY = Math.Min(a.y, b.y);
        int maxY = Math.Max(a.y, b.y);

        // Calculate if p, a, and b are in a straight line
        float determinant = (b.x - a.x) * (p.y - a.y) - (b.y - a.y) * (p.x - a.x);

        // Check if p is on the line and between a and b
        return Math.Abs(determinant) < Mathf.Epsilon &&
               p.x >= minX && p.x <= maxX &&
               p.y >= minY && p.y <= maxY;
    }

    public static void Test() {
        var triangle = new Polygon(new List<(int, int)> { (2, 2), (6, 5), (2, 5) });
        var concavePolygon = new Polygon(new List<(int, int)> { (1, 1), (3, 3), (1, 6), (4, 6), (6, 3), (4, 1) });
        var irregularPolygon = new Polygon(new List<(int, int)> { (0, 0), (2, 3), (1, 6), (5, 7), (8, 4), (7, 2), (4, 0) });

        var testCases = new List<((int, int) point, Polygon polygon, bool expected)> {
            ((3, 4), triangle, true), // Inside
            ((2, 2), triangle, false), // Boundary
            ((5, 5), triangle, false), // Outside

            ((2, 3), concavePolygon, true), // Inside
            ((1, 1), concavePolygon, false), // Boundary
            ((5, 5), concavePolygon, false), // Outside

            ((4, 3), irregularPolygon, true), // Inside
            ((0, 0), irregularPolygon, false), // Boundary
            ((6, 6), irregularPolygon, false), // Outside
        };

        foreach (var testCase in testCases) {
            bool result = testCase.polygon.IsPointInside(testCase.point);
            Debug.Assert(result == testCase.expected, 
                $"Test failed: Point {testCase.point} in polygon: {testCase.polygon} - Expected: {testCase.expected}, Result: {result}");
        }
    }
}