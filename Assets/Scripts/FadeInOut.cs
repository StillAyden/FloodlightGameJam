using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] TaskManager taskManager;
    [SerializeField] Image _firstBlackImage;
    [SerializeField] List<string> _whichDay = new List<string> { "DAY 1", "DAY 6", "Day 14", "Day 23" };
    [SerializeField] int _currentDay = 0;
    [SerializeField] TMP_Text _textWhichDay;

    private void OnEnable()
    {
        _currentDay = 0;
    }
    public void sendTaskManager()
    {
        _firstBlackImage.enabled = false;
        _textWhichDay.text = _whichDay[_currentDay];
        _currentDay++;
        taskManager.FadeOut();
    }
}
