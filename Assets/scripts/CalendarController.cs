﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Events;
using UnityEngine.Android;

public class CalendarController : MonoBehaviour
{
    public GameObject _calendarPanel;
    public Text _yearNumText;
    public Text _monthNumText;
    public static string plsplspls;
    public GameObject _item;

    public static string APM1;
    public static bool AM1;
    public static bool AM2;
    public static bool AM3;

    public static string time1;
    public static string time2;
    public static string time3;

    public static string note1;
    public static string note2;
    public static string note3;

    public List<GameObject> _dateItems = new List<GameObject>();
    const int _totalDateNum = 42;

    private DateTime _dateTime;
    public static CalendarController _calendarInstance;

    void Start()
    {
        APM1 = GameObject.Find("APM button1").GetComponent<Text>();
        AM1 = true;
        AM2 = true;
        AM3 = true;
        bool pandan = true;
        /*if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }*/
        _calendarPanel.SetActive(true);
        _calendarInstance = this;
        Vector3 startPos = _item.transform.localPosition;
        _dateItems.Clear();
        _dateItems.Add(_item);

        for (int i = 1; i < _totalDateNum; i++)
        {
            GameObject item = GameObject.Instantiate(_item) as GameObject;
            item.name = "Item" + (i + 1).ToString();
            item.transform.SetParent(_item.transform.parent);
            item.transform.localScale = Vector3.one;
            item.transform.localRotation = Quaternion.identity;
            item.transform.localPosition = new Vector3((i % 7) * 36  + startPos.x, startPos.y - (i / 7) * 30, startPos.z);

            _dateItems.Add(item);
        }

        _dateTime = DateTime.Now;

        CreateCalendar();

        //_calendarPanel.SetActive(false);
    }
    void Update()
    {
 
        
    }
    void CreateCalendar()
    {
        DateTime firstDay = _dateTime.AddDays(-(_dateTime.Day - 1));
        int index = GetDays(firstDay.DayOfWeek);

        int date = 0;
        for (int i = 0; i < _totalDateNum; i++)
        {
            Text label = _dateItems[i].GetComponentInChildren<Text>();
            _dateItems[i].SetActive(false);

            if (i >= index)
            {
                DateTime thatDay = firstDay.AddDays(date);
                if (thatDay.Month == firstDay.Month)
                {
                    _dateItems[i].SetActive(true);

                    label.text = (date + 1).ToString();
                    date++;
                }
            }
        }
        _yearNumText.text = _dateTime.Year.ToString();
        _monthNumText.text = _dateTime.Month.ToString("D2");
    }

    int GetDays(DayOfWeek day)
    {
        switch (day)
        {
            case DayOfWeek.Monday: return 1;
            case DayOfWeek.Tuesday: return 2;
            case DayOfWeek.Wednesday: return 3;
            case DayOfWeek.Thursday: return 4;
            case DayOfWeek.Friday: return 5;
            case DayOfWeek.Saturday: return 6;
            case DayOfWeek.Sunday: return 0;
        }

        return 0;
    }
    public void YearPrev()
    {
        _dateTime = _dateTime.AddYears(-1);
        CreateCalendar();
    }

    public void YearNext()
    {
        _dateTime = _dateTime.AddYears(1);
        CreateCalendar();
    }

    public void MonthPrev()
    {
        _dateTime = _dateTime.AddMonths(-1);
        CreateCalendar();
    }

    public void MonthNext()
    {
        _dateTime = _dateTime.AddMonths(1);
        CreateCalendar();
    }

    public void ShowCalendar(Text target)
    {
        _calendarPanel.SetActive(true);
        _target = target;
        //_calendarPanel.transform.position = new Vector3(965, 475, 0);//Input.mousePosition-new Vector3(0,120,0);
    }

    Text _target;

    //Item 클릭했을 경우 Text에 표시.
    public void OnDateItemClick(string day)
    {
        //_target.text = _yearNumText.text + "-" + _monthNumText.text + "-" + int.Parse(day).ToString("D2");
        //_calendarPanel.SetActive(false);
        Debug.Log(_yearNumText.text + "-" + _monthNumText.text + "-" + day);
        plsplspls = Convert.ToString(day);
        Debug.Log(plsplspls);
    }

    public void APM1Click()
    {
        if (AM1 == true)
        {
            APM1.text = "PM";
            AM1 = false;
        }

        if (AM1 == false)
        {
            APM1.text = "AM";
            AM1 = true;
        }
    }

    public void Note1(InputField NoteField1)
    {
        Debug.Log("메모 테스트: " + NoteField1.text);
        Debug.Log(plsplspls);
        string fullPath = "Assets/test/";
        if (File.Exists(fullPath) == false)
        {
            var file = File.CreateText(fullPath + _yearNumText.text + "-" + _monthNumText.text + "-" + plsplspls + ".txt");
            file.Close();
        }
        //Debug.Log(DateTime.Now.ToString("yyyy"));
        StreamWriter sw = new StreamWriter(fullPath + _yearNumText.text + "-" + _monthNumText.text + "-" + plsplspls + ".txt");
        string memomemo = NoteField1.text;
        //Debug.Log(Testff.text);
        sw.WriteLine(memomemo);
        sw.Flush();
        sw.Close();
    }

}
