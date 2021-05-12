# Rhythm Doctor Current Song Plugin
*A [BepinEx](https://github.com/BepInEx/BepInEx/releases) plugin for Rhythm Doctor.*

Takes the current level's song and artist name and outputs it into a `.txt` file, for use in OBS or other streaming software.

How to install:
1. Download the latest release of BepinEx_x86 and `RDCurrentSong.dll`.
2. Extract it to the folder containing the game `.exe`. 
3. Run the game. BepinEx should create all of its necessary folders.
4. Put `RDCurrentSong.dll` into the `BepinEx/plugins` folder.
5. Run the game again. By default, it'll output the `.txt` file to the folder containing the game `.exe`. You can change this in the config file.

Required libraries to compile the plugin `.dll` yourself (not included because of copyright, need to add to `Libs`):
* BepinEx.dll (from `BepinEx/core`)
* UnityEngine.dll (from `Rhythm Doctor_data/Managed`)
* UnityEngine.CoreModule.dll (from `Rhythm Doctor_data/Managed`)
* Assembly-CSharp.dll (from `Rhythm Doctor_data/Managed`)
