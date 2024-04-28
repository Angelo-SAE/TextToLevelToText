using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterMultiArrayObject", menuName = "VariableObjects/CharacterMultiArrayObject", order = 100)]
public class CharacterMultiArrayObject : ScriptableObject
{
    public char[,] value;
}
