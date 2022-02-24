using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GeriSayimManager : MonoBehaviour
{
  [SerializeField]
  private GameObject gerisayim;
  [SerializeField]
  private Text gerisayimtext;
   [SerializeField]
   private Text baslatext;
   GameManager gameManager;
   private void Awake()
   {
   gameManager=Object.FindObjectOfType<GameManager>();//gamemanagere ulaşmak için
   }
    void Start()
    {
       StartCoroutine(geriyesayroutine());
    }
     
     IEnumerator geriyesayroutine()
     {
         gerisayimtext.text="3";
         yield return new WaitForSeconds(0.5f);
         gerisayim.GetComponent<RectTransform>().DOScale(1,0.2f).SetEase(Ease.OutBack);
         yield return new WaitForSeconds(0.5f);
         gerisayim.GetComponent<RectTransform>().DOScale(0,0.2f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);
        gerisayimtext.text="2";
        yield return new WaitForSeconds(0.5f);
         gerisayim.GetComponent<RectTransform>().DOScale(1,0.2f).SetEase(Ease.OutBack);
         yield return new WaitForSeconds(0.5f);
         gerisayim.GetComponent<RectTransform>().DOScale(0,0.2f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);
        gerisayimtext.text="1";
        yield return new WaitForSeconds(0.5f);
         gerisayim.GetComponent<RectTransform>().DOScale(1,0.2f).SetEase(Ease.OutBack);
         yield return new WaitForSeconds(0.5f);
         gerisayim.GetComponent<RectTransform>().DOScale(0,0.2f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);
        baslatext.text="BASLA!";
        yield return new WaitForSeconds(0.5f);
        gerisayimtext.GetComponent<RectTransform>().DOScale(0,0.1f);
         gerisayim.GetComponent<RectTransform>().DOScale(1,0.2f).SetEase(Ease.OutBack);
         yield return new WaitForSeconds(0.5f);
         gerisayim.GetComponent<RectTransform>().DOScale(0,0.2f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);

        
        StopAllCoroutines();
        gameManager.oyunabasla();
     }
     
    
}
