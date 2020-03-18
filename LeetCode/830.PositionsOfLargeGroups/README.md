# Positions of Large Groups

https://leetcode.com/problems/positions-of-large-groups/

In a string S of lowercase letters, these letters form consecutive groups of the same character.  

For example, a string like S = "abbxxxxzyy" has the groups "a", "bb", "xxxx", "z" and "yy".  

Call a group large if it has 3 or more characters.  We would like the starting and ending positions of every large group.  

The final answer should be in lexicographic order.  
 
**Example 1:**  
```  
Input: "abc"
Output: []
Explanation: We have "a","b" and "c" but no large group.
```  

**Example 2:**  
```  
Input: "abcdddeeeeaabbbcd"
Output: [[3,5],[6,9],[12,14]]
```  