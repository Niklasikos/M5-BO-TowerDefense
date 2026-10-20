using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Level 1"); 
    }

    public void LoadQuit()
    {
        Application.Quit();
    }
}
