using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableLibrary/Variables/String Variable")]
public class StringVariable : ScriptableObjectArchitecture
{
    [Header("Main Property")]
    public string Value;

    public void SetValue(string newValue)
    {
        Value = newValue;
    }
}