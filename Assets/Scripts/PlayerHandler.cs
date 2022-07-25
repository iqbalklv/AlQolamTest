using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private BoolVariable isCasting;
    [SerializeField] private RodHandler rodHandler;
    private bool _isGameStarted;

    public void OnGameStarted()
    {
        _isGameStarted = true;
        isCasting.Value = false;
    }

    public void OnGameStopped()
    {
        _isGameStarted = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Cast();
        }
    }

    private async void Cast()
    {
        if (!_isGameStarted) return;
        if (isCasting.Value) return;
        isCasting.Value = true;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, (mouseWorldPos - (Vector2)rayOrigin.position).normalized);

        rodHandler.OnCast(mouseWorldPos);
        
        if (hit.collider != null)
        {
            hit.collider.gameObject.GetComponent<CatchableObject>().OnCaught(isCasting, rayOrigin.position);
        }
        else
        {
            await Task.Delay(TimeSpan.FromSeconds(1.7f));
            isCasting.Value = false;
        }
    }
}
