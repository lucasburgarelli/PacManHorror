using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonGoBack : MonoBehaviour
{
    public void OnButtonGoBackClick()
    {
        SceneManager.LoadScene("UIMainMenu");
    }
}
