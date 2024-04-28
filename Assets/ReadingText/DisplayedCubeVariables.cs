using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[ExecuteInEditMode]
public class DisplayedCubeVariables : MonoBehaviour
{
    public Vector3 size;
    public GameObjectObject selectedObject;
    [SerializeField] private GameObject wall, box, goal, player;
    private Vector3 tempPosition;

    private void Update()
    {
      if(Input.GetKeyDown(KeyCode.J))
      {
        if(selectedObject.value is not null)
        {
          if(selectedObject.value.tag == "Floor")
          {
            tempPosition = new Vector3(selectedObject.value.transform.position.x, selectedObject.value.transform.position.y + 1f, selectedObject.value.transform.position.z);
          } else {
            tempPosition = selectedObject.value.transform.position;
            Destroy(selectedObject.value);
          }
          Instantiate(wall, tempPosition, wall.transform.rotation);
        }
      }
    }

}
