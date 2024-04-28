using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOutSelectedObject : MonoBehaviour
{
    [SerializeField] private CharacterMultiArrayObject currentLevelCharArray;
    [SerializeField] private GameObjectObject selectedObject, levelHolder;
    [SerializeField] private Vector3Object selectedPosition;
    [SerializeField] private GameObject wall, box, goal, player;

    private void Update()
    {
      ChangeSelected();
    }

    private void ChangeSelected()
    {
      if(selectedObject.value is not null)
      {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
          SpawnObject(wall);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
          SpawnObject(box);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
          SpawnObject(goal);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
          SpawnObject(player);
        }
        if(Input.GetKey(KeyCode.Alpha5))
        {
          DeleteObject();
        }
      }
    }

    private void SpawnObject(GameObject objToSpawn)
    {
      DeleteObject();
      GameObject tempSpawned = Instantiate(objToSpawn, selectedPosition.value, objToSpawn.transform.rotation, levelHolder.value.transform);
      selectedObject.value = tempSpawned;
    }

    private void DeleteObject()
    {
      try
      {
        if(selectedObject.value.tag != "Floor")
        {
          currentLevelCharArray.value[(int)selectedPosition.value.x, (int)selectedPosition.value.z] = ' ';
          Destroy(selectedObject.value);
          selectedObject.value = null;
        }
      }catch{}
    }
}
