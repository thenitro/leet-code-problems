﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OnlineMajorityElementInSubarray
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var mc = new MajorityChecker(new[] {1, 1, 2, 2, 1, 1});
            Console.WriteLine(1 == mc.Query(0, 5, 4));
            Console.WriteLine(-1 == mc.Query(0, 3, 3));
            Console.WriteLine(2 == mc.Query(2, 3, 2));
        }
    }
}

public class MajorityChecker
{
    private class StNode
    {
        public int Majority;
        public int Count;
        public int L;
        public int R;

        public StNode Left;
        public StNode Right;

        public StNode(int l, int r)
        {
            L = l;
            R = r;
            Majority = 0;
            Count = 0;
        }

        public void PushDown()
        {
            if (L == R)
            {
                return;
            }

            if (Left == null)
            {
                var mid = (L + R) >> 1;
                Left = new StNode(L, mid);
                Right = new StNode(mid + 1, R);
            }
        }

        public void UpdateByVal(int majority, int count)
        {
            Majority = majority;
            Count = count;
        }

        public void UpdateFromSon()
        {
            if (Left.Majority == Right.Majority)
            {
                Majority = Left.Majority;
                Count = Left.Count + Right.Count;
            }
            else
            {
                Majority = Left.Count >= Right.Count ? Left.Majority : Right.Majority;
                Count = Math.Abs(Left.Count - Right.Count);
            }
        }
    }

    private StNode _root;
    private Dictionary<int, List<int>> _idx;
    
    public MajorityChecker(int[] arr)
    {
        _root = new StNode(0, arr.Length - 1);
        _idx = new Dictionary<int, List<int>>();

        for (int i = 0; i < arr.Length; i++)
        {
            var num = arr[i];
            var subArr = _idx.ContainsKey(num) ? _idx[num] : new List<int>();
                subArr.Add(i);
            
            _idx[num] = subArr;

            UpdateSingle(_root, i, arr[i]);
        }
    }

    private void UpdateSingle(StNode root, int pos, int val)
    {
        if (root.L == root.R)
        {
            root.UpdateByVal(val, 1);
            return;
        }

        var mid = (root.L + root.R) >> 1;
        root.PushDown();
        if (pos <= mid)
        {
            UpdateSingle(root.Left, pos, val);
        }
        else
        {
            UpdateSingle(root.Right, pos, val);
        }
        
        root.UpdateFromSon();
    }

    public int Query(int left, int right, int threshold)
    {
        var majority = new int[1];
        var count = new [] { -1 };

        QueryHelper(_root, left, right, majority, count);

        var freq = GetFreq(majority[0], left, right);
        return freq >= threshold ? majority[0] : -1;
    }

    private void QueryHelper(StNode root, int left, int right, int[] majority, int[] count)
    {
        if (root.R < left || root.L > right)
        {
            return;
        }

        if (left <= root.L && root.R <= right)
        {
            MergeQuery(majority, count, root.Majority, root.Count);
            return;
        }

        QueryHelper(root.Left, left, right, majority, count);
        QueryHelper(root.Right, left, right, majority, count);
    }

    private void MergeQuery(int[] majority, int[] count, int curM, int curC)
    {
        if (count[0] == -1)
        {
            majority[0] = curM;
            count[0] = curC;
        } 
        else if (majority[0] == curM)
        {
            count[0] += curC;
        }
        else
        {
            majority[0] = count[0] >= curC ? majority[0] : curM;
            count[0] = Math.Abs(count[0] - curC);
        }
    }

    private int GetFreq(int target, int left, int right)
    {
        var index = _idx[target];

        var rightIdx = FindIdx(index, right);
        var leftIdx = FindIdx(index, left);

        if (rightIdx < 0)
        {
            return 0;
        }
        else if (leftIdx < 0)
        {
            return rightIdx - leftIdx;
        }
        else if (index[leftIdx] == left)
        {
            return rightIdx - leftIdx + 1;
        }
        else
        {
            return rightIdx - leftIdx;
        }
    }

    private int FindIdx(List<int> idx, int pos)
    {
        var start = 0;
        var end = idx.Count - 1;
        var mid = 0;

        while (start <= end)
        {
            mid = (start + end) >> 1;
            
            if (idx[mid] < pos)
            {
                start = mid + 1;
            } 
            else if (idx[mid] > pos)
            {
                end = mid - 1;
            }
            else
            {
                return mid;
            }
        }

        return end;
    }
}