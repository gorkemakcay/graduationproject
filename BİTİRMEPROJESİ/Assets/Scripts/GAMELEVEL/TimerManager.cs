using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
   [SerializeField]
   private Text suretext;
   int kalansure;
   bool suresaysinmi;
   GameManager gameManager;
   private void Awake()
   {
       gameManager=Object.FindObjectOfType<GameManager>();
   }
    void Start()
    {
        kalansure=90;
        suresaysinmi=true;
        
    }
    public void sureyibaslat()
    {
    StartCoroutine(SureTimerRoutine()); 
    }
    IEnumerator SureTimerRoutine()
    {
        while(suresaysinmi==true)
        {
            yield return new WaitForSeconds(1f);
            suretext.text=kalansure.ToString();
            kalansure--;
            if(kalansure==0)
            {
               
                suresaysinmi=false;
                gameManager.OyunuBitir();
            }
        }

    }

   
}
