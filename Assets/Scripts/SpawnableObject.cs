using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class SpawnableObject : MonoBehaviour
{
    public Type ObjectType;
    [SerializeField] private float speed;
    [SerializeField] private bool isFlipable;
    [SerializeField] private Sprite[] sprites;

    private SpriteRenderer _spriteRenderer;
    private float[] bound = new float[2];
    private float _boundOffset = 2f;
    private float _initialXScale;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _initialXScale = transform.localScale.x;

        Camera cam = Camera.main;
        
        bound[0] = cam.ScreenToWorldPoint(new Vector3(0f, 0f, cam.nearClipPlane)).x - _boundOffset;
        bound[1] = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, cam.nearClipPlane)).x + _boundOffset;
    }

    private void OnEnable()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }

    public async void Move(int direction)
    {
        transform.position = new Vector3(direction > 0 ? bound[0] + _boundOffset : bound[1] - _boundOffset, Random.Range(0f, -4f), 0f);

        if (isFlipable)
        {
            transform.localScale = new Vector3(_initialXScale * direction, transform.localScale.y, transform.localScale.z);
        }

        do
        {
            if (Time.timeScale <= 0) continue;
            
            transform.Translate(speed * Time.deltaTime * direction, 0f, 0f);
            await Task.Delay(TimeSpan.FromSeconds(Time.deltaTime));

        } while (transform.position.x > bound[0] && transform.position.x < bound[1]);

        gameObject.SetActive(false);
    }

    public enum Type
    {
        Hazard,
        Objective
    }
}
