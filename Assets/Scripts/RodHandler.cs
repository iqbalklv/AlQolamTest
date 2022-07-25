using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodHandler : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform threadOrigin;
    [SerializeField] private Transform threadTarget;
    private Vector3 _threadIdlePos;

    private void Awake()
    {
        _threadIdlePos = threadTarget.localPosition;
    }

    public void OnCast(Vector2 targetPos)
    {
        LeanTween.move(threadTarget.gameObject, targetPos, .5f).setOnComplete( () =>
        {
            LeanTween.moveLocal(threadTarget.gameObject, _threadIdlePos, 1.2f).setEaseInCubic();
        });

    }

    private void Update()
    {
        lineRenderer.SetPosition(0, threadOrigin.position);
        lineRenderer.SetPosition(1, threadTarget.position);
    }
}
