using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System;
using UnityEngine.TextCore.Text;

public static class SaveGame
{
    /// <summary>
    /// Is taking the character data and checking a path for the data to be saved into a JSON file
    /// </summary>
    /// <param name="playerCharacter">Character</param>
    /// <param name="isAppend">bool</param>
    public static void PlaySaveGame (Character playerCharacter, bool isAppend)
    {
        string path = Application.persistentDataPath + "/dasavegame.gme";
        
        CharData playData = new CharData(playerCharacter);
        
        //Deleats the file if it exists and is not in append mode
        if (File.Exists(path) && !isAppend)
        {
            File.Delete(path);
        }

        // Writes or appends file data
        //https://learn.microsoft.com/en-us/dotnet/api/system.io.filestream?view=net-8.0
        using (FileStream stream = File.Open(path, FileMode.Append))
        {
            //Serialize the characters data into JSON format
            byte[] data = new UTF8Encoding(true).GetBytes(JsonUtility.ToJson(playData));

            //Adding one to the array size and places a newline character
            Array.Resize(ref data, data.Length + 1);
            data[data.Length - 1] = (byte)'\n';

            stream.Write(data, 0, data.Length);
        }

    }

    /// <summary>
    /// Loads the characters data to the game from the JSON save file 
    /// </summary>
    /// <returns></returns>
    public static CharData[] LoadPlayChar()
    {
        string path = Application.persistentDataPath + "/dasavegame.gme";
        try
        {
            //https://stackoverflow.com/questions/8037070/whats-the-fastest-way-to-read-a-text-file-line-by-line
            const Int32 BufferSize = 128;
            CharData playData = null;
            CharData oppData = null;

            int lineNum = 0;
            CharData[] characterData;
            characterData = new CharData[2];

            //Reads the path of the filestream where the save data is located 
            using (FileStream fileStream = File.OpenRead(path))
            using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    line = line.TrimEnd('\r','\n');

                    //Retrieves the player characters stats for the game
                    if (lineNum == 0)
                    {
                        playData = JsonUtility.FromJson<CharData>(line);
                    }
                    //Retrieves the opponent characters stats for the game
                    else if (lineNum == 1)
                    {

                        oppData = JsonUtility.FromJson<CharData>(line);
                    }
                    lineNum++;
                }
            }

            characterData[0] = playData;
            characterData[1] = oppData;

            return characterData;
        }
        catch (Exception e)
        {

            Debug.LogError("Save not found in " + path + e.Message);
            return null;
        }
    }

    /// <summary>
    /// Converts the data loaded from the CharData class to the Character class 
    /// </summary>
    /// <param name="characterData"></param>
    /// <param name="aCharacter"></param>
    /// <returns></returns>
    public static Character ConvertData(CharData characterData, Character aCharacter)
    {
        aCharacter.charName = characterData.playCharName;
        aCharacter.charMaxHealth = characterData.playCharMaxHealth;
        aCharacter.charCurrentHealth = characterData.playCharCurrentHealth;
        aCharacter.charMaxEnergy = characterData.playCharMaxEnergy;
        aCharacter.charCurrentEnergy = characterData.playCharCurrentEnergy;
        aCharacter.charSkill = characterData.playCharSkill;
        aCharacter.charProt= characterData.playCharProt;
        aCharacter.charCurrentProt = characterData.playCharCurrentProt;
        aCharacter.charSpeed = characterData.playCharSpeed;

        return aCharacter;   
    }
}
