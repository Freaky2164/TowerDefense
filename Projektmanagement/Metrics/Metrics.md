# Metrics

The metric we want to keep an eye on in our project is source code complexity because all further improvements of our game rely on the quality of current source code. 
If our code is already of poor quality then we run the risk of not being able to maintain our code in the future.

<br>

We measure our source code complexity by using the following three metrics:

## Halstead’s program volume

Halstead’s software metrics can be used to estimate the size, complexity, and effort required to develop and maintain a software program. 
The program volume is the product of program length (N) and logarithm of vocabulary size (n), i.e., V = N*log2(n).
Proportional to program size it represents the size, in bits, of space necessary for storing the program.

## Cyclomatic complexity

Cyclomatic complexity of a code section is the quantitative measure of the number of linearly independent paths in it. 
It is a software metric used to indicate the complexity of a program. It is computed using the Control Flow Graph of the program. 

## Weighted methods per class (WMC)

This measures the sum of complexity of the methods in a class. 
A predictor of the time and effort required to develop and maintain a class we can use the number of methods and the complexity of each method.
