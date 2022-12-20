Tower Defense - Software Architecture Document

## Table of Contents
 - [Table of contents](#table-of-contents)
 - [Introduction](#1-introduction)
    - [Purpose](#11-purpose)
    - [Scope](#12-scope)
    - [Definitions, Acronyms and Abbreviations](#13-definitions-acronyms-and-abbreviations)
    - [References](#14-references)
    - [Overview](#15-overview)
 - [Architectural Representation](#2-architectural-representation)
 - [Architectural Goals and Constraints](#3-architectural-goals-and-constraints)
 - [Use-Case View](#4-use-case-view)
    - [Use-Case Realizations](#41-use-case-realization)
 - [Logical View](#5-logical-view)
    - [Overview](#51-overview)
    - [Architecturally Significant Design Packages](#52-architecturally-significant-design-packages)
 - [Process View](#6-process-view)
 - [Deployment View](#7-deployment-view)
 - [Implementation View](#8-implementation-view)
    - [Overview](#8-overview)
    - [Layers](#82-layers)
 - [Size and Performance](#9-size-and-performance)
 - [Quality](#10-quality)

## 1. Introduction

### 1.1 Purpose
This document provides an overview of our software architecture. With several different architectural views it depicts different aspects of the system. It is intended to capture and convey the significant architectural decisions which have been made for the system.


### 1.2 Scope
This document describes the architecture of the TowerDefense project.


### 1.3 Definitions, Acronyms and Abbreviations
| Abbrevation | Explanation                            |
| ----------- | -------------------------------------- |
| n/a         | not applicable                         |
| FAQ         | Frequently asked Questions             |

### 1.4 References

| Title                                                              | Date       | Publishing organization   |
| -------------------------------------------------------------------|:----------:| ------------------------- |
| [TowerDefense Blog](https://github.com/argastle/TowerDefense/discussions)   | 20.10.2022 | TowerDefense Team    |
| [GitHub](https://github.com/argastle/TowerDefense)              | 20.10.2022 | TowerDefense Team    |

### 1.5 Overview
This document contains the architectural representation, goals and constraints as well 
as the logical, deployment, implementation and data views.

## 2 Architectural Representation 
This project uses a special MVC Pattern native to Unity. The models in Unity are the objects that store the data, for example the enemies and towers. The view is described by the scenes and game objects. The controller is defined through the C#-scripts which hold the logic for our game. A special form of the MVC pattern for Unity including a fourth Service components can be seen in the next picture:

![Unity MVCS Architecture](https://user-images.githubusercontent.com/64361270/206400556-000309cd-4d7f-4d8a-8b5a-d2cf1e03c727.png)

## 3 Architectural Goals and Constraints 
Our game is based on an event-driven software architecture design with mediator topology. The game will be developed entirely with Unity using C#-Scripts for coding the logic. We plan to make the game portable to all Android devices and plan to make them available on app stores.

## 4 Use-Case View 
![Use Case Diagram](https://github.com/argastle/TowerDefense/blob/main/Projektmanagement/Use_Case_Diagram.png)

### 4.1 Use-Case Realizations
- [Use-Case-Realization Specification: Create Game & Load Game](https://github.com/argastle/TowerDefense/edit/main/Projektmanagement/UCRS%20%231.md)
- [Use-Case-Realization Specification: Start Round](https://github.com/argastle/TowerDefense/edit/main/Projektmanagement/UCRS%20%232.md)

## 5 Logical View 
![UML Class Diagram](https://github.com/argastle/TowerDefense/blob/main/Projektmanagement/Uml-Diagram.png)

### 5.1 Overview
n/a

### 5.2 Architecturally Significant Design Packages
n/a

## 6 Process View 
Here you can see our sequence diagrams for the two main scenarios in our game:

 - Scenario 1: You are in the menu and you want to start a new game either by creating a new one or by loading a previous one.
 ![Create Game Sequence Diagram](https://github.com/argastle/TowerDefense/blob/main/Projektmanagement/SequenceDiagrams/Create_Game_Sequence_Diagram.png)
 - Scenario 2: You are already in a game and able to place towers, using them to shoot enemies and rewarding you with money you can use to buy more tower
  ![Play Round Sequence Diagram](https://github.com/argastle/TowerDefense/blob/main/Projektmanagement/SequenceDiagrams/Play_Round_Sequence_Diagram_Updated.png)

## 7 Deployment View 
Here you can see our deployement view diagram: 

![Deployment View Diagram](https://github.com/argastle/TowerDefense/blob/main/Projektmanagement/DeploymentView.png)

### 7.1 Test

## 8 Implementation View 
In our implementation we use one system which consists of all the needed components in our game. In the following component diagram we added a theoretical utility system for persisting user information and an additional system for the use of third-party audio effects. 

![Component Diagram](https://github.com/argastle/TowerDefense/blob/main/Projektmanagement/Component%20Diagram.png)

## 9 Size and Performance
n/a

## 10 Quality 
For our game we will be focusing on Performance using Framerates per Seconds as a measurement for how good the performance is. The framerate of a game is nowadays probably one of the most important quality attributes in the gaming industry. Thats why we try to aim for the optimal structure of our game objects. We want to minimize the initializations of different objects as much as possible and we also seek out to reduze the use of more expensive functions that would lead to the same outcome.

![Utility Tree](https://github.com/argastle/TowerDefense/blob/main/Projektmanagement/Utility%20Tree.png)

![Performance Tactic Tree](https://github.com/argastle/TowerDefense/blob/main/Projektmanagement/PerformanceTacticsHighlights.png)

[Design Checklist](https://github.com/argastle/TowerDefense/blob/main/Projektmanagement/Design%20Checklist%20for%20Performance.md)
