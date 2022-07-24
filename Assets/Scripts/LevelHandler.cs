using System.Collections;
using System.Collections.Generic;
using BasicTools.ButtonInspector;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [Header("Output Variables")]
    [SerializeField] private StringVariable durationLeftVariable;
    [SerializeField] private GameEvent onGameStarted;
    [SerializeField] private GameEvent onGameStopped;

    public const float MaxDuration = 120f; //seconds
    private float _durationLeft;
    private bool _isPlaying;


    private void Update()
    {
        if (!_isPlaying) return;

        _durationLeft -= Time.deltaTime;
        durationLeftVariable.Value = ((int)_durationLeft + 1).ToString();

        if(_durationLeft <= 0)
        {
            StopPlaying();
        }
    }

    public void StartPlaying()
    {
        _durationLeft = MaxDuration;
        _isPlaying = true;
        onGameStarted.Raise();
    }

    private void StopPlaying()
    {
        _isPlaying = false;
        onGameStopped.Raise();
    }

    [Button("Start Game", nameof(StartPlayingDebug))]
    public bool btn;
    public void StartPlayingDebug()
    {
        StartPlaying();
    }

    [Button("Stop Game", nameof(StopPlayingDebug))]
    public bool btn1;
    public void StopPlayingDebug()
    {
        StopPlaying();
    }
}
