using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableLibrary/List/Int List")]
public class IntList : ScriptableObject
{
    public List<int> Value = new List<int>();
}
