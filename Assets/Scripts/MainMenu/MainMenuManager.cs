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
        SceneManager.LoadScene("Gym"); 
    }

    public void LoadQuit()
    {
        Application.Quit();
    }
}
