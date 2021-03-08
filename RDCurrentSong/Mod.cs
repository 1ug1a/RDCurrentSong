using System;
using System.IO;
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using UnityEngine.Rendering;

namespace RDCurrentSong
{
    [BepInPlugin("com.rhythmdr.currentsong", "Rhythm Doctor Current Song Plugin by Lugi", "1.2.1")]
    [BepInProcess("Rhythm Doctor.exe")]
    public class Mod : BaseUnityPlugin
    {
        private ConfigEntry<string> configName;
        private ConfigEntry<string> configSplitName;
        private ConfigEntry<string> configFolder;
        private ConfigEntry<int> configSpacing;
        private ConfigEntry<int> configMinLength;
        private ConfigEntry<bool> configSplit;

        private int spacing, minLength;
        private string oldLevel, newLevel, folder, folder2;
        private string[] splitLevel;

        void Awake()
        {
            configFolder = Config.Bind("General",
                                       "FolderPath",
                                       "",
                                       "The system path where the .txt file is located. " +
                                       "Leave blank to use game folder.");

            configName = Config.Bind("General",
                           "FileName",
                           "level",
                           "The name of the .txt file (without .txt).");

            configMinLength = Config.Bind("General",
                                          "MinLength",
                                          15,
                                          "The minimum length of the song title. Adds extra spaces if the title is short.");

            configSpacing = Config.Bind("General",
                                        "SpacingAmt",
                                        5,
                                        "The number of spaces added after the song title, no matter the length.");

            configSplit = Config.Bind("General",
                                      "SplitTitle",
                                      false,
                                      "Whether or not to split song name and artist into separate files.");

            configSplitName = Config.Bind("General",
                                          "SplitName",
                                          "artist",
                                          "The name of the song artist .txt file (without .txt)");

            if (configFolder.Value == "")
            {
                folder = Path.Combine(Directory.GetParent(Application.dataPath).FullName, configName.Value + ".txt");
                folder2 = Path.Combine(Directory.GetParent(Application.dataPath).FullName, configSplitName.Value + ".txt");
            }
            else
            {
                folder = Path.Combine(configFolder.Value, configName.Value + ".txt");
                folder2 = Path.Combine(configFolder.Value, configSplitName.Value + ".txt");
            }

            minLength = configMinLength.Value;
            spacing = configSpacing.Value;

            newLevel = "";

            using (StreamWriter outputFile = new StreamWriter(folder))
            {
                outputFile.WriteLine(newLevel.PadRight(minLength) + "".PadRight(spacing));
            }
        }
        void Update()
        {
            newLevel = DiscordController.instance.cachedLevelName;
            if (oldLevel != newLevel)
            {
                if (configSplit.Value == false)
                {
                    using (StreamWriter outputFile = new StreamWriter(folder))
                    {
                        outputFile.WriteLine(newLevel.PadRight(minLength) + "".PadRight(spacing));
                    }
                }
                else
                {
                    if (newLevel == "") { }
                    else
                    {
                        splitLevel = newLevel.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                        using (StreamWriter outputFile = new StreamWriter(folder))
                        {
                            outputFile.WriteLine(splitLevel[1].PadRight(minLength) + "".PadRight(spacing));
                        }
                        using (StreamWriter outputFile = new StreamWriter(folder2))
                        {
                            outputFile.WriteLine(splitLevel[0].PadRight(minLength) + "".PadRight(spacing));
                        }
                    }
                }
            }
            oldLevel = newLevel;
        }
    }
}
