# Performance-Optimization-101


Measure, don’t assume.
Be scientific
Make small changes each time and measure again
Performance is contextual
Performance should be part of every story
Focus on hot paths
Use StringBuilder for heavy string operations
Use ValueTask
Understand the Pre-compiling phase (lowering)
Avoid LINQ in hot paths
Clean code is always good.
Don’t copy memory, slice it. Span<T> is less complex than it may first seem.
Use ArrayPools where appropriate to reduce array allocations
