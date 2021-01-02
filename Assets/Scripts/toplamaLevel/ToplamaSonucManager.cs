using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ToplamaSonucManager : MonoBehaviour
{
    [SerializeField]
    private Text yalnisAdetTxt;
  
    public void OyunaYenidenBasla()
    {
        SceneManager.LoadScene("toplamaLevel");

    }
    public void YalnisiGoster(int yalnisAdet)
    {
        yalnisAdetTxt.text = yalnisAdet.ToString();
    }
    public void ToplamaVideo()
    {
        SceneManager.LoadScene("toplama");
    }

    public void CikarmaVideo()
    {
        SceneManager.LoadScene("cikarma");
    }

    public void BolmeVideo()
    {
        SceneManager.LoadScene("bolme");
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("menuLevel");
    }
    public void GameLevelDon()
    {
        SceneManager.LoadScene("gameLevel");
    }
    public void cikarmaLeveli()
    {
        SceneManager.LoadScene("gameLevel 2");
    }
}
