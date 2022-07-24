using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableObjectArchitecture : ScriptableObject
{
    [Header("Dev Property")]
    [TextArea(1, 5)]
    [SerializeField] private string notes;
}
