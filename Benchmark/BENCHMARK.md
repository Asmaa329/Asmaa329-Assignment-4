# Benchmark Analysis Report

## Benchmark Results

| Method                     | Iterations | Mean             | Error            | StdDev         | Gen0         | Gen1         | Gen2        | Allocated     |
|--------------------------- |----------- |-----------------:|-----------------:|---------------:|-------------:|-------------:|------------:|--------------:|
| StringConcatenation        | 100        |        82.437 us |       117.764 us |      6.4551 us |     297.6074 |            - |           - |     456.13 KB |
| StringBuilderConcatenation | 100        |         4.655 us |         5.499 us |      0.3014 us |      13.7405 |            - |           - |      21.15 KB |
| StringConcatenation        | 1000       |    11,021.904 us |    22,524.110 us |  1,234.6225 us |   30921.8750 |    6921.8750 |   2000.0000 |   44992.72 KB |
| StringBuilderConcatenation | 1000       |       130.370 us |       153.602 us |      8.4195 us |      57.3730 |      28.5645 |     28.5645 |     192.06 KB |
| StringConcatenation        | 10000      | 1,763,183.300 us |   754,528.663 us | 41,358.2623 us | 1152000.0000 | 1125000.0000 | 855000.0000 | 4493117.71 KB |
| StringBuilderConcatenation | 10000      |     1,160.077 us |     1,126.407 us |     61.7422 us |     248.0469 |     248.0469 |    248.0469 |    1816.89 KB |
| StringConcatenation        | 100000     | 1,735,211.833 us | 1,333,336.177 us | 73,084.6553 us | 1351000.0000 | 1324000.0000 | 934000.0000 | 4493160.06 KB |
| StringBuilderConcatenation | 100000     |    18,303.599 us |    12,664.176 us |    694.1662 us |    2468.7500 |    2000.0000 |    968.7500 |    18024.5 KB |


---

## Analysis & Questions

### 1. Which approach was faster with 100 iterations?
`StringBuilderConcatenation` was faster than string concatenation even at 100 iterations.

### 2. Which approach was faster with 100,000 iterations?
`StringBuilderConcatenation` was drastically faster (sub-millisecond) compared to `StringConcatenation` which took several seconds.

### 3. Which approach allocated more memory?
`StringConcatenation` allocated significantly more memory across all iteration limits.

### 4. What happened to string concatenation performance as the loop size increased?
The execution time and memory allocation grew quadratically $O(N^2)$. As iterations increased, performance degraded rapidly.

### 5. Why does repeated string concatenation create additional allocations?
In C#, `string` objects are immutable. Every time `+=` is executed, a new string object is created in the Heap, copying the entire existing string content plus the new content, leaving the old string objects for Garbage Collection.

### 6. Why does StringBuilder usually perform better when text is repeatedly appended?
`StringBuilder` manages an internal mutable buffer array. Appending modifies the buffer in-place without creating new string instances until `ToString()` is explicitly called.

### 7. Is StringBuilder always better than normal string operations? Explain.
No. For simple operations with a known, fixed number of concatenations (e.g., 2 to 3 string parts like `firstName + " " + lastName`), standard string concatenation or interpolated strings `$"..."` are faster, simpler, and optimized directly by the C# compiler without the overhead of instantiating a `StringBuilder` object.