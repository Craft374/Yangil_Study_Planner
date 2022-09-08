using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class rt : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //string Path = "Assets/test/test";
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
    }

    void Update()
    {

    }

}
