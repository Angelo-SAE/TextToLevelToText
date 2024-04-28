using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLevel : MonoBehaviour
{
    [SerializeField] private IntObject savedLevelNumber;
    [SerializeField] private CharacterMultiArrayObject currentLevelCharArray;

    private void Update()
    {
      if(Input.GetKeyDown(KeyCode.D))
      {
        CreateTextFromCharArray();
      }
    }

    private void CreateTextFromCharArray()
    {
      string charString = "";
      for(int a = 0; a < currentLevelCharArray.value.GetLength(0); a++)
      {
        for(int b = 0; b < currentLevelCharArray.value.GetLength(1); b++)
        {
          charString += currentLevelCharArray.value[a,b];
        }
        charString += "\n";
      }
      CreateTextFile(charString);
    }

    private void CreateTextFile(string charString)
    {
      string path = Application.streamingAssetsPath + "/SavedLevels/savedLevel" + savedLevelNumber.value.ToString();

      File.WriteAllText(path, charString);

      savedLevelNumber.value++;
    }
}
