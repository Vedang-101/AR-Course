# Augmented Reality Course Project

The Augmented Reality course project involves around augmenting a simple card battle game with the avatars on top animating to the actions performed during the game loop.
The project uses Unity Game Engine and Vuforia AR SDK. The game uses cards as the target images to track the 3D models on top of and continously checks which cards are
being played and uses that as an input for playing the animation logic where the stronger opponet plays an attak animation and shoots a projectile towards the other avatar.
The game is a small proof of concept to show the application of AR in traditional card games to enhane the user experience and engagement.

https://user-images.githubusercontent.com/45897291/190529405-8b7d8026-5743-4e19-b612-d67867e6ac3e.mp4

## Rules of the game
- Players randomly get cards from the deck and place them face down.
- At each start of turn, player picks one card from their deck to play with, the opponent chooses their card at the same time.
- Both players play the cards at same time, one who has higher damage attacks the other opponent, if any card is down, player replenish the card with a new one.
- Last player remaining in the battleground wins
