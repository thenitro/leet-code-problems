﻿namespace QuadTreeIntersection
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}

public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node(){}
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
}

public class Solution {
    public Node Intersect(Node quadTree1, Node quadTree2) 
    {
        if (quadTree1.isLeaf && quadTree2.isLeaf)
        {
            return new Node(quadTree1.val || quadTree2.val, true, null, null, null, null);
        }

        var topLeft1 = quadTree1.isLeaf ? quadTree1 : quadTree1.topLeft;
        var topRight1 = quadTree1.isLeaf ? quadTree1 : quadTree1.topRight;
        var bottomLeft1 = quadTree1.isLeaf ? quadTree1 : quadTree1.bottomLeft;
        var bottomRight1 = quadTree1.isLeaf ? quadTree1 : quadTree1.bottomRight;

        var topLeft2 = quadTree2.isLeaf ? quadTree2 : quadTree2.topLeft;
        var topRight2 = quadTree2.isLeaf ? quadTree2 : quadTree2.topRight;
        var bottomLeft2 = quadTree2.isLeaf ? quadTree2 : quadTree2.bottomLeft;
        var bottomRight2 = quadTree2.isLeaf ? quadTree2 : quadTree2.bottomRight;

        var topLeft = Intersect(topLeft1, topLeft2);
        var topRight = Intersect(topRight1, topRight2);
        var bottomLeft = Intersect(bottomLeft1, bottomLeft2);
        var bottomRight = Intersect(bottomRight1, bottomRight2);

        if (topLeft.isLeaf && topRight.isLeaf &&
            bottomLeft.isLeaf && bottomRight.isLeaf &&
            topLeft.val == topRight.val &&
            topLeft.val == bottomLeft.val &&
            topLeft.val == bottomRight.val)
        {
            return new Node(topLeft.val, true, null, null, null, null);
        }
        
        return new Node(false, false, topLeft, topRight, bottomLeft, bottomRight);
    } 
}