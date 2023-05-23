# Test plan

## 1.	Introduction

Tests are like little superheroes for software development. They're there to catch bugs before they appear on your productive code. By writing tests that check individual parts of code, you can be sure they're doing what they're supposed to do. These tests not only boost your confidence when making changes but also help you avoid introducing new bugs. Plus, they make your code easier to understand and collaborate on. So, they're your secret weapon for maintaining high-quality, reliable code.

## 2. Test Strategy

In our case we don t had any other choice for our project than using the in Unity included Unity-test framework. As far as we need to test unity components, like our gameobject (e.g. Turrets, Enemies..) or our Main Menu (e.g. Buttons...) the integrated test framework was the easiest and best choice for us, because its already in our engine included and provides all neccessary features. To include CI/CD we tryed several things but couldn t find any free and simple tool to automate the test process. The issue is here on the Unity components, which can t be effiently tested from other tools. So we decided to only automate our tests which not include Unity components. For that we created an extra Project that runs the test each time we commit. 


## 3. Test Plan


## 4. Test Cases

## 5. Test Results

## 6. Metrics

## 7. Recommendations

## 8. Conclusion


