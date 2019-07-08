Audio Manager Package (Read Me / Documentation)
Created By: Jonathan Carter
Version: 1
Last Updated: 22/06/19
	
Contents:
	- Package contents
	- First use setup
	- How to play a clip
	- Error Messages
	- Common Problems

		
1) Package Contents
	
The package has four folders including the one this document is in, each has one file. the Editor and Scripts folders are needed for the manager to function:
	
	Editor:
		AudioManagerEditor.cs
	Prefabs:
		AudioPrefab.prefab
	Scripts:
		AudioManagerScript.cs
	Readme:
		This document
		
	
2) First Use Setup
	
Once the package has been imported into the project, create a empty gameobject for the manager and add the Audio Manager Script to it or add it to an exsisting gameobject if you wish.
When using the script for the first time it will create a directory /audio if it doesn't already exsist, you will need to store the audio in this directory for script to work.
Next you will need to assign a prefab to the script, this is done by pressing the assign prefab button. This button will show a extra setion of GUI with a help box and
a GameObject field. Add the prefab to the Gameobject field to assign it, you will notice the button text and colour will change to show this has worked.

Next you will need to scan the audio clips into the manager, this is done by pressing the scan button. You will notice that there is a text box below the buttons.
This box display's the number of eligible clips in the /audio directory as well as how many have been scanned already. This will update on the fly when you add new files into the /audio
directory. If there are unscanned items then you will need to re-scan by pressing the yellow re-scan button (Note: the yellow button only appears once the green scan button has been pressed once).

Once it scans the /audio directory it will show each clip in a list but a preview button and the clip name for each clip. Pressing the preview button plays the clip associated with it 
in the inspector, please note that the clip will play at the default volume and pitch. You will need the clip name when calling a clip to be played by the manager so you can copy the text from these
boxes to ensure you don't make a typo when playing a clip. 


3) How To Play A Clip

The first step to this is getting the manager, referencing the script and assigning it is the easiest way, you can also use findobjectoftype or tags to get the gameobject the script is on.

Once you have a refernece setup, you have three ways to play a clip built into the manager (you are welcome to make your own on top of what I've built if needed):

- PlayClip() - The standard play option which plays the clip from the start. You have to input the string for the name of the clip to play. You do also have the option to change the volume & pitch.
- PlayClipFromTime() - Works just lke the first function but requires atleast the first 2 inputs. The first is the string of the clip to play. The second is the time which is a float value for when the clip should play from. You do also have the option to change the volume & pitch.
- PlayClipWithDelay() - Once again works just like the first function but plays after a delay input. Again it requires atleast the first 2 inputs. The first is the string of the clip to play. The Second being the time delay before the clip plays. You do also have the option to change the volume & pitch.

More functions may be added in the future, most if there is a demand for a certain function. 


4) Error Messages

The scripts have a selection of error messages in the for of Debug warnings, all errors from this script come with the prefix "(*Audio Manager*):" so you will know it is from this package. Most errors shouldn't come up but they should explain what you've done wrong and how to fix it.
However if you run into a problem or get an error and are unsure, fell free to drop me an email at (hello@carter.games) and I'll do my best to help you out.  


5) Common Problems

The manager can find my audio:
Please make sure all audio you want to use with this manager is in the /audio directory and NOT in a sub-directory, the script currently doesn't support sub-directory's at this time and therefore will ignore anything in them.

I called a function to play audio and nothing happened:
Please make sure you spelt the clip name correctly, note it is CaSe SeNsItIvE, also make sure the code is running with a debug log and the script is references correctly. 

I called a function and the clip plays a million times:
This is due to you having the call in an update() or similar, if you have the call in update you need to have either a boolean or a coroutine to stop it been called more than once. 