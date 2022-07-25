using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnableObject))]
public class CatchableObject : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private IntVariable scoreGained;
    [SerializeField] private GameEvent onScoreGained;
    private SpawnableObject _spawnableObject;

    private void Awake()
    {
        _spawnableObject = GetComponent<SpawnableObject>();
    }

    public void OnCaught(BoolVariable isCasting, Vector2 origin)
    {
        _spawnableObject.CancelMove();
        LeanTween.moveLocal(gameObject, origin, 1.2f).setDelay(.5f).setEaseInCubic().setOnComplete(() =>
       {
           isCasting.Value = false;
           gameObject.SetActive(false);
           scoreGained.Value = score;
           onScoreGained.Raise();
       });
    }
}
