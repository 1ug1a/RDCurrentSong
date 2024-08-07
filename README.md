# Rhythm Doctor Current Song Plugin
*A [BepinEx 5](https://github.com/BepInEx/BepInEx/releases) plugin for Rhythm Doctor.*

Takes the current level's song and artist name and outputs it into a `.txt` file, for use in OBS or other streaming software.

How to install:
1. Download BepinEx 5 (the x64 version, usually) and `RDCurrentSong.dll` on the [Releases page](https://github.com/1ug1a/RDCurrentSong/releases).
2. Extract it to the folder containing the game `.exe`. 
3. Run the game. BepinEx should create all of its necessary folders.
4. Put `RDCurrentSong.dll` into the `BepinEx/plugins` folder.
5. Run the game again. By default, it'll output the `.txt` file to the folder containing the game `.exe`. You can change this in the config file.

For development - required libraries to compile the plugin `.dll` yourself (not included because of copyright, need to add to `Libs`):
* BepinEx.dll (from `BepinEx/core`)
* UnityEngine.dll (from `Rhythm Doctor_data/Managed`)
* UnityEngine.CoreModule.dll (from `Rhythm Doctor_data/Managed`)
* Assembly-CSharp.dll (from `Rhythm Doctor_data/Managed`)
