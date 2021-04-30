

**PERFORMANCE OPTIMIZATION 101**


*What we will cover*

• Measuring Application and code performance

• Little bit about Benchmark.NET

• Little bit about Bogus

• StringBuilder vs String

• Date Time Parsing

• Struct vs Class

• Is Clean code actually slower ?

• Is LINQ actually slower ?

• When to use ValueTask instead of Task and save precious memory ?

• Span<T>, Read Only Span<T>

• Array Pool

• Concept of Lowering


**BenchmarkDotNet**

A Benchmark is a test that you run to measure how fast your code is..

https://github.com/dotnet/BenchmarkDotNet

https://benchmarkdotnet.org/articles/overview.html

Install-Package BenchmarkDotNet


**Bogus** 

will help you load databases, UI and apps with fake data for your testing needs

https://github.com/bchavez/Bogus

Install-Package Bogus

For NodeJS people! https://github.com/marak/Faker.js/

**Struct Vs Class**

**structs** have several benefits when it comes to deallocation:

When structs are not part of a class, they are allocated on the **Stack** and don’t require garbage collection at all (stack unwinding).


Full guidelines from Microsoft https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/choosing-between-class-and-struct

guidelines/choosing-between-class-and-struct - https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/choosing-between-class-and-struct

**Is Clean code actually slower ?**
**Is LINQ actually slower ?**
**When to use Value Task instead of Task and save precious memory ?**


**Span<T>**

System.Memory package built into .NetCore 2.1

Read/write ‘view’ over a contiguous region of memory

Heap (managed objects) – Arrays, Strings

Stack (via stackalloc)

Native / unmanaged

 index / iterate to modify the memory within the span

Almost no overhead



**ArrayPool**

Pool of array for re-use

Found in System.Buffers.

ArrayPool<T>.Shared.Rent(int length)

You are likely to get an array larger than your minimum size

ArrayPool<T>.Shared.Return(T[] array, bool ClearArray = false)



**Lowering**   <https://sharplab.io/>

1. Loops
2. Switch
3. Record
4. Var keyword
5. Using Keyword
6. Async Task



**Summary**

1. Measure, don’t assume.
2. Be scientific
3. Make small changes each time and measure again
4. Performance is contextual
5. Performance should be part of every story
6. Focus on hot paths
7. Use StringBuilder for heavy string operations
8. Use ValueTask
9. Understand the Pre-compiling phase (lowering)
10. Avoid LINQ in hot paths
11. Clean code is always good.
12. Don’t copy memory, slice it. Span<T> is less complex than it may first seem.
13. Use ArrayPools where appropriate to reduce array allocations