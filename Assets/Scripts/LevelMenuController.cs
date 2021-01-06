using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuController : MonoBehaviour
{
    public void Play()
    {
        Application.LoadLevel("Gameplay");
    }

    public void Back() {
        Application.LoadLevel("MainMenu");
    }
}
