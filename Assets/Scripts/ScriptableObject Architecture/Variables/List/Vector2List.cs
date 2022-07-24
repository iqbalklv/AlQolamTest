using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableLibrary/List/Vector2 List")]
public class Vector2List : ScriptableObject
{
    public List<Vector2> Value = new List<Vector2>();
}
