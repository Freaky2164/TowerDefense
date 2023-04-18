## Methods extracted

  To maintain better clarity, the update method of various classes was split into their functionality and extracted as separate methods. For example, the update method of the tower:

![Old Update](https://github.com/argastle/TowerDefense/blob/main/Projektmanagement/Clean%20Code/Screenshots/OldUpdate.png)
![New Update](https://github.com/argastle/TowerDefense/blob/main/Projektmanagement/Clean%20Code/Screenshots/NewUpdate.png)

## Naming conventions adjusted

  To adhere to C# best practices, global private variables were prefixed with an underscore.

![NamingConventions](https://github.com/argastle/TowerDefense/blob/main/Projektmanagement/Clean%20Code/Screenshots/NamingConventions.png)

## Performance optimized (unnecessary code removed)

  To reduce redundancy in complex calls, these calls were defined globally once and called or updated in the required places.
  As a result, redundant variables were removed and the naming conventions were adjusted.

![PerformanceOptimation](https://github.com/argastle/TowerDefense/blob/main/Projektmanagement/Clean%20Code/Screenshots/PerformanceOptimation.png)

## Methods corrected for properties

  To make the methods more secure and keep track of the dependencies of various classes, the methods were modified with the private modifier.
  
![StaticMethod](https://github.com/argastle/TowerDefense/blob/main/Projektmanagement/Clean%20Code/Screenshots/StaticMethod.png)
