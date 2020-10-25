# Introduction
A basic command line application to apply correlation calculations to any two distinct columns.

# Usage

Just need to call the application and answer to the prompt questions, or provide all necessary parameters on the command line.

```
PS C:\projectdir> CorrelationCalculator.exe
Please provide the measurement's filename: data-file.csv
Please provide the first column name: Drink
Please provide the second column name: Age
The Linear Correlation value is 0.39953299615098076
The Spearman Correlation value is 0.672727272727272
The Kendall Correlation value is 0.5111111111111111
 
```


# Extending it

Currently it supports linear, Spearman and Kendall correlation algorithms.

Additionally it is possible to define other algorithms by implementing the `CorrelationEvaluator` interface.


# Building it

Currently it is a plain .NET Framework 4.8 application, no idea if I will bother bringing it forward to Core.

Just use Visual Studio or MsBuild on the solution file.