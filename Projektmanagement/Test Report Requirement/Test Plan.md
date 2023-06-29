# Test plan

## 1.	Introduction

### 1.1	Purpose
The purpose of the Evaluation Summary is to gather all of the information necessary to plan and control the test effort for a given iteration. 
It describes the approach to testing the software.
This Test Plan for TowerDefense supports the following objectives:
-	Identifies the items that should be targeted by the tests.
-	Identifies the motivation for and ideas behind the test areas to be covered.
-	Outlines the testing approach that will be used.
-	Identifies the required resources and provides an estimate of the test efforts.

### 1.2	Scope
This document describes the used unit tests in C#.

We could not cover our game as a whole in tests, because of licensing issues with Unity. Therefor we can only assure the raw functionality of our C# scripts.

### 1.3	Definitions, Acronyms, and Abbreviations
This document is meant for internal use primarily.

### 1.4 References
| Title                                                              | Date       | Publishing organization   |
| -------------------------------------------------------------------|:----------:| ------------------------- |
| [TowerDefense Blog](https://github.com/argastle/TowerDefense/discussions)   | 20.10.2022 | TowerDefense Team    |
| [GitHub](https://github.com/argastle/TowerDefense)              | 20.10.2022 | TowerDefense Team    |

### 1.5 Document structure
n/a

## 2. Evaluation Mission and Test Motivation

### 2.1 Background

Testing serves to ensure that the written code does what it is intended to do. It also prevents future code changes to break existing functionality unnoticed. In the context of integration it can also prevent broken software states to be merged into secured VC branches.

### 2.2 Evaluation Mission

Testing is a crucial phase in the development cycle. It is necessary in order to fix technical bugs and important functional problems. With TDD we define the test first and can fix bugs before they even occur.

### 2.3 Test Motivators

The tests are done to ensure quality and mitigate risks and fulfill functional requirements. Their purpose is to provide stability for our game.

## 3. Target Test Items

- C# scripts

## 4. Outline of Planned Tests
The tests assure the correct functionality of the calculations of the player health, enemy health and the money for buying and upgrading towers.

### 4.1 Outline of Test Inclusions

- Player health
- Enemy health
- Money
- Tower upgrades

### 4.2 Outline of Other Candidates for Potential Inclusion

n/a

### 4.3 Outline of Test Exclusions

Because of time and resource constraints we will not do:

- Stress test
- Performance tests

## 5. Test Approach

### 5.1 Testing Techniques and Types

#### 5.1.1 Unit Testing

|                       | Description                                                         |
|-----------------------|---------------------------------------------------------------------|
|Technique Objective    | Ensure that the implemented code works as expected                  |
|Technique              | Implement test methods using .NET Core Framework                    |
|Oracles                | Test execution logs results to the command line, logs in Github Actions |
|Required Tools         | .NET Core Dependency                   |
|Success Criteria       | All tests pass. Coverage is above 90%   |

## 6. Entry and Exit Criteria

### 6.1 Test Plan

#### 6.1.1 Test Plan Entry Criteria

n/a

#### 6.1.2 Test Plan Exit Criteria

n/a

## 7. Deliverables

## 7.1 Test Evaluation Summaries

The project owns a certain amount of tests. Each pushed commit triggers our CI/CD Pipeline, which compiles the scripts and executes the tests.

CI/CD Pipeline in Github Actions: [GitHub Actions](https://github.com/Freaky2164/TowerDefense/actions/workflows/tests.yml)

![CI/CD Pipeline in Github Actions](https://github.com/Freaky2164/TowerDefense/assets/64361270/4adcde04-3b77-4cee-b9f7-ee5225f3e0f0)

Integration of CI/CD Pipeline pipeline with GitHub:

![Integration of CI/CD Pipeline pipeline with GitHub](https://github.com/Freaky2164/TowerDefense/assets/64361270/ddd8da4b-0503-49d0-9fb7-4aae2248fe35)

## 7.2 Reporting on Test Coverage
A report for our test coverage is made with the help of SonarQube:

![SonarQube test report](https://github.com/Freaky2164/TowerDefense/assets/64361270/3bb76ca1-531d-48f2-ad90-8a3c7c0f74a9)

Our report shows that the tests cover 90.4% of our C# scripts.

## 7.3 Perceived Quality Reports
n/a

## 7.4 Incident Logs and Change Requests

We integrated the tools mentioned above into our GitHub pull request workflow. If a build fails this is directly visible in GitHub.

![GitHub pull request workflow](https://github.com/Freaky2164/TowerDefense/assets/64361270/0746dc04-30ae-4365-9a3a-d70dcdf4388c)

## 7.5 Smoke Test Suite and Supporting Test Scripts
n/a

## 8. Testing Workflow

1) Local testing in the IDE
2) Commit and Push triggers build and test exection in the CI/CD Pipeline
3) Each pull requests triggers the pipeline (build and test)

## 9. Environmental Needs

### 9.1 Base System Hardware
n/a

### 9.2 Base Software Elements in the Test Environment

The following base software elements are required in the test environment for this Test Plan.

| Software Element Name |  Type and Other Notes                        |
|-----------------------|----------------------------------------------|
| IntelliJ              | Test Runner / IDE                            |
| .NET Core           | Unit testing library                         |

### 9.3 Productivity and Support Tools

The following tools will be employed to support the test process for this Test Plan.

| Tool Category or Type | Tool Brand Name                              |
|-----------------------|----------------------------------------------|
| GitHub Repository            | [GitHub](https://github.com/Freaky2164/TowerDefense)            |

## 10. Responsibilities, Staffing, and Training Needs

### 10.1 People and Roles

| Role          | Person Assigned |  Specific Responsibilities or Comments |
|---------------|:--------------:|----------------------------------------|
| Test Manager | Paul | Provides management oversight. |
| Test Designer | Tim, Lukas | Defines the technical approach to the implementation of the test effort. |
| Test System Administrator | Johannes | Ensures test environment and assets are managed and maintained. |

### 10.2 Staffing and Training Needs
n/a

## 11. Iteration Milestones
We want to keep ensure at least 90% code coverage with our tests.

## 12. Risks, Dependencies, Assumptions, and Constraints

| Risk | Mitigation Strategy | Contingency (Risk is realized) |
|------|---------------------|--------------------------------|
| Code has lots of side effects | Refactor code (Clean Code principles) | publish new refactored tests |
| Test Runner is not able to execute tests | Use standard libraries which include working Test Runner | fix test execution configuration |
