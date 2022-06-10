using LeetCodePuzzles.Helpers.Assert;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LeetCodePuzzles.Question.EasyWarmUp.Medium
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    /// <summary>
    /// https://leetcode.com/problems/add-two-numbers/
    /// You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
    ///    You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    ///    Example 1:
    ///Input: l1 = [2,4,3], l2 = [5,6,4]
    ///    Output: [7,0,8]
    ///    Explanation: 342 + 465 = 807.
    ///Example 2:
    ///Input: l1 = [0], l2 = [0]
    ///    Output: [0]
    ///    Example 3:
    ///Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
    ///    Output: [8,9,9,9,0,0,0,1]
    ///    Constraints:
    ///    The number of nodes in each linked list is in the range[1, 100].
    ///    0 <= Node.val <= 9
    ///    It is guaranteed that the list represents a number that does not have leading zeros.
    /// </summary>
    public class AddTwoNumbers : IQuestion
    {
        public void Run()
        {
            ///    Input: list1 = [2, 4, 3], list2 = [5, 6, 4]
            ///    Output: [7, 0, 8]
            var list1_head = new ListNode(2);
            var list1_node_1 = new ListNode(4);
            var list1_node_2 = new ListNode(3);
            list1_head.next = list1_node_1;
            list1_node_1.next = list1_node_2;
            var list2_head = new ListNode(5);
            var list2_node_1 = new ListNode(6);
            var list2_node_2 = new ListNode(4);
            list2_head.next = list2_node_1;
            list2_node_1.next = list2_node_2;
            var result_head = AddTwoNumbersFunction(list1_head, list2_head);
            Assert.AreEqual(7, result_head.val);
            Assert.AreEqual(0, result_head.next.val);
            Assert.AreEqual(8, result_head.next.next.val);



            ///    Input: list1 = [0], list2 = [0]
            ///    Output: [0]
            var list1_head_b = new ListNode(0);
            var list2_head_b = new ListNode(0);
            var result_head_b = AddTwoNumbersFunction(list1_head_b, list2_head_b);
            Assert.AreEqual(0, result_head_b.val);



            ///    Input: list1 = [9,9,9,9,9,9,9], list2 = [9,9,9,9]
            ///    Output: [8,9,9,9,0,0,0,1]
            var list1_head_c = new ListNode(9);
            var list1_node_1_c = new ListNode(9);
            var list1_node_2_c = new ListNode(9);
            var list1_node_3_c = new ListNode(9);
            var list1_node_4_c = new ListNode(9);
            var list1_node_5_c = new ListNode(9);
            var list1_node_6_c = new ListNode(9);
            list1_head_c.next = list1_node_1_c;
            list1_node_1_c.next = list1_node_2_c;
            list1_node_2_c.next = list1_node_3_c;
            list1_node_3_c.next = list1_node_4_c;
            list1_node_4_c.next = list1_node_5_c;
            list1_node_5_c.next = list1_node_6_c;
            var list2_head_c = new ListNode(9);
            var list2_node_1_c = new ListNode(9);
            var list2_node_2_c = new ListNode(9);
            var list2_node_3_c = new ListNode(9);
            list2_head_c.next = list2_node_1_c;
            list2_node_1_c.next = list2_node_2_c;
            list2_node_2_c.next = list2_node_3_c;
            var result_head_c = AddTwoNumbersFunction(list1_head_c, list2_head_c);
            Assert.AreEqual(8, result_head_c.val);
            Assert.AreEqual(9, result_head_c.next.val);
            Assert.AreEqual(9, result_head_c.next.next.val);
            Assert.AreEqual(9, result_head_c.next.next.next.val);
            Assert.AreEqual(0, result_head_c.next.next.next.next.val);
            Assert.AreEqual(0, result_head_c.next.next.next.next.next.val);
            Assert.AreEqual(0, result_head_c.next.next.next.next.next.next.val);
            Assert.AreEqual(1, result_head_c.next.next.next.next.next.next.next.val);

            ///    Input: list1 = [9], list2 = [1,9,9,9,9,9,9,9,9,9]
            ///    Output: [[0,0,0,0,0,0,0,0,0,0,1]
            var list1_head_d = new ListNode(9);
            var list2_head_d = new ListNode(1);
            var list2_node_1_d = new ListNode(9);
            var list2_node_2_d = new ListNode(9);
            var list2_node_3_d = new ListNode(9);
            var list2_node_4_d = new ListNode(9);
            var list2_node_5_d = new ListNode(9);
            var list2_node_6_d = new ListNode(9);
            var list2_node_7_d = new ListNode(9);
            var list2_node_8_d = new ListNode(9);
            var list2_node_9_d = new ListNode(9);
            list2_head_d.next = list2_node_1_d;
            list2_node_1_d.next = list2_node_2_d;
            list2_node_2_d.next = list2_node_3_d;
            list2_node_3_d.next = list2_node_4_d;
            list2_node_4_d.next = list2_node_5_d;
            list2_node_5_d.next = list2_node_6_d;
            list2_node_6_d.next = list2_node_7_d;
            list2_node_7_d.next = list2_node_8_d;
            list2_node_8_d.next = list2_node_9_d;
            var result_head_d = AddTwoNumbersFunction(list1_head_d, list2_head_d);
            Assert.AreEqual(0, result_head_d.val);
            Assert.AreEqual(0, result_head_d.next.val);
            Assert.AreEqual(0, result_head_d.next.next.val);
            Assert.AreEqual(0, result_head_d.next.next.next.val);
            Assert.AreEqual(0, result_head_d.next.next.next.next.val);
            Assert.AreEqual(0, result_head_d.next.next.next.next.next.val);
            Assert.AreEqual(0, result_head_d.next.next.next.next.next.next.val);
            Assert.AreEqual(0, result_head_d.next.next.next.next.next.next.next.val);
            Assert.AreEqual(0, result_head_d.next.next.next.next.next.next.next.next.val);
            Assert.AreEqual(0, result_head_d.next.next.next.next.next.next.next.next.next.val);
            Assert.AreEqual(1, result_head_d.next.next.next.next.next.next.next.next.next.next.val);
        }

        public ListNode AddTwoNumbersFunction(ListNode l1, ListNode l2)
        {
            BigInteger number_1 = GetNumber(l1);
            BigInteger number_2 = GetNumber(l2);
            BigInteger result = number_1 + number_2;

            List<ListNode> list = new List<ListNode>();
            while(result != 0)
            {
                var div = result % 10;
                result = result / 10;
                list.Add(new ListNode((int)div));
            }

            if(list.Count == 0)
            {
                list.Add(new ListNode(0));
            }

            var head = list[0];
            var current = head;
            for(int i = 1; i < list.Count; i++)
            {
                current.next = list[i];
                current = current.next;
            }
            return head;
        }

        private static BigInteger GetNumber(ListNode list)
        {
            BigInteger number = 0;
            BigInteger multiplicator = 1;
            while (list != null)
            {
                number += list.val * multiplicator;
                multiplicator *= 10;
                list = list.next;
            }

            return number;
        }
    }
}