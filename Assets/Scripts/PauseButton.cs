using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnPressed()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1.0f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
}
