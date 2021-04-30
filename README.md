

**PERFORMANCE OPTIMIZATION 101**

A Benchmark is a test that you run to measure how fast your code is..

https://github.com/dotnet/BenchmarkDotNet

https://benchmarkdotnet.org/articles/overview.html

Install-Package BenchmarkDotNet


**Bogus** 

will help you load databases, UI and apps with fake data for your testing needs

https://github.com/bchavez/Bogus

Install-Package Bogus

For NodeJS people! https://github.com/marak/Faker.js/

Full guidelines from Microsoft https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/choosing-between-class-and-struct
guidelines/choosing-between-class-and-struct - https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/choosing-between-class-and-struct

https://sharplab.io/

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