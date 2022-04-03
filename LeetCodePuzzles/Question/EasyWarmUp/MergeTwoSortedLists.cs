using LeetCodePuzzles.Helpers.Assert;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePuzzles.Question.EasyWarmUp
{
    /// <summary>
    /// https://leetcode.com/problems/merge-two-sorted-lists/
    /// 
    /// You are given the heads of two sorted linked lists list1 and list2.

    ///    Merge the two lists in a one sorted list.The list should be made by splicing together the nodes of the first two lists.
    ///
    ///
    ///    Return the head of the merged linked list.
    ///
    ///
    ///
    ///
    ///    Example 1:
    ///
    ///
    ///    Input: list1 = [1, 2, 4], list2 = [1, 3, 4]
    ///    Output: [1,1,2,3,4,4]
    ///
    ///Example 2:
    ///
    ///
    ///    Input: list1 = [], list2 = []
    ///    Output: []
    ///
    ///Example 3:
    ///
    ///
    ///    Input: list1 = [], list2 = [0]
    ///    Output: [0]
    /// </summary>

     // Definition for singly-linked list.
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


    public class MergeTwoSortedLists : IQuestion
    {
        public void Run()
        {
            ///    Input: list1 = [1, 2, 4], list2 = [1, 3, 4]
            ///    Output: [1,1,2,3,4,4]
            var list1_head = new ListNode(1);
            var list1_node_1 = new ListNode(2);
            var list1_node_2 = new ListNode(3);
            list1_head.next = list1_node_1;
            list1_node_1.next = list1_node_2;
            var list2_head = new ListNode(1);
            var list2_node_1 = new ListNode(3);
            var list2_node_2 = new ListNode(4);
            list2_head.next = list2_node_1;
            list2_node_1.next = list2_node_2;
            var result_head = MergeTwoLists(list1_head, list2_head);
            Assert.AreEqual(1, result_head.val);
            Assert.AreEqual(1, result_head.next.val);
            Assert.AreEqual(2, result_head.next.next.val);
            Assert.AreEqual(3, result_head.next.next.next.val);
            Assert.AreEqual(3, result_head.next.next.next.next.val);
            Assert.AreEqual(4, result_head.next.next.next.next.next.val);


            /// Input: list1 = [], list2 = []
            /// Output: []
            ListNode list1_head_2 = null;
            ListNode list2_head_2 = null;
            var result_head_2 = MergeTwoLists(list1_head_2, list2_head_2);
            Assert.IsTrue(result_head_2 == null);


            /// Input: list1 = [], list2 = [0]
            /// Output: [0]
            ListNode list1_head_3 = null;
            ListNode list2_head_3 = new ListNode(0);
            var result_head_3 = MergeTwoLists(list1_head_3, list2_head_3);
            Assert.AreEqual(0, result_head_3.val);
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if(list1 == null)
            {
                return list2;
            }

            if(list2 == null)
            {
                return list1;
            }

            if(list1.val < list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists(list1, list2.next);
                return list2;
            }
        }

        public ListNode MergeTwoListsIterative(ListNode list1, ListNode list2)
        {
            if(list1 == null)
            {
                return list2;
            }

            if(list2 == null)
            {
                return list1;
            }

            ListNode head = null;
            if(list1.val < list2.val)
            {
                head = list1;
                list1 = list1.next;
            }
            else
            {
                head = list2;
                list2 = list2.next;
            }

            ListNode current = head;
            while(list1 != null && list2 != null)
            {
                if(list1.val < list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }
                current = current.next;
            }

            current.next = list1 == null ? list2 : list1;

            return head;
        }
    }
}
