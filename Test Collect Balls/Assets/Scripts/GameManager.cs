using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Tooltip("The game manager's audio source")]
    [SerializeField]
    private AudioSource audioSource = null;

    [Tooltip("The clip that will start playing when starting to play")]
    [SerializeField]
    private AudioClip audioClip = null;

    [Tooltip("The canvas that will be disabled when starting to play")]
    [SerializeField]
    private GameObject canvas = null;

    [Tooltip("The text that shows how many points have the player collected in all its runs")]
    [SerializeField]
    private Text pointsText = null;

    [Tooltip("The total points that the player has collected in all its runs")]
    [SerializeField]
    private int totalPoints = 0;

    [Tooltip("Whether the game is paused or not")]
    private bool isGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        isGamePaused = true;
        Time.timeScale = 0;

        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    /// <summary>
    /// This function is called to unpause time and start playing the game
    /// </summary>
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

    /// <summary>
    /// This function is called when the player gets a point
    /// </summary>
    public void GetPoint()
    {
        totalPoints++;
    }

    /// <summary>
    /// This function is called to get the path of the save file
    /// </summary>
    /// <returns> The full path of the save file</returns>
    private string GetPath()
    {
        string path = Path.Combine(Application.dataPath, "Saves");

        return Path.Combine(path, "saves.Save");
    }

    /// <summary>
    /// This function is called to save the points to the save file
    /// </summary>
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

    /// <summary>
    /// This function is called to load the points from the save file
    /// </summary>
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

        totalPoints = int.Parse(data);
        if (totalPoints == 1)
        {
            pointsText.text = totalPoints.ToString() + " point";
        }
        else
        {
            pointsText.text = totalPoints.ToString() + " points";
        }
    }
}
