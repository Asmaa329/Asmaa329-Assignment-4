# Greatest Common Divisor of Strings

- **Problem URL**: [https://leetcode.com/problems/greatest-common-divisor-of-strings/](https://leetcode.com/problems/greatest-common-divisor-of-strings/)
- **LeetCode Profile**: [https://leetcode.com/u/asmaadiab329/](https://leetcode.com/u/asmaadiab329/)

---

## Accepted Submission Screenshot

![Accepted Submission](LeetCode_Screenshot%20.png)

---

## Problem Description
For two strings `s` and `t`, we say "t divides s" if and only if `s = t + t + t + ... + t + t` (i.e., `t` is concatenated with itself one or more times).

Given two strings `str1` and `str2`, return *the largest string `x` such that `x` divides both `str1` and `str2`*.

---

## Approach & Complexity
- **Approach**: The core property tested here is that if two strings have a common divisor string, then concatenating them in either order should result in the same string (`str1 + str2 == str2 + str1`). If this condition holds true, the length of the greatest common divisor string will be the greatest common divisor (GCD) of the lengths of `str1` and `str2`.

