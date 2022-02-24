using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PausePaneli;
    private void OnEnable()
    {
        Time.timeScale=0f;
    }
    private void OnDisable()
    {
        Time.timeScale=1f;
    }
    public void YenidenOyna()
    {
        PausePaneli.SetActive(false);
    }
    public void MenuyeDon()
    {
        SceneManager.LoadScene("SAMPLESCENE");
    }
    public void OyundanCik()
    {
        Application.Quit();
    }
}

