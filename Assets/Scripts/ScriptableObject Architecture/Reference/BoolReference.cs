using UnityEngine;

[System.Serializable]
public class BoolReference
{
    [SerializeField] private bool useConstant = false;
    [SerializeField] private bool constantValue = default;
    [SerializeField] private BoolVariable variable = default;

    public bool Value
    {
        get
        {
            return useConstant ? constantValue : variable.Value;
        }
    }

    public BoolVariable Variable
    {
        get
        {
            return variable;
        }
    }
}