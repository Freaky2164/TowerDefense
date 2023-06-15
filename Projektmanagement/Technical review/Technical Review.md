## Goal: 
The purpose of this code review is to assess the RoundHandler and EnemySpawner components in order to align with best practices, minimize code instability, and ensure functionality.

## Components for Review:
- RoundHandler 
- EnemySpawner 

For these components, the following criteria have been considered:
- code quality
- scalability
- maintainability
- functionality

## Review methodology:
The following steps were followed during the review process:

1. Examination of best practices.
2. Discussion with the developer regarding their implementation.
3. Evaluation of the components' functionality.
4. Review of the code, highlighting both positive and negative aspects.
5. Definition of next steps.
6. Summary of lessons learned.

## Example Review:
RoundHandler: The RoundHandler component should handle rounds independently without direct connections to other components. It should, however, be aware of whether a round is currently being played to avoid simultaneous rounds. Other components should be able to easily access information about the active round.

![TechnicalReview](https://github.com/Freaky2164/TowerDefense/assets/97842228/b3da19fa-156e-446b-a211-5ecd2019a28c)

Upon reviewing the code, it was identified that certain improvements are needed. Firstly, adherence to C# naming conventions should be addressed, specifically the inclusion of underscores in the naming of private properties. On a positive note, the implementation of event handling is commendable, as it allows convenient access to information about the active round in other components without the RoundHandler needing to be aware of them. A potential area for improvement is the initialization of rounds within the RoundHandler class, which should be extracted into a separate configuration file for future edits within the Unity editor.

## Outcome: 
### Actions:
- Extract information about rounds into a separate configuration file.
- Refactor the code to adhere to C# naming conventions.
- Responsible for these actions: The developer who created the RoundHandler component.

### Lessons learned:
- Emphasize encapsulation of components from each other.
- Clarify the responsibilities and scope of each component.