using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource = null;

    [SerializeField]
    private AudioClip audioClip = null;

    [SerializeField]
    private GameObject canvas = null;

    [SerializeField]
    private Text pointsText = null;

    [SerializeField]
    private int totalPoints = 0;

    private bool isGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        isGamePaused = true;
        Time.timeScale = 0;
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

    public void UnpauseTime(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!context.performed || !isGamePaused)
        {
            return;
        }

        isGamePaused = false;
        Time.timeScale = 1;
        canvas.SetActive(false);
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
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
        pointsText.text = totalPoints.ToString() + " points";
    }
}
