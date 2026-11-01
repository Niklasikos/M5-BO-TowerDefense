using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject panel1;
    [SerializeField] GameObject panel1pos;
    [SerializeField] GameObject middlepos;
    [SerializeField] GameObject panel2;
    [SerializeField] GameObject panel2pos;
    [SerializeField] private TextMeshProUGUI SaveFilesText;
    [SerializeField] private GameObject transitionerGO;
    [SerializeField] private Image transitioner;
    private bool triggeredSettings= false;
    void Start()
    {
        transitioner.CrossFadeAlpha(0f, 1f, false);
        Invoke(nameof(SetInActive), 1f);
        Time.timeScale = 1f;
        SaveFilesText.text = "Reset Data";
        panel2.transform.position = panel2pos.transform.position;
    }

    void Update()
    {
        if (triggeredSettings == true)
        {
            panel1.transform.position = Vector2.Lerp(panel1.transform.position, panel1pos.transform.position, 2f * Time.deltaTime);
            panel2.transform.position = Vector2.Lerp(panel2.transform.position, middlepos.transform.position, 2f * Time.deltaTime);
        }
        if (triggeredSettings == false)
        {
            panel1.transform.position = Vector2.Lerp(panel1.transform.position, middlepos.transform.position, 2f * Time.deltaTime);
            panel2.transform.position = Vector2.Lerp(panel2.transform.position, panel2pos.transform.position, 2f * Time.deltaTime);

        }
    }

    public void LoadGame()
    {
        SetActive();
        transitioner.CrossFadeAlpha(1f, 1f, false);
        Invoke(nameof(LoadLevelSelect), 1f);
    }

    private void LoadLevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void Settings()
    {
        triggeredSettings = true;
    }

    public void MainMenu()
    {
        triggeredSettings = false;
    }

    public void ResetSaveFiles()
    {
        MainGameManager.Instance.ResetSave();
        StartCoroutine(SaveFileErased());

    }

    private IEnumerator SaveFileErased()
    {
        SaveFilesText.text = "Done";
        yield return new WaitForSeconds(1f);
        SaveFilesText.text = "Reset Data";
    }

    public void LoadQuit()
    {
        Application.Quit();
    }

    private void SetInActive()
    {
        transitionerGO.SetActive(false);
    }

    private void SetActive()
    {
        transitionerGO.SetActive(true);
    }
}
