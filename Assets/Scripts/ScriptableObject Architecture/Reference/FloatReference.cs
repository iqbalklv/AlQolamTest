using UnityEngine;

[System.Serializable]
public class FloatReference
{
    [SerializeField] private bool useConstant = false;
    [SerializeField] private float constantValue = default;
    [SerializeField] private FloatVariable variable = default;

    public float Value
    {
        get
        {
            return useConstant ? constantValue : variable.Value;
        }
    }
}