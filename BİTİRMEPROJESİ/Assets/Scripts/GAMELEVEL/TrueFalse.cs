using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrueFalse : MonoBehaviour
{
    
    [SerializeField]
    private GameObject Trueicon,Falseicon;
    void Start()
    {
        scalekapat();
    }

   public void TrueFalseScale(bool dogruyanlis)
   {
       if(dogruyanlis==true)
       {
           Trueicon.GetComponent<RectTransform>().DOScale(1,0.2f);
           Falseicon.GetComponent<RectTransform>().localScale=Vector3.zero;
       }
       else
       {
           Falseicon.GetComponent<RectTransform>().DOScale(1,0.2f);
           Trueicon.GetComponent<RectTransform>().localScale=Vector3.zero;
       }
       Invoke("scalekapat",0.3f);
       
   }
   void scalekapat()
   {
       Trueicon.GetComponent<RectTransform>().localScale=Vector3.zero;
        Falseicon.GetComponent<RectTransform>().localScale=Vector3.zero;
   }
    
}
