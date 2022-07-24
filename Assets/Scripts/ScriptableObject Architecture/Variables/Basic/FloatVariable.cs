using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableLibrary/Variables/Float Variable")]
public class FloatVariable : ScriptableObjectArchitecture
{
    [Header("Main Property")]
    public float Value;

    public void SetValue(float value)
    {
        Value = value;
    }
}
