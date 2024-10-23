using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonExit : MonoBehaviour
{
    public void OnButtonExitClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("UIMainMenu");
    }
}
