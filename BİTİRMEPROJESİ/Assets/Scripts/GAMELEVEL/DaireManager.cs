using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DaireManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] dairelerdizisi;
    void Start()
    {
        dairelerikapat();
    }
   public void dairelerikapat()
    {
        foreach (GameObject daire in dairelerdizisi)
        {
            daire.GetComponent<RectTransform>().localScale=Vector3.zero;
        }
    }
    public void daireleriac(int hangidaire)
    {
        dairelerdizisi[hangidaire].GetComponent<RectTransform>().DOScale(1,0.3f).SetEase(Ease.InBack);
        if(hangidaire%5==0)
        {
              foreach (GameObject daire in dairelerdizisi)
        {
            daire.GetComponent<RectTransform>().localScale=Vector3.zero;
        }
        }
    }
    
}
