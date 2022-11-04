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
    public static string _dayNumText;
    public GameObject _item;

    public static Text APM1;
    public static Text APM2;
    public static Text APM3;

    public static bool AM1;
    public static bool AM2;
    public static bool AM3;
    public static bool pandan;

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
        //텍스트 레이어 지정
        APM1 = GameObject.Find("APM Text1").GetComponent<Text>();
        APM2 = GameObject.Find("APM Text2").GetComponent<Text>();
        APM3 = GameObject.Find("APM Text3").GetComponent<Text>();

        AM1 = true;
        AM2 = true;
        AM3 = true;

        note1 = "";
        note2 = "";
        note3 = "";
        
        pandan = true;

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
        _dayNumText = Convert.ToString(day);
        
        string[] textValue = System.IO.File.ReadAllLines(path);
        bool justice;
        justice = true;
        int i;
        i = 0;
        while (justice == true)
        {
            if (i < 9)
            {
                sw.WriteLine(textValue[i]);
                i += 1;
            }

            else
            {
                justice = false;    
            }
        }
    }

    public void APM1Click()
    {
        while (pandan == true)
        {
            if (AM1 == true)
                {
                    APM1.text = "PM";
                    AM1 = false;
                    break;
                }

            if (AM1 == false)
                {
                    APM1.text = "AM";
                    AM1 = true;
                    break;
                }   
        }
    }

    public void APM2Click()
    {
        while (pandan == true)
        {
            if (AM2 == true)
                {
                    APM2.text = "PM";
                    AM2 = false;
                    break;
                }

            if (AM2 == false)
                {
                    APM2.text = "AM";
                    AM2 = true;
                    break;
                }   
        }
    }

    public void APM3Click()
    {
        while (pandan == true)
        {
            if (AM3 == true)
                {
                    APM3.text = "PM";
                    AM3 = false;
                    break;
                }

            if (AM3 == false)
                {
                    APM3.text = "AM";
                    AM3 = true;
                    break;
                }   
        }
    }

    public void Note1(InputField NoteField1)
    {
        Debug.Log("메모 테스트: " + NoteField1.text);
        note1 = NoteField1.text;
        Debug.Log(note1);
    }

    public void Note2(InputField NoteField2)
    {
        Debug.Log("메모 테스트: " + NoteField2.text);
        note2 = NoteField2.text;
        Debug.Log(note2);
    }

    public void Note3(InputField NoteField3)
    {
        Debug.Log("메모 테스트: " + NoteField3.text);
        note3 = NoteField3.text;
        Debug.Log(note3);
    }

    public void SaveNote()
    {
        string fullPath = "Assets/test/";
        if (File.Exists(fullPath) == false)
        {
            var file = File.CreateText(fullPath + _yearNumText.text + "-" + _monthNumText.text + "-" + _dayNumText + ".txt");
            file.Close();
        }
        //Debug.Log(DateTime.Now.ToString("yyyy"));
        StreamWriter sw = new StreamWriter(fullPath + _yearNumText.text + "-" + _monthNumText.text + "-" + _dayNumText + ".txt");
        
        sw.WriteLine(AM1);
        sw.WriteLine(AM2);
        sw.WriteLine(AM3);

        sw.WriteLine(note1);
        sw.WriteLine(note2);
        sw.WriteLine(note3);

        sw.Flush();
        sw.Close();
        Debug.Log("save");
    }

}
