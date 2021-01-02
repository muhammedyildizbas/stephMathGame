using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Security.AccessControl;
public class PuanManager : MonoBehaviour
{
    public int dogruAdet;
    private int toplamPuan;
    private int puanArtisi;

    [SerializeField]
    private Text puanText;


    void Start()
    {
        puanText.text = toplamPuan.ToString();
       
    }

    
   
    // Update is called once per frame

    public void PuaniArtir(string zorlukSeviyesi)
    {
        switch (zorlukSeviyesi)
        {
            case "kolay":
                puanArtisi = 5;
               
                break;

            case "orta":
                puanArtisi = 10;
               
                break;

            case "zor":
                puanArtisi = 15;
               
                break;
                
        }

        toplamPuan += puanArtisi;
        puanText.text = toplamPuan.ToString();
       

    }
   
}
