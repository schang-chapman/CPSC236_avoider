# CPSC236_avoider

## Identifying Information
* Name: Sharon Chang
* Student ID: 2344341
* Email: shchang@chapman.edu
* Course: CPSC236
* Assignment: Avoider

## Assets Files
Animations:
* -

Prefabs:
* Enemy
* Line of Sight

Scenes:
* -

Scripts:
* CameraFollow
* EnemyManager
* ExitManager
* GameManagerScript
* PlayerManager

Sprites:
* Guard(Armed)
  * attack
  * idle
  * walk
* Player(Unarmed)
  * idle
  * walk
* TilesetGrass

Tilemaps:
* Graveyard Tilemap

## References
* Player + Enemy sprites from: https://rgsdev.itch.io/animated-top-down-character-base-template-in-pixel-art-rgsdev
* Tileset from: https://angrysnail.itch.io/pixel-art-graveyard-tileset
* CPSC236 Platformer instruction videos
  * Making a tilemap
  * Camera follow
* 2D Click to Move in Unity, Muddy Wolf Games
* Unity3D subreddit
  * How to detect double click
* gamedevbeginner.com
  * How to pause the game
* Unity 5 - Move Objects to Specific Positions (Waypoints), Lurony
  * Enemy patrol/waypoint movement
* Blackthornprod Unity videos
  * Line of sight
  * Follow player

## Known Errors
* If you click on a space that is technically "empty", but the player cannot directly move to it, the player will just collide with the nearest wall and start jittering in place.
* After implementing the code to check which direction the enemy was facing, enemies no longer acknowledged or chased the player. Cause unknown.
