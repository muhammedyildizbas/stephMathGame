using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CarpmaLeveliManager : MonoBehaviour
{
    ToplamaHakManager toplamaHakManager;
    ToplamaPuanManager toplamaPuanManager;
    // Start is called before the first frame update
    void Start()
    {
        butonaBasilsinmi = false;

        soruPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;


        kareleriOlustur();

    }
    private void Awake()
    {
        kalanHak = 3;
        audioSource = GetComponent<AudioSource>();
        sonucPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
        levelPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
        durumPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
        durumPaneli2.GetComponent<RectTransform>().localScale = Vector3.zero;
        durumPaneli3.GetComponent<RectTransform>().localScale = Vector3.zero;
        toplamaHakManager = Object.FindObjectOfType<ToplamaHakManager>();
        toplamaPuanManager = Object.FindObjectOfType<ToplamaPuanManager>();
        toplamaHakManager.KalanHaklariKontrolEt(kalanHak);
    }


    [SerializeField]
    private GameObject karePrefab;

    [SerializeField]
    private Transform karelerPaneli;

    [SerializeField]
    private Text soruText;

    private GameObject[] karelerDizisi = new GameObject[25];

    [SerializeField]
    private Transform soruPaneli;

    [SerializeField]
    private Sprite[] kareSprites;

    [SerializeField]
    AudioSource audioSource;

    public AudioClip butonSesi;


    [SerializeField]
    private GameObject sonucPaneli;

    [SerializeField]
    private GameObject levelPaneli;

    [SerializeField]
    private GameObject durumPaneli;

    [SerializeField]
    private GameObject durumPaneli2;

    [SerializeField]
    private GameObject durumPaneli3;


    List<int> bolumDegerleriListesi = new List<int>();

    int bolunenSayi, bolenSayi;
    int kacinciSoru;
    int dogruSonuc;
    int butonDegeri;
    bool butonaBasilsinmi;
    int kalanHak;
    GameObject gecerliKare;
    string sorununZorlukDerecesi;

    public void kareleriOlustur()
    {
        for (int i = 0; i < 25; i++)
        {
            GameObject kare = Instantiate(karePrefab, karelerPaneli);
            kare.transform.GetChild(1).GetComponent<Image>().sprite = kareSprites[Random.Range(0, kareSprites.Length)];

            kare.transform.GetComponent<Button>().onClick.AddListener(() => ButonaBasildi());


            karelerDizisi[i] = kare;

        }
        BolumDegerleriniTexteYazdir();

        StartCoroutine(DoFadeRoutine());
        Invoke("SoruPaneliniAc", 3f);

    }

    IEnumerator DoFadeRoutine()
    {
        foreach (var kare in karelerDizisi)
        {
            kare.GetComponent<CanvasGroup>().DOFade(1, 01f);
            yield return new WaitForSeconds(0.1f);

        }
    }

    public void SureBitti()
    {
        durumPaneli.GetComponent<RectTransform>().DOScale(1, 0.09f);
    }

    void ButonaBasildi()
    {


        if (butonaBasilsinmi)
        {
            audioSource.PlayOneShot(butonSesi);
            butonDegeri = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
            gecerliKare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            SonucuKontrolEt();

        }

    }

    void SonucuKontrolEt()
    {

        if (butonDegeri == dogruSonuc)
        {
            gecerliKare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            gecerliKare.transform.GetChild(0).GetComponent<Text>().text = "";
            gecerliKare.transform.GetComponent<Button>().interactable = false;
            toplamaPuanManager.PuaniArtir(sorununZorlukDerecesi);
            bolumDegerleriListesi.RemoveAt(kacinciSoru);
            if (bolumDegerleriListesi.Count > 0)
            {
                SoruPaneliniAc();
            }
            else
            {

                durumPaneli3.GetComponent<RectTransform>().DOScale(1, 0.09f);

                levelPaneli.GetComponent<RectTransform>().DOScale(1, 0.09f);
                OyunBitti();
            }


        }
        else
        {
            kalanHak--;
            toplamaHakManager.KalanHaklariKontrolEt(kalanHak);
        }
        if (kalanHak <= 0)
        {
            durumPaneli2.GetComponent<RectTransform>().DOScale(1, 0.09f);
            OyunBitti();
        }
    }
    public void OyunBitti()
    {
        butonaBasilsinmi = false;
        sonucPaneli.GetComponent<RectTransform>().DOScale(1, 0.09f);
    }
    void BolumDegerleriniTexteYazdir()
    {
        foreach (var kare in karelerDizisi)
        {
            int rastgelerDeger = Random.Range(2,65);

            bolumDegerleriListesi.Add(rastgelerDeger);
            kare.transform.GetChild(0).GetComponent<Text>().text = rastgelerDeger.ToString();

        }
    }

    void SoruPaneliniAc()
    {
        SoruyuSor();
        butonaBasilsinmi = true;
        soruPaneli.GetComponent<RectTransform>().DOScale(1, 0.09f);

    }

    void SoruyuSor()
    {

        bolenSayi = Random.Range(2, 60);
        kacinciSoru = Random.Range(0, bolumDegerleriListesi.Count);
        dogruSonuc = bolumDegerleriListesi[kacinciSoru];
        bolunenSayi = dogruSonuc+bolenSayi ;
        if (bolunenSayi <= 0)
        {
            sorununZorlukDerecesi = "zor";

        }
        else if (bolunenSayi > 0 && bolunenSayi <= 20)
        {
            sorununZorlukDerecesi = "ortaustu";
        }
        else if (bolunenSayi > 20 && bolunenSayi < 70)
        {
            sorununZorlukDerecesi = "orta";

        }
        else
        {
            sorununZorlukDerecesi = "kolay";

        }
        soruText.text = bolunenSayi.ToString() + " - " + bolenSayi.ToString();

    }

}
