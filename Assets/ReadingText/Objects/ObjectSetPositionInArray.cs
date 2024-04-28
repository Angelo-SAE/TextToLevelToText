using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSetPositionInArray : MonoBehaviour
{
    [SerializeField] private CharacterMultiArrayObject currentLevelCharArray;
    [SerializeField] private char objectCharacter;

    private void Awake()
    {
      SetPostionInArray();
    }

    private void SetPostionInArray()
    {
      currentLevelCharArray.value[(int)transform.position.x, (int)transform.position.z] = objectCharacter;
    }
}
