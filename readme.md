# Bobo vs Bellman

## History
When I was in the 9th grade, and just leaning to program, I wrote a program to determine a letter grade from a percentage.
My teacher, Mr. Bellman, called it out as a very bad example of how to write a complicated if statement.

He wasn't wrong, but I felt that my solution would still be slightly better than his in some situations. Specifically, 
it would have fewer comparisons, depending on the input data.

30 years later, I finally got around to testing that theory. 

## Conclusion
If the grades are evenly distributed from 0-100, then my solution has fewer comparisons.  
However, if the grades are distributed normally around a particular percentage (75% for a C, for example), then his
solution is better.

In short, Mr. Bellman's solution is far easier to read than mine (I've made it harder here to count the comparisons), 
but may require more comparisons. The if statement can be adjusted and optimized based on what you know about the dataset.

In production code, don't use my solution unless you REALLY need optimizations. It's weird and would be tough to maintain.