#########################################
# UMAzing In-game UMA Character Creator #

Version 2.0.0

Now updated for Unity 5 and UMA 2!

Requires:
UMA 2 - Unity Multipurpose Avatar 2.0.1 or above
Unity 5.0.1 or above

######################
## What is UMAzing? ##

UMAzing in-game character creator is an extension for UMA (Unity Multipurpose Avatar). It allows anyone to easily set up a functional and good-looking in-game character creation wizard for any type of game. For clarification, UMA is what glues together the parts and textures that make up the character, and UMAzing is the interface which lets the player switch between UMAs various parts in-game, and handles the saving of the finished character. 

The key philosophy in making UMAzing has been to make it as quick as possible to set up, yet still be open to modification. For that reason, UMAzing includes 3 different character creation themes, which you can use as they are or use them as a starting point for creating your own theme. 

If you are starting from scratch, there is basically zero configuration needed. All you need to do is add the scenes to the Unity build settings menu and play. 

Included is also 4  pre-made scenes, whereof 3 are related to the various character creation themes and one is the entry-point for your game after the character creation is finished. Feel free to use the themes as they are, or modify them to better suit your game.  

You can use the included game scene with a third person viewpoint as a starting point for your gameplay or change the character creation to instead lead to any scene you may already have created by simply dragging a supplied prefab into your scene changing one line in the inspector to match the name of your scene.

Giving your players the ability to create their own characters in your game couldn't be any easier.

##############
## Features ##

- Built on the powerful UMA framework, allowing for limitless extendability
- Almost zero configuration setup
- 3 fully fledged themes (Fantasy, Sci-Fi and Plain)
- Professional, clean GUI appearance, with lots of customizability
- GUI adapts to the screen size
- Smooth orbit camera and fading scene transitions
- Automatically hides parts and colors when there is only one variation of it
- More than sliders: choose the various parts that make up the characters
- Customize the randomization ranges and slider limits
- Easily add skincolors, haircolors, eyecolors, lipstick color and so on right in the inspector
- Includes a simple third person camera setup which automatically attaches to your generated character in the game scene
- Toggle allowance for removing underwear or not
- Commented code, helping you to make your own edits and understand how UMA works


######################
## How to set it up ##

(0. First, make sure you have UMA installed in your project)

All of the assets for UMAzing can be found in UMA>Extensions>UMAzing. An additional folder called Character Saves is also created under your root assets folder.

Choose one of the two methods below for setting up UMAzing:

### If you are starting from scratch: ###

1. Load UMAzing into your project

2. Drag and drop "Game Scene" and your preferred "CC Scene" from UMA>Extensions>UMAzing>Scenes to your build settings (File > Build Settings). Make sure CC Scene is above Game Scene.

(2a. If using Unity Pro license, check "Use PRO" in UMA>UMAgenerator in your chosen CC Scene and Game Scene for much faster character generation)

3. That's it! Go into the chosen CC Scene and press play.

(4. Keep building your game from "Game Scene")


### If you want to add the character creator to your existing game: ###

1. Load UMAzing into your project

2. Add your preferred "CC Scene" from UMA>Extensions>UMAzing>Scenes to your build settings (File > Build Settings). Place it at the top or have your menu lead to it before the game scene.

3. Go into the chosen CC Scene and in the hierarchy, click on UMAzing > Character Creator

4. In the inspector, edit the "Game Scene Name" field to the name of the scene you want to load after the character creation finishes

5. Go into your game scene

6. In the project browser, drag UMA>Extensions>UMAzing>Assets>Common>Prefabs>UMA and UMACharacter into your scene where you want the player to start

(6a. If using Unity Pro license, check "Use PRO" in UMA>UMAgenerator in your chosen CC Scene and Game Scene for much faster character generation)

7. In the hierarchy, click on UMACharacter and link up "Context" to the UMAContext in the scene

8. Go into the CC Scene and press play.

(9. Configure the UMAzing character creator to suit your game )

Finally, create the folders "Asset>Character Saves" (if using the default Save Path) under the folder where you store your built executable, or the characters won't be able to save in the built version. It will throw an error telling you which folder is missing.

###################################################################################################
## Adding additional overlays to existing slots (eg. a texture-based hairstyle or shirt texture) ##

Tutorials for creating art assets to be compatible with UMA can be found here: http://fernandoribeirogames.wix.com/umabeta

Lets say you want to create a third male hairstyle. 

For simplicity, let's copy the folder UMA>UMA_Assets>Overlays>Male>MaleHair02. Rename everything to 03. 
Click on MaleHair03>MaleHair03 and edit the "Overlay Name" field to "MaleHair03"
Edit MaleHair03_diffuse to suit your needs. 
Open up the CC Scene and select UMA>OverlayLibrary in the hierarchy. 
In the inspector, drag MaleHair03>MaleHair03 onto the the field up top. Do the same for the Game Scene. 
Then, in the CC Scene, select UMAzing>Character Creator in the hierarchy. 
Scroll down to "Male Hair Styles", increase the size by 1, and in the lowest slot, type in the name of the new asset (in this case MaleHair03). 

You should now be able to select the new hairstyle in the character creator.

######################
## Troubleshooting ##

Q: DirectoryNotFoundException: Could not find a part of the path ".../Assets/Character Saves/....txt".

A: Make sure the folder where the character saves are stored exists ("Character Saves" directly under the Assets folder by default) exists. You will also need to create one under your Build directory for the final, compiled version of the game to find the character save files.


Q: Level 'Game Scene' (-1) couldn't be loaded because it has not been added to the build settings.

A: Make sure both the CC Scene and Game Scene has been added to File > Build Settings


Q: UMAResourceNotFoundException: SlotLibrary: Unable to find ...

A: This can occur after UMA has updated its SlotLibrary. To resolve this, open up UMA>Example>Scenes>Crowd, and in the Hierarchy panel, Select UMA>SlotLibrary. In the Inspector, Click the cogwheel to the right of Slot Library (Script), and choose Copy Component. Then open up the UMAzing CC Scenes and Game Scene. Again, in the hierarchy, select SlotLibrary, and this time in the inspector, click the same cogwheel and choose Paste Component Values. Save each scene, and it should work.


Q: Can I add other races than humans?

A: Yes, but not easily. Because the available races could vastly differ from game to game and because UMA only comes with human assets by default, I've decided to only officially support humans. But if you really want to add a new race, the best way would be to look inside the character creator script as well as become familiar with how UmaRaces work. You would also need to add a dialogue before "choose gender" with the various races.
