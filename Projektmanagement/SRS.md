TowerDefense - Software Requirements Specification 

## Table of contents
- [Table of contents](#table-of-contents)
- [Introduction](#1-introduction)
    - [Purpose](#11-purpose)
    - [Scope](#12-scope)
    - [Definitions, Acronyms and Abbreviations](#13-definitions-acronyms-and-abbreviations)
    - [References](#14-references)
    - [Overview](#15-overview)
- [Overall Description](#2-overall-description)
    - [Vision](#21-vision)
    - [Use Case Diagram](#22-use-case-diagram)
	- [Technology Stack](#23-technology-stack)
- [Specific Requirements](#3-specific-requirements)
    - [Functionality](#31-functionality)
    - [Usability](#32-usability)
- [Supporting Information](#4-supporting-information)

## 1. Introduction

### 1.1 Purpose
This Software Requirements Specification (SRS) describes all specifications for the application "Tower Defense". It includes an overview about this project and its vision, detailed information about the planned features and boundary conditions of the development process.


### 1.2 Scope
We are going to create a simple Tower Defense game that runs on Android Phones
When you open the application you are presented with a menu where you can choose between a Start, Load, Quit and Settings Button.
If you start or load the game you get forwarded to the game map.

The map should be split in 2 Parts:

- The way through the map where enemies walk to your base to decrease your HP
- A place where you can place your turrets to defend your base!

The main goal is to survive multiple waves of enemies which can be achieved by buying and upgrading towers.
This towers can then be placed on the map and automatically shoot the enemies walking along the path

### 1.3 Definitions, Acronyms and Abbreviations
| Abbrevation | Explanation                            |
| ----------- | -------------------------------------- |
| SRS         | Software Requirements Specification    |
| UC          | Use Case                               |
| n/a         | not applicable                         |
| tbd         | to be determined                       |
| OUCD         | Overall Use Case Diagram               |
| FAQ         | Frequently asked Questions             |

### 1.4 References

| Title                                                              | Date       | Publishing organization   |
| -------------------------------------------------------------------|:----------:| ------------------------- |
| [TowerDefense Blog](https://github.com/argastle/TowerDefense/discussions)   | 20.10.2022 | TowerDefense Team    |
| [GitHub](https://github.com/argastle/TowerDefense)              | 20.10.2022 | TowerDefense Team    |


### 1.5 Overview
The following chapter provides an overview of this project with vision and Overall Use Case Diagram. The third chapter (Requirements Specification) delivers more details about the specific requirements in terms of functionality, usability and design parameters. Finally there is a chapter with supporting information. 
    
## 2. Overall Description

### 2.1 Vision
Inspired by games like Bloons TD we want to make a unique take on the Tower Defense genre. To achieve that we create our own individual design for the map, towers and enemies. Additionally we try to add new features which popular Tower Defense games haven't implemented yet. But the most important thing is that our game is entertaining and fun to play!

### 2.2 Use Case Diagram

![OUCD](./Use_Case_Diagram.png)

### 2.3 Technology Stack
The technology we use is:

Game Engine:
- Unity

IDE:
- Unity Hub
- Rider
- Visual Studio Code

Project Management:
- YouTrack
- GitHub

## 3. Specific Requirements

### 3.1 Functionality
This section will explain the different use cases, you could see in the Use Case Diagram, and their functionality.  
Until December we plan to implement:
- 3.1.1 Create Game
- 3.1.2 Start Round
- 3.1.3 Place Towers
- 3.1.4 Upgrade Towers

![OUCD](./MockUps/GameMockUp.png)

Until June, we want to implement:
- 3.1.5 Increase Wave Speed
- 3.1.6 Save Game
- 3.1.7 Load Game
- 3.1.8 Player Level
- 3.1.9 Unlock new Towers
- 3.1.10 Player Settings

#### 3.1.1 Create Game
This use case allows users to start a game. He can either create a new game or load an existing one. This is neccecary for playing the game, since you can't play without an existing game.

[Create Game](./UseCases/Create_Game.md)

#### 3.1.2 Start Round
This use case allows players to start a new round while playing the game. This is a necessary feature for the game since the game pauses after every wave. So the player can decide when he is ready for the next wave.

[Start Round](./UseCases/Start_Round.md)

#### 3.1.3 Place Towers
This use case allows players to place towers on the map. The player can choose on from a verarity of different towers and place it anywere on the grid. This is important as it is the essential functionality for the game.

[Place Towers](./UseCases/Place_Towers.md)

#### 3.1.4 Upgrade Towers
This use case allows players to upgrade towers that they have already placed on the map. This is a necessary feature for the game since the enemies in a level are getting stronger with each wave. Since the space to place towers on the map is limited, the only way for the player to be able to handle stronger waves is to upgrade to stronger towers.

[Upgrade Towers](./UseCases/Upgrade_Towers.md)

### 3.2 Usability
We plan on designing the user interface as intuitive and self-explanatory as possible to make the user feel as comfortable as possible using the app. Though an FAQ document will be available, it should not be necessary to use it.

## 4. Supporting Information
For any further information you can contact the TowerDefense Team or check our [TowerDefense Blog](https://github.com/argastle/TowerDefense/discussions). 
The Team Members are:
- Paul Faller
- Lukas Weber
- Tim Wäckerle
- Nico Argast
- Johannes Methfessel

<!-- Picture-Link definitions: -->
[OUCD]: https://github.com/IB-KA/CommonPlayground/blob/master/UseCaseDiagramCP.png "Overall Use Case Diagram"
