using System.IO;

public class test : MonoBehaviour
{
    void Start()
    {
        string path = @"Craft374/Yangil_Study_Planner/Assets/scripts/test.txt";
        string[] lines = { "hello", "nice to meet you", "bye~" }; 
        File.WriteAllLines(path, lines);
    }
}


