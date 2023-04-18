# Tower Defense - Software Architecture Document

## Allocation of Responsibilities
Enemy game objects and towers are critical for performance since we have to calculate the distance from the tower to the enemy for every enemy that is in range of a tower during the runtime.
Because our implementation of this calculation requires traversal of a list of all enemies this could be critical if there are many enemies and towers that run calculations simultaneously.
We want to test another implementation that could improve the performance of the game by reduzing the costs of traversing the list with all enemies.
After testing with more that a hundred enemies and some towers we saw that our implementation is not leading to any losses in the performance of the game.

## Coordination Model
Game Handler communicates with the Financial System for increasing the player money after every defeated enemy. It also communicates with the Enemy Handler responsible for initializing the next wave of enemies and the Enemy Spawner that spawns them.
The towers communicate with the Financial System for reduzing the player money after buying a tower and with the enemies by calculatin the distance from tower to enemy and generating a projectile that tracks the location of the enemy.

## Data Model
Updating the enemy game objects every frame is a heavy load for the performance, but since every enemy needs to move along its path, this cant be avoided.
The same goes for the tower game objects that need to check if there are enemies within their range after every frame.

## Mapping among Architectural Elements
The performance of the calculations needed for shooting enemy game objects in range of towers could be possibly improved by using two or more concurrent running scripts.
Snychronization would then be needed which could be a problem and relativize the effects of the parallel calculations.

## Resource Management
Enemy game objects and towers are critical for performance since we have to calculate the distance from the tower to the enemy for every enemy that is in range of a tower during the runtime.
Because our implementation of this calculation requires traversal of a list of all enemies this could be critical if there are many enemies and towers that run calculations simultaneously.

## Choice of Technology
The logic in our game is written mostly with C# scripts, which has a relatively good performance compared with other programming languages like Java, Javascript, C++ or Phyton.
