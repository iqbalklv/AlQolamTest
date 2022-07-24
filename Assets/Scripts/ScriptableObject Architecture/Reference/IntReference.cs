using UnityEngine;

[System.Serializable]
public class IntReference
{
    [SerializeField] private bool useConstant = false;
    [SerializeField] private int constantValue = default;
    [SerializeField] private IntVariable variable = default;

    public int Value
    {
        get
        {
            return useConstant ? constantValue : variable.Value;
        }
    }
}
