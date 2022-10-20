# Use-Case Specification: Upgrade Towers

# 1. Upgrade Towers

## 1.1 Brief Description
This use case allows players to upgrade towers that they have already placed on the map. 
This is a necessary feature for the game since the enemies in a level are getting stronger with each wave. 
Since the space to place towers on the map is limited, the only way for the player to be able to handle stronger waves is to upgrade to stronger towers.

## 1.2 Mockup 
![Mockup Post a Session](../mockups/post_a_session_mockup.png)

## 1.3 Screenshots
<img src="./Screenshots/UC1_Post_Session_Screenshot0.png" alt="Posting" width="300"/> <img src="./Screenshots/UC1_Post_Session_Screenshot1.png" alt="Posting" width="300"/> <img src="./Screenshots/UC1_Post_Session_Screenshot2.png" alt="Posting" width="300"/> <img src="./Screenshots/UC1_Post_Session_Screenshot3.png" alt="Posting" width="300"/> <img src="./Screenshots/UC1_Post_Session_Screenshot4.png" alt="Posting" width="300"/>

# 2. Flow of Events

## 2.1 Basic Flow
- Users klicks on "Post new session"-button
- "Post-Session"-template pops up
- User fills in template
- User klicks on "finish"-button
- Session gets posted

### Activity Diagram
![Activity Diagram](../activity_diagrams/UCD1_Post_Session.png)

### .feature File

[.feature File Posting a session](../../frontend/app/src/androidTest/assets/features/UC1_Post_Session.feature)
```Cucumber
Feature: Use Case 1 Posting a Session
  As a USER
  I want to open the app and be able to post a new Session at the Session Overview Page
  Therefore I want the fields: title, description, game, place, date and numberOfPlayers able to be filled in

  Background:
    Given The user is logged in
    And Activity New Session is open

  @postsession-feature
  Scenario Outline: Add a new session
    When The user types the title <title> and the input is correct
    And The user types the game <game> and the input is correct
    And The user chooses <type> as type
    And The user chooses <genre> as genre
    And The user types the post code <postCode> and the input is correct
    And The user picks the date <date>
    And The user picks the time <time>
    And The user types the number of players <numberOfPlayers> and the input is correct
    And The user types the description <description> and the input is correct
    And The user presses the publish button
    Then The posting screen is closed
    And The new session with <title> is shown

    Examples: Sessions
      | title | game       | type     | genre     | postCode  | date       | time  | numberOfPlayers | description |
      | Cards | Doppelkopf | Offline  | Card Game | 23456     | 29-10-2019 | 06:00 | 4               | fun         |
      | Raid  | Game       | Online   | MMO RPG   | -         | 01-11-2020 | 12:00 | 10              | online Game |

  @postsession-feature
  Scenario: Leaving the Activity New Session without sending a Request
    When The user presses the Back button
    Then No Request is sent
    And The posting screen is closed
```

## 2.2 Alternative Flows
n/a

# 3. Special Requirements
n/a

# 4. Preconditions
The preconditions for this use case are:
1. The player has started a game
2. The player has placed a turret on the map
3. The player has enough money to upgrade a tower

# 5. Postconditions
The postconditions for this use case are:
1. The tower changes his appearance according to the level of the upgrade
2. The damage or speed of the tower is increased

# 6. Story Points
![Function Points UC1_Post_Session](../function_points/UC1_Posting.png)
<img src="../function_points/Blue_print.png" alt="Function Points Blue_Print" width="500"/>

Total number of sotry points: 14
