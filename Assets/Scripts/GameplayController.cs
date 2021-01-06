using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private Button resumeBtn;

    public void Pause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeBtn.onClick.RemoveAllListeners();
        resumeBtn.onClick.AddListener(()=>Resume());
    }

    public void PlayerDied()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeBtn.onClick.RemoveAllListeners();
        resumeBtn.onClick.AddListener(() => Restart());
    }

    public void GoToMennu()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("MainMenu");
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("Gameplay");
    }

    

}
