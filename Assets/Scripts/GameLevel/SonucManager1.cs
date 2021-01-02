using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SonucManager1 : MonoBehaviour
{
    [SerializeField]
    private Text yalnisAdetTxt;

    

    public void OyunaYenidenBasla()
    {
        SceneManager.LoadScene("gameLevel");

    }
    public void YalnisiGoster(int yalnisAdet)
    {
        yalnisAdetTxt.text = yalnisAdet.ToString();
    }
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("menuLevel");
    }
    public void toplamaLevel()
    {
        SceneManager.LoadScene("toplamaLevel");
    }
  
}
