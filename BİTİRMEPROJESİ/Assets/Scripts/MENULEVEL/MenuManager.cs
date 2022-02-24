using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Transform kafa;
    [SerializeField]
    private Transform baslabtn;
    void Start()
    {
        kafa.transform.GetComponent<RectTransform>().DOLocalMoveX(0f,1f).SetEase(Ease.OutBack);
        baslabtn.transform.GetComponent<RectTransform>().DOLocalMoveY(-270f,1.5f).SetEase(Ease.InBack);
    }

    public void oyunabasla()
    {
        SceneManager.LoadScene("GAMELEVEL");
    }
}
