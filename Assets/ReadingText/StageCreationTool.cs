using UnityEngine;
using UnityEditor;
using System.IO;

public class StageCreationTool : EditorWindow
{

  private GameObjectObject selectedObject;
  private char[,] levelLayout;

  private TextAsset textTest;
  private GameObject wall, box, goal, player;

  [MenuItem("Tools/Basic Text To Level Generator")]
  private static void ShowWindow()
  {
    GetWindow(typeof(StageCreationTool));
  }

  private void OnGUI()
  {
    GUILayout.Label("Basic Text To Level Generator", EditorStyles.boldLabel);

    textTest = EditorGUILayout.ObjectField("Level Text", textTest, typeof(TextAsset), false) as TextAsset;
    selectedObject = EditorGUILayout.ObjectField("Selected Object", selectedObject, typeof(GameObjectObject), false) as GameObjectObject;
    wall = EditorGUILayout.ObjectField("wall", wall, typeof(GameObject), false) as GameObject;
    box = EditorGUILayout.ObjectField("box", box, typeof(GameObject), false) as GameObject;
    goal = EditorGUILayout.ObjectField("goal", goal, typeof(GameObject), false) as GameObject;
    player = EditorGUILayout.ObjectField("player", player, typeof(GameObject), false) as GameObject;

    if(GUILayout.Button("Generate Level"))
    {
      GenerateLevel();
    }
  }

  private void GenerateLevel()
  {

    GameObject holder = new GameObject("Holder");
    int currentLayer = 0;
    int currentChar = 0;
    int maxChar = 0;
    string filePath = AssetDatabase.GetAssetPath(textTest);
    string[] readText = File.ReadAllLines(filePath);

    foreach(string text in readText)
    {
      currentLayer++;
      for(int currentColumn = 0; currentColumn < text.Length; currentColumn++)
      {
        currentChar++;
      }
      if(currentChar > maxChar)
      {
        maxChar = currentChar;
      }

    }

    levelLayout = new char[currentLayer, maxChar];
    currentLayer = 0;

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
        }
        if(curBean == 'O')
        {
          Instantiate(box, new Vector3(currentLaye, box.transform.position.y, currentCharacter), box.transform.rotation, holder.transform);
        }
        if(curBean == 'X')
        {
          Instantiate(goal, new Vector3(currentLaye, goal.transform.position.y, currentCharacter), goal.transform.rotation, holder.transform);
        }
        if(curBean == 'P')
        {
          Instantiate(player, new Vector3(currentLaye, player.transform.position.y, currentCharacter), player.transform.rotation, holder.transform);
        }
      }

}}}
