using System.Collections;
using System.Collections.Generic;
using BasicTools.ButtonInspector;
using UnityEngine;
using TMPro;

public class LevelHandler : MonoBehaviour
{
    [Header("Output Variables")]
    [SerializeField] private StringVariable durationLeftVariable;
    [SerializeField] private StringVariable coinVariable;
    [SerializeField] private StringVariable scoreVariable;
    [SerializeField] private GameEvent onGameStarted;
    [SerializeField] private GameEvent onGameStopped;
    [Header("Input Variables")]
    [SerializeField] private IntVariable scoreGained;
    [SerializeField] private SpriteRenderer characterSR;
    [SerializeField] private Sprite[] characterSprites;
    [Header("Panel Config")]
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI subtitle;

    public const float MaxDuration = 120f; //seconds
    private const int MaxScore = 1000;
    private const string CoinKey = "PLAYER_COIN";

    private int CurrentCoin => PlayerPrefs.GetInt(CoinKey, 0);

    private float _durationLeft;
    private bool _isPlaying;
    private int _currentScore = 0;

    private void Start()
    {
        durationLeftVariable.Value = "";
        coinVariable.Value = $"{CurrentCoin} Coin";
        scoreVariable.Value = $"Score: {_currentScore}/{MaxScore}";
    }

    private void Update()
    {
        if (!_isPlaying) return;

        _durationLeft -= Time.deltaTime;
        durationLeftVariable.Value = ((int)_durationLeft + 1).ToString();

        if (_durationLeft <= 0)
        {
            OnGameOver(false);
            StopPlaying();
        }
    }

    public void StartPlayingFromCharSelection(IntVariable characterFlag)
    {
        characterSR.sprite = characterSprites[characterFlag.Value];
        StartPlaying();
    }

    public void StartPlaying()
    {
        _currentScore = 0;
        scoreVariable.Value = $"Score: {_currentScore}/{MaxScore}";
        _durationLeft = MaxDuration;
        _isPlaying = true;
        onGameStarted.Raise();
    }

    private void StopPlaying()
    {
        durationLeftVariable.Value = "";
        _isPlaying = false;
        onGameStopped.Raise();
    }

    public void OnScoreGained()
    {
        if (!_isPlaying) return;

        _currentScore = _currentScore + scoreGained.Value < 0 ? 0 : _currentScore + scoreGained.Value;
        scoreVariable.Value = $"Score: {_currentScore}/{MaxScore}";

        if (_currentScore >= 1000)
        {
            OnGameOver(true);
        }
    }

    private void OnGameOver(bool isWin)
    {
        StopPlaying();

        if (isWin)
        {
            title.text = "You Win!";
            subtitle.text = $"You gain {(int)_durationLeft} Coins!";
        }
        else
        {
            title.text = "You Lose!";
            subtitle.text = $"Better luck next time!";
        }

        panel.SetActive(true);

        PlayerPrefs.SetInt(CoinKey, CurrentCoin + (int)_durationLeft);

        coinVariable.Value = $"{CurrentCoin} Coin";
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
