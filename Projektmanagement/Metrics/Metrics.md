# Metrics

The metric we want to keep an eye on in our project is source code complexity because all further improvements of our game rely on the quality of current source code. 
If our code is already of poor quality then we run the risk of not being able to maintain our code in the future.
We measure our source code complexity by using the following three metrics:

## Halstead’s program volume

Halstead’s software metrics can be used to estimate the size, complexity, and effort required to develop and maintain a software program. 
The program volume is the product of program length (N) and logarithm of vocabulary size (n), i.e., V = N*log2(n).
Proportional to program size it represents the size, in bits, of space necessary for storing the program.

For the program volume we calculated the sum of all operands and operators throughout our 38 classes as described in the definition of Haldsteads`s program value.
We then used these values to get an estimated volume of 1.057 KB for our game.

![grafik](https://github.com/Freaky2164/TowerDefense/assets/64361270/8ca74a71-1e98-4b6b-ab9f-ea17b2f43c72)

## Cyclomatic complexity

Cyclomatic complexity of a code section is the quantitative measure of the number of linearly independent paths in it. 
It is a software metric used to indicate the complexity of a program. It is computed using the Control Flow Graph of the program. 

For the cyclomatic complexity we calculated the value for every class itself and then we also calculated the average value which is 2.44.
With a value of 11 the BaseTower class is the most complex class in our game, but we also have 23 classes with only a complexity value of 1.

![grafik](https://github.com/Freaky2164/TowerDefense/assets/64361270/233b888b-5b28-4df5-8483-21f23a2064bc)

## Weighted methods per class (WMC)

This measures the sum of complexity of the methods in a class. 
A predictor of the time and effort required to develop and maintain a class we can use the number of methods and the complexity of each method.

For the weighted methods per class metric we calculated the number of methods of every class itself and then we also calulated the average value which is 4.34.
It shows a similiar image as the cyclomatic complexity with the Base Tower class having the highest value of 15.
With 10 the GameHandler has the second hightest value, which makes sense because most of our game depends on methods that these two classes provide.

![grafik](https://github.com/Freaky2164/TowerDefense/assets/64361270/06e9530f-ab9a-4847-8f74-c77660e92a13)
