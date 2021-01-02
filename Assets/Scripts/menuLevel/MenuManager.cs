using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startBtn, exitBtn, hakkimdaBtn,paneliKapat;

    [SerializeField]
    private GameObject hakkimdaPaneli;

    [SerializeField]
    private GameObject bulut, bulut2, bulut3, bulut4;




    private void Awake()
    {
        hakkimdaPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
       
    }
    void Start()
    {
        bulut4.GetComponent<RectTransform>().DOLocalMoveX(1330, 0.8f);
        bulut3.GetComponent<RectTransform>().DOLocalMoveX(1540, 0.8f);
        bulut2.GetComponent<RectTransform>().DOLocalMoveX(-1246, 0.8f);
        bulut.GetComponent<RectTransform>().DOLocalMoveX(-1250, 0.8f);
        FadeOut();
    }

   

    // Update is called once per frame
    void FadeOut()
    {
        startBtn.GetComponent<CanvasGroup>().DOFade(1, 0.08f);
        exitBtn.GetComponent<CanvasGroup>().DOFade(1, 0.08f).SetDelay(0.5f);
        hakkimdaBtn.GetComponent<CanvasGroup>().DOFade(1, 0.08f).SetDelay(0.5f);

    }
    public void ExitGame()
    {
        Application.Quit();

    }
    public void StartGameLevel()
    {
       
       
        SceneManager.LoadScene("gameLevel");
       
    }
    public void hakkimdaPaneliniAc()
    {
        hakkimdaPaneli.GetComponent<RectTransform>().DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }
    public void hakkimdaPaneliniKapat()
    {
        SceneManager.LoadScene("menuLevel");
    }
}
