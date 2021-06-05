# Unity 3D platformer game - recruitment task

## Game mechanics

Player starts the game in the middle of scene, which is built in a maze-alike concept. 

The task is to open doors, but before that player must find a chest containing key. Key is needed to open doors and to complete the run. Through the course of game, time is measured and after finishing run, timer is stopped and results are shown. Game can be repeated endlessly and best time is saved as a highscore. 

Location of chest is randomly selected from three predefined locations and location of doors is selected in the same way from eight predefined locations. Doors are always spawned near one of four big blocks (which in fact are the only elements big enough to hold doors :blush: ).

## Controls

* **LMB** - player interaction (interactive elements are highlighted as red)
* **W S A D** - player movement (up/down/left/right)
* **Q E** - player rotation (counterclockwise, clockwise)
* **ESC** - exit to main menu (for now game can't be resumed - needs to be started again, so use with caution :smiling_imp: )

## Used external resources

* Assets
    * https://assetstore.unity.com/packages/3d/characters/humanoids/sci-fi/stylized-astronaut-114298
    * https://assetstore.unity.com/packages/3d/props/lowpoly-sci-fi-crates-free-146016
    * https://assetstore.unity.com/packages/3d/props/rust-key-167590
    * https://assetstore.unity.com/packages/3d/environments/sci-fi/sci-fi-door-21813

* Textures

    * https://www.textures.com/download/PBR0407/137280
    * https://www.textures.com/download/PBR0403/137274

* Audio
    * https://freesound.org/people/lucktheone/sounds/170643/
    * https://www.zophar.net/music/nintendo-nes-nsf/quattro-arcade-go-dizzy-go

## Author notes

3D assets were downloaded from unity store and were used in untouched way - I didn't do any 3D work in the process of creating game. The same goes for textures - they are added unmodified.

Audio resources were modified with Audacity.

Scripts and UI elements are my work based on endless torturials found online. This game is in fact my first attempt at Unity Engine and also at c# language, so it's far from being perfect and polished :sunglasses::sunglasses::sunglasses:.

Some of project files were not added to repo, I found them unnecessary and gitignored them (if you need a full package then I can send it separately, same goes for UI psd files). `Build` directory was added - it contains a working build with .exe file. I also added zipped file of build directory, so you can download it, unpack and run game directly.

&nbsp;

---

&nbsp;

Unity version: 2020.3.9f1 LTS  
Build date: 2021-06-04  
Author: PityoN