using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableLibrary/Variables/Int Variable")]
public class IntVariable : ScriptableObjectArchitecture
{
    [Header("Main Property")]
    public int Value;

    public void SetValue(int value)
    {
        Value = value;
    }
}
