using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Security.AccessControl;
using System.IO;

public class GameManager1 : MonoBehaviour
{
    [SerializeField]

    private GameObject karePrefab;


    [SerializeField]

    private Transform karelerPaneli;
    private GameObject[] karelerDizisi = new GameObject[12];

    [SerializeField]

    private Text soruText;

   
    

    [SerializeField]
    private Transform soruPaneli;

    [SerializeField]
    private Transform lokomotif;

    [SerializeField]
    private Sprite[] kareSprites;

    [SerializeField]
    private GameObject anaMenuPanel,durdurPanel,sesPanel,ekranArasiPanel, ekranArasiPanel2;

    [SerializeField]
    private GameObject sesPanelAc, sesPanelKapat;

    List<int> bolumDegerleriListesi = new List<int>();
    int bolenSayi, bolunenSayi;
    int kacinciSoru;
    int dogruSonuc;
     int yalnisAdet;
    int butonDegeri;
    GameObject gecerliKare;
    [SerializeField]
    private GameObject sonucPaneli;

   

    [SerializeField]
    private GameObject cikisPaneli;

    [SerializeField]
    private GameObject levelPaneli;
    [SerializeField]
    private GameObject bulut, bulut2, bulut3, bulut4;

    [SerializeField]
    private GameObject durumPaneli;

    [SerializeField]
    private GameObject cocuk, cocuk3;

    [SerializeField]
    private GameObject durumPaneli2;

    [SerializeField]
    private GameObject durumPaneli3;


    bool butonaBasilsinmi;
    int kalanHak;
    string sorununZorlukDerecesi;
    KalanHaklarManager kalanHaklarManager;
    SonucManager sonucManager;
    SonucManager1 sonucManager1;
    PuanManager puanManager;
    ToplamaPuanManager toplamaPuanManager;
    ToplamaPuanManager1 toplamaPuanManager1;
    ToplamaPuanManager2 toplamaPuanManager2;
    ToplamaSonucManager toplamaSonucManager;
    AdmobManager admobManager;
    sesAcKapaOlay SesAcKapaOlay;


    [SerializeField]
    AudioSource audioSource;

    public AudioClip butonSesi,kazandinSes;

    [SerializeField]
    AudioSource sahneSesleri,panelSesleri,sureBittiSes;

    private void Awake()
    {
        kalanHak = 3;
        audioSource = GetComponent<AudioSource>(); 
        sonucPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
        levelPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
        durumPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
        durumPaneli2.GetComponent<RectTransform>().localScale = Vector3.zero;
        durumPaneli3.GetComponent<RectTransform>().localScale = Vector3.zero;
        kalanHaklarManager = FindObjectOfType<KalanHaklarManager>();
        puanManager = FindObjectOfType<PuanManager>();
        toplamaPuanManager = Object.FindObjectOfType<ToplamaPuanManager>();
        toplamaPuanManager1 = Object.FindObjectOfType<ToplamaPuanManager1>();
        toplamaPuanManager2 = Object.FindObjectOfType<ToplamaPuanManager2>();
        admobManager = Object.FindObjectOfType<AdmobManager>();
        kalanHaklarManager.kalanHaklariKontrolEt(kalanHak);
        
    }
    void Start()
    {
        bulut4.GetComponent<RectTransform>().DOLocalMoveX(2354, 2f).SetEase(Ease.OutBack);
        bulut3.GetComponent<RectTransform>().DOLocalMoveX(2325, 2f).SetEase(Ease.OutBack);
        bulut2.GetComponent<RectTransform>().DOLocalMoveX(-1898, 2f).SetEase(Ease.OutBack);
        bulut.GetComponent<RectTransform>().DOLocalMoveX(-2210, 2f).SetEase(Ease.OutBack);
        
        butonaBasilsinmi = false;
       

        soruPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
        lokomotif.GetComponent<RectTransform>().localScale = Vector3.zero;
       
        kareleriOlustur();
        
    }
    public void cocuguCagir()
     {
         cocuk.GetComponent<RectTransform>().DOLocalMoveX(-26, 5f).SetEase(Ease.InBack);
     }

     public void cocugu3Cagir()
     {
         cocuk3.GetComponent<RectTransform>().DOLocalMoveX(-26, 3f).SetEase(Ease.InBack);
     }
    public void anaMenuPaneliAc()
    {
        anaMenuPanel.SetActive(true);
    }
    public void ekranArasiPaneliAc()
    {
        ekranArasiPanel.SetActive(true);
    }
    public void ekranArasiPaneli2Ac()
    {
        ekranArasiPanel2.SetActive(true);
        
        ekranArasiPanel.SetActive(false);
    }
    public void durdurPanelAc()
    {
       durdurPanel.SetActive(true);
    }
    public void sesPaneliAc()
    {
      
        sesPanel.SetActive(true);
        sesPanelAc.SetActive(false);
        sesPanelKapat.SetActive(true);
        
    }
    public void surePaneliKapat()
    {
        durumPaneli.SetActive(false);
    }

    public void sesPanaliKapat()
    {
        sesPanel.SetActive(false);
        sesPanelKapat.SetActive(false);
        sesPanelAc.SetActive(true);
    }
    // Update is called once per frame

    public void kareleriOlustur()
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject kare = Instantiate(karePrefab, karelerPaneli);
            kare.transform.GetChild(1).GetComponent<Image>().sprite = kareSprites[Random.Range(0, kareSprites.Length)];
            
            kare.transform.GetComponent<Button>().onClick.AddListener(() => ButonaBasildi());

            karelerDizisi[i] = kare;
        }
        BolumDegerleriniTexteYazdir();
        StartCoroutine(DoFadeRoutine());
        Invoke("SoruPaneliniAc", 1.3f);
        sahneSesleri.Play();
       
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
            puanManager.PuaniArtir(sorununZorlukDerecesi);
            toplamaPuanManager.PuaniArtir(sorununZorlukDerecesi);
            toplamaPuanManager1.PuaniArtir(sorununZorlukDerecesi);
            toplamaPuanManager2.PuaniArtir(sorununZorlukDerecesi);
            bolumDegerleriListesi.RemoveAt(kacinciSoru);
            if(bolumDegerleriListesi.Count>0)
            {
                SoruPaneliniAc();
            }
            else
            {

               
                durumPaneli3.GetComponent<RectTransform>().DOScale(1, 0.09f);
                sahneSesleri.Stop();
              
                audioSource.PlayOneShot(kazandinSes);
                cocugu3Cagir();
                surePaneliKapat();
                levelPaneli.GetComponent<RectTransform>().DOScale(1, 0.09f);
                
                OyunBitti();
            }
            
        
        }
        else
        {
            kalanHak--;
            yalnisAdet++;
            kalanHaklarManager.kalanHaklariKontrolEt(kalanHak);
        }
        if (kalanHak <= 0)
        {

            
            panelSesleri.Play();
            durumPaneli2.GetComponent<RectTransform>().DOScale(1, 0.09f);
           
            sahneSesleri.Stop();
             cocuguCagir();
            surePaneliKapat();
            OyunBitti();
           
        }
        
    } 
    public void OyunBitti()
    {

        butonaBasilsinmi = false;
        
       
        sonucPaneli.GetComponent<RectTransform>().DOScale(1, 0.3f).SetEase(Ease.OutBack);
        toplamaSonucManager = Object.FindObjectOfType<ToplamaSonucManager>();
        toplamaSonucManager.YalnisiGoster(yalnisAdet);
        sonucManager = Object.FindObjectOfType<SonucManager>();
        sonucManager.YalnisiGoster(yalnisAdet);
        sonucManager1 = Object.FindObjectOfType<SonucManager1>();
        sonucManager1.YalnisiGoster(yalnisAdet);

    }
    
    IEnumerator DoFadeRoutine()
    {
        foreach (var kare in karelerDizisi)
        {
            kare.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
            yield return new WaitForSeconds(0.07f);

        }
    }
    
    public void SureBitti()
    {
        sahneSesleri.Stop();
        durumPaneli.GetComponent<RectTransform>().DOScale(1, 0.09f);
        sureBittiSes.Play();
    }
    void SoruPaneliniAc() 
    {
        SoruyuSor();
        butonaBasilsinmi = true;
        soruPaneli.GetComponent<RectTransform>().DOScale(1, 0.05f).SetEase(Ease.OutBack);
        lokomotif.GetComponent<RectTransform>().DOScale(1, 0.05f).SetEase(Ease.OutBack);
        admobManager.ShowBanner();
    }

    void BolumDegerleriniTexteYazdir()
    {
        foreach (var kare in karelerDizisi)
        {
            int rastgeleDeger = Random.Range(80, 10);
            bolumDegerleriListesi.Add(rastgeleDeger);

            kare.transform.GetChild(0).GetComponent<Text>().text = rastgeleDeger.ToString();

        }


    }

    void SoruyuSor()
    {

        bolenSayi = Random.Range(50, 10);
        kacinciSoru = Random.Range(0, bolumDegerleriListesi.Count);
        dogruSonuc = bolumDegerleriListesi[kacinciSoru];
        bolunenSayi = dogruSonuc - bolenSayi;
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
        soruText.text = bolunenSayi.ToString() + " + " + bolenSayi.ToString();

    }

}   