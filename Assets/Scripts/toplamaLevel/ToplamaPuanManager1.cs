using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToplamaPuanManager1 : MonoBehaviour
{
    // Start is called before the first frame update
    private int toplamPuan;
    private int puanArtisi;
    string puan;

    int dogruAdet;

    [SerializeField]
    private Text dogruAdetTxt;

    [SerializeField]
    private Text puanText;







    void Start()
    {


        puanText.text = toplamPuan.ToString();
        dogruAdetTxt.text = dogruAdet.ToString();

    }

    public void PuaniArtir(string zorlukSeviyesi)
    {
        switch (zorlukSeviyesi)
        {
            case "kolay":
                puanArtisi = 5;
                dogruAdet++;
                break;

            case "orta":
                puanArtisi = 10;
                dogruAdet++;
                break;
            case "ortaustu":
                puanArtisi = 12;
                dogruAdet++;
                break;

            case "zor":
                puanArtisi = 15;
                dogruAdet++;
                break;


        }

        toplamPuan += puanArtisi;
        puanText.text = toplamPuan.ToString();
        dogruAdetTxt.text = dogruAdet.ToString();

    }
    // Update is called once per frame
    void Update()
    {

    }
}
