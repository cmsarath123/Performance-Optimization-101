

**PERFORMANCE**

**OPTIMIZATION 101**

Gislen Software





What we will cover

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





Aspects of Performance





A Benchmark is a test that you run to measure how fast your code is..

ü[~~https://github.com/dotnet/BenchmarkDotNet~~](https://github.com/dotnet/BenchmarkDotNet)

ü[~~https://benchmarkdotnet.org/articles/overview.html~~](https://benchmarkdotnet.org/articles/overview.html)

üInstall-Package BenchmarkDotNet





Bogus for .NET

**Bogus** will help you load databases, UI and apps with fake

data for your testing needs

ü[~~https://github.com/bchavez/Bogus~~](https://github.com/bchavez/Bogus)

üInstall-Package Bogus

üFor NodeJS people! [~~https://github.com/marak/Faker.js/~~](https://github.com/marak/Faker.js/)





Demo





StringBuilder vs String





Date Time Parser





Struct Vs Class

**structs** have several benefits when it comes to deallocation:

When structs are not part of a class, they are allocated on the **Stack** and don’t require garbage

collection at all (stack unwinding).

Structs [take](https://adamsitnik.com/Value-Types-vs-Reference-Types/)[ ](https://adamsitnik.com/Value-Types-vs-Reference-Types/)[less](https://adamsitnik.com/Value-Types-vs-Reference-Types/)[ ](https://adamsitnik.com/Value-Types-vs-Reference-Types/)[memory](https://adamsitnik.com/Value-Types-vs-Reference-Types/)[ ](https://adamsitnik.com/Value-Types-vs-Reference-Types/)than a reference type because they don’t have an **ObjectHeader** and

a **MethodTable**.

**Full guidelines from Microsoft [https://docs.microsoft.com/en-us/dotnet/standard/design-**](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/choosing-between-class-and-struct)**

[**guidelines/choosing-between-class-and-struct**](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/choosing-between-class-and-struct)





Is Clean code actually slower ?





Is LINQ actually slower ?





When to use Value Task

instead of Task and save

precious memory ?





Span<T>

üSystem.Memory package built into .NetCore 2.1

üRead/write ‘view’ over a contiguous region of memory

Heap (managed objects) – Arrays, Strings

Stack (via stackalloc)

Native / unmanaged

ü index / iterate to modify the memory within the span

üAlmost no overhead





Span<T>





Working with strings





ArrayPool

üPool of array for re-use

üFound in System.Buffers.

üArrayPool<T>.Shared.Rent(int length)

üYou are likely to get an array larger than your minimum size

üArrayPool<T>.Shared.Return(T[] array, bool ClearArray = false)





Lowering

<https://sharplab.io/>

ü Loops

ü Switch

ü Record

ü Var keyword

ü Using Keyword

ü Async Task





State Machine





Summary

üMeasure, don’t assume.

üBe scientific

üMake small changes each time and measure again

üPerformance is contextual

üPerformance should be part of every story

üFocus on hot paths

üUse StringBuilder for heavy string operations

üUse ValueTask

üUnderstand the Pre-compiling phase (lowering)

üAvoid LINQ in hot paths

üClean code is always good.

üDon’t copy memory, slice it. Span<T> is less complex than it may first seem.

üUse ArrayPools where appropriate to reduce array allocations





Thanks for listening

sarathkumarc@Gislen.com

