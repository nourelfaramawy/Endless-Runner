# Go Go Power Rangers - Endless Runner Game Project

## Project Objective
The main objective of this project is to demonstrate proficiency in developing core components of a video game deployable on both desktop and mobile platforms. The game is inspired by the popular Power Rangers series and is an endless runner similar to Subway Surfers.

## Gameplay Overview
In this endless runner game, the player controls a sphere moving forward automatically on an infinite floor divided into 3 lanes. The player must dodge obstacles while collecting orbs to switch forms and utilize powers. The goal is to achieve the highest score before the game ends.

## Rules of Play
### Movement
- Player views the game from a third-person perspective behind the sphere.
- Player automatically moves forward.
- Player can steer left and right to change lanes.
- Player cannot exit the playing area.
- Player's speed is consistent across devices.

### Item Generation
- Orbs and obstacles are generated automatically and randomly across 3 lanes.
- Orbs increase player's resources, while obstacles end the game.
- Maximum of 2 obstacles per lane.
- All game objects are pooled or discarded to avoid memory leaks.

### Energy & Score
- The player has 3 different types of energy points: red energy points, green energy
points and blue energy points.
- The player’s energy points’ are initially set to zero, and their maximum value is 5
points, and can never exceed this value.
- The player has a score counter, which is initially set to zero.
- Collecting an orb normally increases both the score and the corresponding colour’s
energy points by 1 point each.

### Switching Forms
- The player initially starts in normal form (i.e. white).
- To switch to a colored form, the player must have the corresponding energy points at their maximum value (i.e. 5 points). Pressing “J”, “K”, and “L” switches to red, green, and blue forms respectively.
- Switching forms changes the player’s color and consumes 1 point from the corresponding energy points.
- Players can switch to any form from either the normal form or a different colored form, provided the energy points of the selected color are at their maximum. Attempting to switch without enough energy points keeps the player in their current form.
- When the player collects an orb matching their current form's color, the score increases by 2 points, while energy points remain unaffected. Collecting orbs of other colors behaves normally.
- If in an active form and its corresponding energy points reach zero, the player automatically reverts to the normal form.

### Powers
### General Power Usage
- When in a form, the player can activate the corresponding power by pressing “Space bar”, which consumes 1 point from its corresponding energy points.

### Red Power (Nuke)
- Once activated, all currently existing obstacles ahead of the player are eliminated.
- After all existing obstacles are eliminated, obstacle generation continues normally.

### Green Power (Multiplier)
- Upon activation, the next collected orb provides 5 times the score points and double the energy points.
- Collecting orbs of the same color as the current form increases the score by 10 points, but energy points remain unchanged.
- Collecting orbs of different colors from the current form increases the score by 5 points and energy points by 2 points.
- The multiplier deactivates automatically after collecting only 1 orb.
- Pressing “Space Bar” while the multiplier is active has no effect.
- Switching to another form deactivates the multiplier automatically.

### Blue Power (Shield)
- Upon activation, a shield surrounds the player, protecting from 1 obstacle hit.
- The shield deactivates automatically after hitting only 1 obstacle.
- Pressing “Space Bar” while the shield is active has no effect.
- Switching to another form deactivates the shield automatically.
- The shield is not affected by collecting orbs.

## Obstacle Damage
- The player reverts back to the normal form upon hitting an obstacle while in a colored form.
- The player cannot be damaged multiple times by the same obstacle.
- If the player hits an obstacle while in the normal form, the game ends, and a "Game Over" screen is displayed.

## Game Controls
### Windows
- Left and right arrows (or A and D) to move.
- J, K, and L to switch to red, green, and blue forms.
- Space bar to activate power.
- Escape to pause/resume.

## Cheats 
- Pressing “U” toggles the player’s invincibility. In this state, obstacles do not affect
the player. However, both the energy points and score behave normally.
- Pressing “I”, “O” or “P” to increase the player’s red, green and blue energy points
by 1 point respectively.


Enjoy playing Go Go Power Rangers! 🎮
