using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Play button pressed");
        // Load your game scene - replace with actual scene name
        SceneManager.LoadScene("DemoLvl");
    }

    public void QuitGame()
    {
        Debug.Log("Quit button pressed");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
