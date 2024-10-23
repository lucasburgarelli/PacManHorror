using UnityEngine;
using UnityEngine.SceneManagement;

public class UiMainMenu : MonoBehaviour
{
    public void OnButtonPlayClick()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnButtonPlayerControls()
    {
        SceneManager.LoadScene("UIOptions");
    }
    
    public void OnButtonExitClick()
    {
        Application.Quit();
    }
}
