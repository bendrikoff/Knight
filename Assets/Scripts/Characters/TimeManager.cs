using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public int Speed = 1;   //Для теста
    
    public Text PauseButtonText;

    public Text DateText;

    public int MaxTimeMultiplier = 4;

    private List<Month> _months;

    private Month _currentMonth;

    private float _deltaTime;

    public bool isPaused;

    private float _beforeStopTimeScale;

    private int _days;

    private int _year;
    public Action NextDay;
    public static TimeManager GetInstance() => Instance;

    private static TimeManager Instance = new TimeManager();
    
    public void StopTime()
    {
        if (!isPaused)
            _beforeStopTimeScale = Time.timeScale;
        Time.timeScale = 0;
        isPaused = true;
    }

    public void StartTime()
    {
        Time.timeScale = _beforeStopTimeScale;
        isPaused = false;
    }

    public void PauseButton()
    {
        if (isPaused)
        {
            StartTime();
            PauseButtonText.text = "Pause";
        }
        else
        {
            StopTime();
            PauseButtonText.text = "Play";
        }
    }

    public void SpeedUpTime()
    {
        if(Time.timeScale<MaxTimeMultiplier)
            Time.timeScale*=2;
    }

    public void SpeedDownTime()
    {
        if(Time.timeScale>1/MaxTimeMultiplier)
         Time.timeScale /= 2;
    }

    private void Start()
    {
        _year = 1000;
        MonthDaysInitialization();
        DayChange();
    }

    public void Update()
    {
        Time.timeScale = Speed;
        
        _deltaTime += Time.deltaTime;
        if (_deltaTime/180>1)
        {
            DayChange();
            _deltaTime = 0;
        }
    }

    private void DayChange()
    {
        _days++;
        DateText.text = _days+" "+_currentMonth.Name+" "+_year;
        NextDay?.Invoke();
        if (_days > _currentMonth.Days)
        {
            MonthChange();
        }
    }

    private void MonthChange()
    {
        _days = 1;
        if (_months.IndexOf(_currentMonth) == 12)
        {
            _currentMonth = _months[0];
            _year++;
        }
        else
        {
            _currentMonth = _months[_months.IndexOf(_currentMonth) + 1]; 
        }
        

    }

    private void MonthDaysInitialization()
    {
        _months = new List<Month>();
        _months.Add(new Month("Января",31));
        _months.Add(new Month("Февраля",28));
        _months.Add(new Month("Марта",31));
        _months.Add(new Month("Апреля",30));
        _months.Add(new Month("Мая",31));
        _months.Add(new Month("Июня",30));
        _months.Add(new Month("Июля",31));
        _months.Add(new Month("Августа",31));
        _months.Add(new Month("Сентября",30));
        _months.Add(new Month("Октября",31));
        _months.Add(new Month("Ноября",30));
        _months.Add(new Month("Декабря",31));
        _currentMonth = _months[0];
    }

    private class Month
    {
        public string Name;
        public int Days;

        public Month(string Name,int Days)
        {
            this.Name = Name;
            this.Days = Days;
        }
    }
}
