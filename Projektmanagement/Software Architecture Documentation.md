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
    - [Use-Case Realizations](#41-use-case-realizations)
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
[This section describes what software architecture is for the current system, and how it is represented. Of the Use-Case, Logical, Process, Deployment, and Implementation Views, it enumerates the views that are necessary, and for each view, explains what types of model elements it contains.]

## 3 Architectural Goals and Constraints 
Our game is based on an event-driven software architecture design with mediator topology. The game will be developed entirely with Unity using C#-Scripts for coding the logic. We plan to make the game portable to all mobile devices and plan to make them available on app stores.

## 4 Use-Case View 
[This section lists use cases or scenarios from the use-case model if they represent some significant, central functionality of the final system, or if they have a large architectural coverage—they exercise many architectural elements or if they stress or illustrate a specific, delicate point of the architecture.]
### 4.1	Use-Case Realizations
[This section illustrates how the software actually works by giving a few selected use-case (or scenario) realizations, and explains how the various design model elements contribute to their functionality.]

## 5 Logical View 
[This section describes the architecturally significant parts of the design model, such as its decomposition into subsystems and packages. And for each significant package, its decomposition into classes and class utilities. You should introduce architecturally significant classes and describe their responsibilities, as well as a few very important relationships, operations, and attributes.]

### 5.1	Overview
[This subsection describes the overall decomposition of the design model in terms of its package hierarchy and layers.]

### 5.2	Architecturally Significant Design Packages
[For each significant package, include a subsection with its name, its brief description, and a diagram with all significant classes and packages contained within the package. 
For each significant class in the package, include its name, brief description, and, optionally, a description of some of its major responsibilities, operations, and attributes.]

## 6 Process View 
[This section describes the system's decomposition into lightweight processes (single threads of control) and heavyweight processes (groupings of lightweight processes). Organize the section by groups of processes that communicate or interact. Describe the main modes of communication between processes, such as message passing, interrupts, and rendezvous.]

## 7 Deployment View 
[This section describes one or more physical network (hardware) configurations on which the software is deployed and run. It is a view of the Deployment Model. At a minimum for each configuration it should indicate the physical nodes (computers, CPUs) that execute the software and their interconnections (bus, LAN, point-to-point, and so on.) Also include a mapping of the processes of the Process View onto the physical nodes.]

## 8 Implementation View 
[This section describes the overall structure of the implementation model, the decomposition of the software into layers and subsystems in the implementation model, and any architecturally significant components.]

### 8.1	Overview
[This subsection names and defines the various layers and their contents, the rules that govern the inclusion to a given layer, and the boundaries between layers. Include a component diagram that shows the relations between layers. ]

### 8.2	Layers
[For each layer, include a subsection with its name, an enumeration of the subsystems located in the layer, and a component diagram.]

## 9 Size and Performance
Since our game will be ported on mobile apps we keep in mind that the required memory space should be minimized and we plan to increase the otherall efficiency . 
[A description of the major dimensioning characteristics of the software that impact the architecture, as well as the target performance constraints.]

## 10 Quality 
For our game we will be focusing on Performance using Framerates per Seconds as a measurement for how good the performance is. The framerate of a game is nowadays probably one of the most important quality attributes in the gaming industry. Thats why we try to aim for the optimal structure of our game objects. We want to minimize the initializations of different objects as much as possible and we also seek out to reduze the use of more expensive functions that would lead to the same outcome.<br><br>
Usability is our second most important quality attribute. It should be measured by the time users play and enjoy our game. Our game should be easy to use and players should quicky understand how the game mechanics are working.<br><br>
Availability is not so important for our game. It is measured by the time how long the game is running without any crashes. We try to detect errors during the runtime of the game but if a bug occurs it is likely that the game crashes. We should then try to work on fixing those bugs.
