using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableLibrary/Variables/Color Variable")]
public class ColorVariable : ScriptableObject
{
    public Color value = Color.white;
}