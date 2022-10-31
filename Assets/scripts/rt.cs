using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;
using System;

public class rt : MonoBehaviour
{
    public void OnDateItemClick(string day)
    {
        /*date_click.Invoke();
        _target.text = _yearNumText.text + "-" + _monthNumText.text + "-" + int.Parse(day).ToString("D2");
        _calendarPanel.SetActive(false);
        Debug.Log(_yearNumText.text + "-" + _monthNumText.text + "-" + day);
        string fullPath = "Assets/test/";
        //string number = "2022-09-02";
        if (File.Exists(fullPath) == false)
        {
            var file = File.CreateText(fullPath + _yearNumText.text + "-" + _monthNumText.text + "-" + day + ".txt");
            file.Close();
        }
        Debug.Log(DateTime.Now.ToString("yyyy"));
        StreamWriter sw = new StreamWriter(fullPath + _yearNumText.text + "-" + _monthNumText.text + "-" + day + ".txt");
        sw.WriteLine("테스트1");
        sw.Flush();
        sw.Close();*/
    }
    // Start is called before the first frame update
    void Start()
    {
        /*string Path = "Assets/test/test";
        string fullPath = "Assets/test/";
        string number = "2022-09-02";
        if(File.Exists(fullPath) == false)
        {
            var file = File.CreateText(fullPath + number + ".txt");
            file.Close();
        }
        Debug.Log("ds");
        StreamWriter sw = new StreamWriter(fullPath + number + ".txt");
        sw.WriteLine("저장된 데이터");
        sw.Flush();
        sw.Close();
        gameObject.active = false;*/
    }


    void Update()
    {

    }

}
