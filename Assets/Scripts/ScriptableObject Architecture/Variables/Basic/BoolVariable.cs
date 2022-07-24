using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableLibrary/Variables/Bool Variable")]
public class BoolVariable : ScriptableObjectArchitecture
{
    [Header("Main Property")]
    public bool Value;

    public void SetValue(bool value)
    {
        Value = value;
    }
}
