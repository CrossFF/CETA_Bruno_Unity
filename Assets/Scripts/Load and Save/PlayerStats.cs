using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    public bool neverPlay;
    public int score;
    public int lastLevel;

    public PlayerStats(bool _neverPlay, int _score, int _lastLevel)
    {
        neverPlay = _neverPlay;
        score = _score;
        lastLevel = _lastLevel;
    }

    public PlayerStats(int _score, int _lastLevel)
    {
        neverPlay = false;
        score = _score;
        lastLevel = _lastLevel;
    }
}
