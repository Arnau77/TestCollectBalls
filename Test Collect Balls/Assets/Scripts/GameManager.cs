using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int totalPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void GetPoint()
    {
        totalPoints++;
    }

    private string GetPath()
    {
        string path = Path.Combine(Application.dataPath, "Saves");

        return Path.Combine(path, "saves.Save");
    }

    public void Save()
    {
        using (FileStream fileStream = new FileStream(GetPath(), FileMode.Create))
        {
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.Write(totalPoints.ToString());
            }
        }
    }

    public void Load()
    {
        string data = "";

        if (!File.Exists(GetPath()))
        {
            return;
        }

        using (FileStream fileStream = new FileStream(GetPath(), FileMode.Open))
        {
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                data = streamReader.ReadToEnd();
            }
        }
        Debug.Log(data);
        totalPoints = int.Parse(data);
    }
}
