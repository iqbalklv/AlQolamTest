using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TMPUpdater : MonoBehaviour
{
    [SerializeField] private StringVariable listenedValue;
    private TextMeshProUGUI _tmp;

    private void Awake()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _tmp.text = listenedValue.Value;
    }
}
