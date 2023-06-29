# CI/CD Summary

Because of the nature of Unity it was not possible for us to set up a pipeline that automatically builds our Unity game and runs our tests. 
What follows is a quick run down of the tools that we tested and why they didnt work.

## Unity Build Automation
Unity itself provides a CI/CD solution for their customers. The big problem is that this service would require us to pay a certain monthly fee, that we didnt want to do.

## Jenkins
Our second approach was to set up a pipeline using Jenkins. This could potentially work when everything is set up on a local machine of our team members with Unity already installed. However the problem is that we don't have an additional server the pipeline could run on. Instead someone would have to manually trigger the pipeline to run on their machine. This means that we wouldn't have an automated pipeline that builds and runs our tests whenever someone changes something in our project. Thus defeating the whole purpose of the automation.

## Travis CI and CircleCI
We also looked into two other CI/CD solutions Travis CI and Circle CI. Both are free and it was possible for us connect them to our repository. Unfortunately they do not have any kind of support for Unity games, so we couldn't use them either.

## Game CI
The closest we got to a suitable solution was with help of Game CI. Game CI is an organization that tries to provide free CI/CD for game developers. It can be used with GitHub Actions, GitLab or CircleCI. For our project we looked into setting everything up with GitHub Actions and CircleCI. We follwed their documentation until we had to aquire a license from Unity that the pipeline needs in order to run correctly. For some reason, probably a bug somewhere, Unity doesn't want to give us this license file and so once again we couldn't claim victory after this long and frustrating battle.

<br>

For our alternative solution we decided to only test our C# scripts since the business logic itself can be split from the rest of our code that is dependent on the Unity environment.
To implement this we created a seperate .NET project which encompasses our logic for the money handling in our game aswell as some tests to ensure that the logic works correctly.
Using GitHub Actions we then integrated this project into our github repository which then automatically builds the projects and runs the tests.

