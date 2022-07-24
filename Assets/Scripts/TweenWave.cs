using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenWave : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float time;


    private void Start()
    {
        StartWave();
    }

    private void StartWave()
    {
        LeanTween.moveLocal(gameObject, endPosition, time).setOnComplete(() =>
        {
            LeanTween.moveLocal(gameObject, startPosition, time).setOnComplete(() =>
            {
                StartWave();
            });
        });
    }
}