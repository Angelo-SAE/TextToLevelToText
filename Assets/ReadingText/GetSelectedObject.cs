using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSelectedObject : MonoBehaviour
{
    [SerializeField] private GameObjectObject selectedObject;
    [SerializeField] private Vector3Object currentSelectedPosition;
    [SerializeField] private Vector3 size;
    [SerializeField] private Camera viewCamera;

    private void OnDrawGizmos()
    {
      Gizmos.DrawWireCube(currentSelectedPosition.value, size);
    }

    private void Update()
    {
      RaycastFromCamera();
    }

    private void RaycastFromCamera()
    {
      RaycastHit hit;
      Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);

      if(Physics.Raycast(ray, out hit))
      {
        if(hit.transform.tag == "Floor")
        {
          currentSelectedPosition.value = new Vector3(hit.transform.position.x, hit.transform.position.y + 1f, hit.transform.position.z);
        } else {
          currentSelectedPosition.value = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);
        }
        selectedObject.value = hit.transform.gameObject;
      } else {
        selectedObject.value = null;
      }
    }
}
