using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Text dogrusayitext,yanlissayitext,puantext;

    void Start()
    {
        
    }
    public void SonuclariGoster(int dogrusayi,int yanlissayi,int puan)
    {
        dogrusayitext.text=dogrusayi.ToString();
        yanlissayitext.text=yanlissayi.ToString();
        puantext.text=puan.ToString();
    }
    public void Anamenuyedon()
    {
        SceneManager.LoadScene("SAMPLESCENE");
    }
    public void YenidenBasla()
    {
SceneManager.LoadScene("GAMELEVEL");
    }
   
}
