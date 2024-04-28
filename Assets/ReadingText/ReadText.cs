using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;



public class ReadText : MonoBehaviour
{
    private char[,] levelLayout = new char[100, 100];
    [SerializeField] private int levelNumber;
    [SerializeField] private GameObjectObject levelHolder;
    [SerializeField] private GameObject holder;

    [SerializeField] private GameObject wall, floor, box, goal, player;



    void Update()
    {
      if(Input.GetKeyDown(KeyCode.G) && levelNumber < 51 && levelNumber > 0)
      {
        if(holder is not null)
        {
          Destroy(holder);
        }
        string filePath = Application.streamingAssetsPath + "/Levels/" + levelNumber.ToString();
        ReadTextFile(filePath);
        levelNumber++;
      }
    }


    private void ReadTextFile(string filePath)
    {
      holder = new GameObject("Holder");
      levelHolder.value = holder;
      int currentLayer = 0;
      string[] readText = File.ReadAllLines(filePath);

      foreach(string text in readText)
      {
        for(int currentColumn = 0; currentColumn < text.Length; currentColumn++)
        {
          levelLayout[currentLayer, currentColumn] = text[currentColumn];
        }
        currentLayer++;
      }

      for(int currentLaye = 0; currentLaye < levelLayout.GetLength(0); currentLaye++)
      {
        for(int currentCharacter = 0; currentCharacter < levelLayout.GetLength(1); currentCharacter++)
        {
          char curBean = levelLayout[currentLaye, currentCharacter];
          if(curBean == '@')
          {
            Instantiate(wall, new Vector3(currentLaye, wall.transform.position.y, currentCharacter), wall.transform.rotation, holder.transform);
            Instantiate(floor, new Vector3(currentLaye, floor.transform.position.y, currentCharacter), floor.transform.rotation, holder.transform);
          }
          if(curBean == ' ')
          {
            Instantiate(floor, new Vector3(currentLaye, floor.transform.position.y, currentCharacter), floor.transform.rotation, holder.transform);
          }
          if(curBean == 'o' || curBean == 'O')
          {
            Instantiate(box, new Vector3(currentLaye, box.transform.position.y, currentCharacter), box.transform.rotation, holder.transform);
            Instantiate(floor, new Vector3(currentLaye, floor.transform.position.y, currentCharacter), floor.transform.rotation, holder.transform);
          }
          if(curBean == 'x' || curBean == 'X')
          {
            Instantiate(goal, new Vector3(currentLaye, goal.transform.position.y, currentCharacter), goal.transform.rotation, holder.transform);
            Instantiate(floor, new Vector3(currentLaye, floor.transform.position.y, currentCharacter), floor.transform.rotation, holder.transform);
          }
          if(curBean == 'V' || curBean == '<' || curBean == '>' || curBean == '^' || curBean == 'v')
          {
            Instantiate(player, new Vector3(currentLaye, player.transform.position.y, currentCharacter), player.transform.rotation, holder.transform);
            Instantiate(floor, new Vector3(currentLaye, floor.transform.position.y, currentCharacter), floor.transform.rotation, holder.transform);
          }
        }
      }

    }
}
