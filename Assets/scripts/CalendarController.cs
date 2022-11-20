using System;
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
    public GameObject bgi;
    public Image BGImage;
    public static Text NoteText1;
    public static Text NoteText2;
    public static Text NoteText3;
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
    public static InputField input1;
    public static InputField input2;
    public static InputField input3;
    public static InputField timeinput1;
    public static InputField timeinput2;
    public static InputField timeinput3;
    public static Text tabni1;
    public static Text tabni2;
    public static Text tabni3;
    public List<GameObject> _dateItems = new List<GameObject>();
    const int _totalDateNum = 42;
    private DateTime _dateTime;
    public static CalendarController _calendarInstance;
    [SerializeField]
    public Sprite[] sprites;
    public int index;
    public int monthint;
    public static Text Monthtext;
    void Start()
    {
        //텍스트 레이어 지정
        APM1 = GameObject.Find("APM Text1").GetComponent<Text>();
        APM2 = GameObject.Find("APM Text2").GetComponent<Text>();
        APM3 = GameObject.Find("APM Text3").GetComponent<Text>();
        Monthtext = GameObject.Find("MONTH").GetComponent<Text>();

        GameObject tabni1 = GameObject.Find("TimeField1");
        timeinput1 = tabni1.GetComponent<InputField>();

        GameObject tabni2 = GameObject.Find("TimeField2");
        timeinput2 = tabni2.GetComponent<InputField>();

        GameObject tabni3 = GameObject.Find("TimeField3");
        timeinput3 = tabni3.GetComponent<InputField>();
        
        GameObject NoteText1 = GameObject.Find("NoteField1");
        input1 = NoteText1.GetComponent<InputField>();

        GameObject NoteText2 = GameObject.Find("NoteField2");
        input2 = NoteText2.GetComponent<InputField>();

        GameObject NoteText3 = GameObject.Find("NoteField3");
        input3 = NoteText3.GetComponent<InputField>();

        GameObject bgi = GameObject.Find("backimage");
        BGImage = bgi.GetComponent<Image>();

        AM1 = true;
        AM2 = true;
        AM3 = true;
        
        note1 = "";
        note2 = "";
        note3 = "";

        time1 = "";
        time2 = "";
        time3 = "";

        pandan = true;

        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageRead);
        }
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }
        
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

    void Update()
    {
        switch (int.Parse(_monthNumText.text))
        {
            case 1:
                Monthtext.text = "₀₁ January";
                BGImage.sprite = sprites[3];
                GameObject.Find("APM button1").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("APM button2").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("APM button3").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("TimeField1").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("TimeField2").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("TimeField3").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("save").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("disk").GetComponent<Image>().color = new Color32(105,138,179,255);
                GameObject.Find("Yearbox").GetComponent<Image>().color = new Color32(105,138,179,255);
                break;
            case 2:
                Monthtext.text = "₀₂ February";
                BGImage.sprite = sprites[3];
                GameObject.Find("APM button1").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("APM button2").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("APM button3").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("TimeField1").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("TimeField2").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("TimeField3").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("save").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("disk").GetComponent<Image>().color = new Color32(105,138,179,255);
                GameObject.Find("Yearbox").GetComponent<Image>().color = new Color32(105,138,179,255);
                break;
            case 3:
                Monthtext.text = "₀₃ March";
                BGImage.sprite = sprites[0];
                GameObject.Find("APM button1").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("APM button2").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("APM button3").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("TimeField1").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("TimeField2").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("TimeField3").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("save").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("disk").GetComponent<Image>().color = new Color32(172,112,173,255);
                GameObject.Find("Yearbox").GetComponent<Image>().color = new Color32(172,112,173,255);
                break;
            case 4:
                Monthtext.text = "₀₄ April";
                BGImage.sprite = sprites[0];
                GameObject.Find("APM button1").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("APM button2").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("APM button3").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("TimeField1").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("TimeField2").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("TimeField3").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("save").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("disk").GetComponent<Image>().color = new Color32(172,112,173,255);
                GameObject.Find("Yearbox").GetComponent<Image>().color = new Color32(172,112,173,255);
                break;
            case 5:
                Monthtext.text = "₀₅ May"; 
                BGImage.sprite = sprites[0];
                GameObject.Find("APM button1").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("APM button2").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("APM button3").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("TimeField1").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("TimeField2").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("TimeField3").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("save").GetComponent<Image>().color = new Color32(203,168,204,255);
                GameObject.Find("disk").GetComponent<Image>().color = new Color32(172,112,173,255);
                GameObject.Find("Yearbox").GetComponent<Image>().color = new Color32(172,112,173,255);
                break;
            case 6:
                Monthtext.text = "₀₆ June";
                BGImage.sprite = sprites[1];
                GameObject.Find("APM button1").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("APM button2").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("APM button3").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("TimeField1").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("TimeField2").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("TimeField3").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("save").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("disk").GetComponent<Image>().color = new Color32(45,124,239,255);
                GameObject.Find("Yearbox").GetComponent<Image>().color = new Color32(45,124,239,255);
                break;
            case 7:
                Monthtext.text = "₀₇ July";
                BGImage.sprite = sprites[1];
                GameObject.Find("APM button1").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("APM button2").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("APM button3").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("TimeField1").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("TimeField2").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("TimeField3").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("save").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("disk").GetComponent<Image>().color = new Color32(45,124,239,255);
                GameObject.Find("Yearbox").GetComponent<Image>().color = new Color32(45,124,239,255);
                break;
            case 8:
                Monthtext.text = "₀₈ August";
                BGImage.sprite = sprites[1];
                GameObject.Find("APM button1").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("APM button2").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("APM button3").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("TimeField1").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("TimeField2").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("TimeField3").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("save").GetComponent<Image>().color = new Color32(134,193,246,255);
                GameObject.Find("disk").GetComponent<Image>().color = new Color32(45,124,239,255);
                GameObject.Find("Yearbox").GetComponent<Image>().color = new Color32(45,124,239,255);
                break;
            case 9:
                Monthtext.text = "₀₉ September";
                BGImage.sprite = sprites[2];
                GameObject.Find("APM button1").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("APM button2").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("APM button3").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("TimeField1").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("TimeField2").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("TimeField3").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("save").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("disk").GetComponent<Image>().color = new Color32(218,110,62,255);
                GameObject.Find("Yearbox").GetComponent<Image>().color = new Color32(218,110,62,255);
                break;
            case 10:
                Monthtext.text = "₁₀ October";
                BGImage.sprite = sprites[2];
                GameObject.Find("APM button1").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("APM button2").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("APM button3").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("TimeField1").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("TimeField2").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("TimeField3").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("save").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("disk").GetComponent<Image>().color = new Color32(218,110,62,255);
                GameObject.Find("Yearbox").GetComponent<Image>().color = new Color32(218,110,62,255);
                break;
            case 11:
                Monthtext.text = "₁₁ November";
                BGImage.sprite = sprites[2];
                GameObject.Find("APM button1").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("APM button2").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("APM button3").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("TimeField1").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("TimeField2").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("TimeField3").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("save").GetComponent<Image>().color = new Color32(226,139,100,255);
                GameObject.Find("disk").GetComponent<Image>().color = new Color32(218,110,62,255);
                GameObject.Find("Yearbox").GetComponent<Image>().color = new Color32(218,110,62,255);
                break;
            case 12:
                Monthtext.text = "₁₂ December";
                BGImage.sprite = sprites[3];
                GameObject.Find("APM button1").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("APM button2").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("APM button3").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("TimeField1").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("TimeField2").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("TimeField3").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("save").GetComponent<Image>().color = new Color32(158,180,206,255);
                GameObject.Find("disk").GetComponent<Image>().color = new Color32(105,138,179,255);
                GameObject.Find("Yearbox").GetComponent<Image>().color = new Color32(105,138,179,255);
                break;
        }
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
        //GameObject.Find("item").GetComponent<Image>().color = new Color32(255,255,225,100);
        //_target.text = _yearNumText.text + "-" + _monthNumText.text + "-" + int.Parse(day).ToString("D2");
        //_calendarPanel.SetActive(false);
        Debug.Log(_yearNumText.text + "-" + _monthNumText.text + "-" + day);
        _dayNumText = Convert.ToString(day);

        string fullPath = Application.persistentDataPath;
        string path = fullPath + _yearNumText.text + "-" + _monthNumText.text + "-" + _dayNumText + ".txt";

        APM1.text = "AM";
        AM1 = true;
        APM2.text = "AM";
        AM2 = true;
        APM3.text = "AM";
        AM3 = true;

        input1.text = "";
        input2.text = "";
        input3.text = "";

        timeinput1.text = "";
        timeinput2.text = "";
        timeinput3.text = "";

        // if (File.Exists(path) == false)
        // {
        //     var file = File.CreateText(fullPath + _yearNumText.text + "-" + _monthNumText.text + "-" + _dayNumText + ".txt");
        //     StreamWriter sw = new StreamWriter(fullPath + _yearNumText.text + "-" + _monthNumText.text + "-" + _dayNumText + ".txt");
        //     //sw.WriteLine("FALSE");
        //     sw.Flush();
        //     sw.Close();
        // }

        if (File.Exists(path) == true)
        {
            string[] textValue = System.IO.File.ReadAllLines(path);

            if (textValue[0] == "TRUE" )
            {
                if (textValue[1] == "False")
                {
                    AM1 = false;
                    APM1.text = "PM";
                }

                if (textValue[1] == "True")
                {
                    AM1 = true;
                    APM1.text = "AM";
                }

                if (textValue[2] == "False")
                {
                    AM2 = false;
                    APM2.text = "PM";
                }

                if (textValue[2] == "True")
                {
                    AM2 = true;
                    APM2.text = "AM";
                }

                if (textValue[3] == "False")
                {
                    AM3 = false;
                    APM3.text = "PM";
                }

                if (textValue[3] == "True")
                {
                    AM3 = true;
                    APM3.text = "AM";
                }

                input1.text = textValue[4].ToString();
                input2.text = textValue[5].ToString();
                input3.text = textValue[6].ToString();
                timeinput1.text = textValue[7].ToString();
                timeinput2.text = textValue[8].ToString();
                timeinput3.text = textValue[9].ToString();
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
        if (NoteField1.text == "")
        {
            note1 = "";
        }
        Debug.Log(note1);
    }

    public void Note2(InputField NoteField2)
    {
        Debug.Log("메모 테스트: " + NoteField2.text);
        note2 = NoteField2.text;
        if (NoteField2.text == "")
        {
            note2 = "";
        }
        Debug.Log(note2);
    }

    public void Note3(InputField NoteField3)
    {
        Debug.Log("메모 테스트: " + NoteField3.text);
        note3 = NoteField3.text;
        if (NoteField3.text == "")
        {
            note3 = "";
        }
        Debug.Log(note3);
    }

    public void Timefield1(InputField TimeField1)
    {
        Debug.Log("시간 테스트: " + TimeField1.text);
        time1 = TimeField1.text;
        if (TimeField1.text == "")
        {
            time1 = "";
        }
        Debug.Log(time1);
    }

    public void Timefield2(InputField TimeField2)
    {
        Debug.Log("시간 테스트: " + TimeField2.text);
        time2 = TimeField2.text;
        if (TimeField2.text == "")
        {
            time2 = "";
        }
        Debug.Log(time2);
    }

    public void Timefield3(InputField TimeField3)
    {
        Debug.Log("시간 테스트: " + TimeField3.text);   
        time3 = TimeField3.text;
        if (TimeField3.text == "")
        {
            time3 = "";
        }
        Debug.Log(time3);
    }

    public void SaveNote()
    {
        string fullPath = Application.persistentDataPath;
        if (File.Exists(fullPath) == false)
        {
            var file = File.CreateText(fullPath + _yearNumText.text + "-" + _monthNumText.text + "-" + _dayNumText + ".txt");
            file.Close();
        }
        //Debug.Log(DateTime.Now.ToString("yyyy"));
        StreamWriter sw = new StreamWriter(fullPath + _yearNumText.text + "-" + _monthNumText.text + "-" + _dayNumText + ".txt");
        
        sw.WriteLine("TRUE");

        sw.WriteLine(AM1);
        sw.WriteLine(AM2);
        sw.WriteLine(AM3);

        sw.WriteLine(note1);
        sw.WriteLine(note2);
        sw.WriteLine(note3);

        sw.WriteLine(time1);
        sw.WriteLine(time2);
        sw.WriteLine(time3);

        sw.Flush();
        sw.Close();
        Debug.Log("save");

        string path = fullPath + _yearNumText.text + "-" + _monthNumText.text + "-" + _dayNumText + ".txt";
        string[] textValue = System.IO.File.ReadAllLines(path);
        bool justice;
        justice = true;
        int i;
        i = 0;
        while (justice == true)
        {
            if (i < 10)
            {
                Debug.Log(textValue[i]);
                i += 1;
            }

            else
            {
                justice = false;    
            }
        }
    }

    
}