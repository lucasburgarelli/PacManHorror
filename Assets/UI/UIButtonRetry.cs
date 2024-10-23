using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonRetry : MonoBehaviour
{
    public void OnButtonRetryClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }
}
