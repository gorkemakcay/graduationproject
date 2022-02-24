using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     [SerializeField]
     private GameObject PausePaneli,SonucPaneli;

    [SerializeField]
    private GameObject puansurepaneli;
    [SerializeField]
    private GameObject gerisayim;
    [SerializeField]
    private Transform yazi;
    [SerializeField]
    private Transform dikdortgen1;
    [SerializeField]
    private Transform dikdortgen2;
    [SerializeField]
    private Text UstText,AltText,Buyuktext,puanText;
    SonucManager sonucManager;
    TimerManager TimerManager;
    DaireManager daireManager;
    TrueFalse trueFalse;
    int oyunsayac,kacincioyun;
    int ustdeger,altdeger,buyukdeger;
    int butondegeri;
    int Toppuan,ArtisPuan;
    int dogrusayi,yanlissayi;
    void Awake()
    {
        
        TimerManager=Object.FindObjectOfType<TimerManager>();
        daireManager=Object.FindObjectOfType<DaireManager>();
        trueFalse=Object.FindObjectOfType<TrueFalse>();
        
    }
    void Start()
    {
        Toppuan=0;
        kacincioyun=0;
        oyunsayac=0;
        UstText.text=" ";
        AltText.text=" ";
        puanText.text="0";
        sahneekraniniguncelle();
    }

    void sahneekraniniguncelle()
    {
        puansurepaneli.GetComponent<CanvasGroup>().DOFade(1,1f);
        gerisayim.GetComponent<CanvasGroup>().DOFade(1,2f);
        dikdortgen1.transform.GetComponent<RectTransform>().DOLocalMoveX(0f,1.5f).SetEase(Ease.OutBack);
        dikdortgen2.transform.GetComponent<RectTransform>().DOLocalMoveX(0f,1.5f).SetEase(Ease.OutBack);     
         yazi.transform.GetComponent<RectTransform>().DOLocalMoveY(-270f,1f);
    }

    public void oyunabasla()
     {
       Kacincioyun();
       yazi.GetComponent<CanvasGroup>().DOFade(0,1f);
        Buyuktext.GetComponent<CanvasGroup>().DOFade(1,1f);
        TimerManager.sureyibaslat();
     }
    
    void Kacincioyun()
    {
        if(oyunsayac<5)
        {
            kacincioyun=1;
            ArtisPuan=25;
        }
        else if(oyunsayac>=5&&oyunsayac<10)
        {
            kacincioyun=2;
            ArtisPuan=50;
        }
        else if(oyunsayac>=10&&oyunsayac<15)
        {
            kacincioyun=3;
            ArtisPuan=75;
        }
        else
        {
            kacincioyun=Random.Range(1,4);//sayac 15i gecerse rastgele bisi gelsin diye
            ArtisPuan=100;
        }
        switch(kacincioyun)
        {
            case 1:
            BirinciFonksiyon();
            break;
            case 2:
            ikincifonksiyon();
            break;
            case 3:
            ucuncufonksiyon();
            break;
        }
    }
    void BirinciFonksiyon()
    {
        int rasgeledeger=Random.Range(0,50);
        if(rasgeledeger<=25)
        {
            ustdeger=Random.Range(2,50);
            altdeger=ustdeger+Random.Range(1,10);
        }
        else
        {
            ustdeger=Random.Range(2,50);
            altdeger=Mathf.Abs(ustdeger-Random.Range(1,10));//math abs eksi gelirse artıya cevirmek icin mutlak deger;
        }
        if(ustdeger>altdeger)
        {
           buyukdeger=ustdeger; 
        }
        else
        {
            buyukdeger=altdeger;
        }
        UstText.text=ustdeger.ToString();
        AltText.text=altdeger.ToString();
    }
    void ikincifonksiyon()
    {
        int birincisayi=Random.Range(1,10);
        int ikincisayi=Random.Range(1,20);
        int ucuncusayi=Random.Range(1,10);
        int dorduncusayi=Random.Range(1,20);
        ustdeger=birincisayi+ikincisayi;
        altdeger=ucuncusayi+dorduncusayi;
         if(ustdeger>altdeger)
        {
           buyukdeger=ustdeger; 
        }
        else if(ustdeger<altdeger)
        {
            buyukdeger=altdeger;
        }
        if(ustdeger==altdeger)
        {
            BirinciFonksiyon();
            return;
        }

        UstText.text=birincisayi+" + "+ikincisayi;
        AltText.text=ucuncusayi+" + "+dorduncusayi;
    }
    void ucuncufonksiyon()
    {
          int birincisayi=Random.Range(1,10);
        int ikincisayi=Random.Range(1,20);
        int ucuncusayi=Random.Range(1,10);
        int dorduncusayi=Random.Range(1,20);
        int besincisayi=Random.Range(1,15);
        int altincisayi=Random.Range(1,15);
        ustdeger=birincisayi+ikincisayi-besincisayi;
        altdeger=ucuncusayi+dorduncusayi-altincisayi;
         if(ustdeger>altdeger)
        {
           buyukdeger=ustdeger; 
        }
        else if(ustdeger<altdeger)
        {
            buyukdeger=altdeger;
        }
        if(ustdeger==altdeger)
        {
            BirinciFonksiyon();
            return;
        }

        UstText.text=birincisayi+" + "+ikincisayi+" - "+besincisayi;
        AltText.text=ucuncusayi+" + "+dorduncusayi+" - "+altincisayi;




    }
    public void butondegerinibelirle(string butonadi)
    {
        if(butonadi=="ustbuton")
        {
            butondegeri=ustdeger;
            
        }
        else if(butonadi=="altbuton")
        {
            butondegeri=altdeger;
        }
        if(butondegeri==buyukdeger)
        {
           trueFalse.TrueFalseScale(true);
            daireManager.daireleriac(oyunsayac%5);
            oyunsayac++;
            Toppuan+=ArtisPuan;
            puanText.text=Toppuan.ToString();
            dogrusayi++;
            Kacincioyun();
        }
        else
        {
            trueFalse.TrueFalseScale(false);
            hatayagoresayaciazalt();
            yanlissayi++;
            Kacincioyun();

        }
        void hatayagoresayaciazalt()
        {
            oyunsayac-=(oyunsayac%5+5);
            if(oyunsayac<0)
            {
                oyunsayac=0;
            }
            daireManager.dairelerikapat();
        }
        
    }
    public void PausePaneliAc()
    {
        PausePaneli.SetActive(true);
    }
    public void OyunuBitir()
    {
        SonucPaneli.SetActive(true);
        sonucManager=Object.FindObjectOfType<SonucManager>();
    
        sonucManager.SonuclariGoster(dogrusayi,yanlissayi,Toppuan);
    }
}
