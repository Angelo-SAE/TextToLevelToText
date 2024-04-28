using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DisplayedCubeVariables))]
public class DrawCubePreview : Editor
{
    public static Vector3 currentPosition = Vector3.zero;
    public static bool isMouseInValidArea = false;

    private static Vector3 oldPosition = Vector3.zero;

    private void OnSceneGUI()
    {
      //UpdateCurrentPosition();
    }

    private void UpdateCurrentPosition()
    {
      Handles.color = Color.green;
      Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
      RaycastHit hit;
      DisplayedCubeVariables myObj = (DisplayedCubeVariables)target;
      if(Physics.Raycast(ray, out hit))
      {
        if(hit.transform.tag == "Floor")
        {
          currentPosition = new Vector3(hit.transform.position.x, hit.transform.position.y + 1f, hit.transform.position.z);
        } else {
          currentPosition = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);
        }
        myObj.selectedObject.value = hit.transform.gameObject;
        Handles.DrawWireCube(currentPosition, myObj.size);
      } else {
        myObj.selectedObject.value = null;
      }

      var e = Event.current;
      if (e != null && e.keyCode != KeyCode.None)
      {
        Debug.Log("Key pressed in editor: " + e.keyCode);
      }

      SceneView.RepaintAll();
    }
}
