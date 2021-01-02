using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesAcKapaOlay: MonoBehaviour
{
    public GameObject ses_acik, ses_kapali;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("sesDurum") == 0)
        {
            ses_acik.SetActive(false);
            ses_kapali.SetActive(true);
            
        }
        else
        {
            ses_acik.SetActive(true);
            ses_kapali.SetActive(false);
        }
    }
    public void ses_durum(string durum)
    {
        if (durum == "acik") //SES KAPAMA
        {
            ses_acik.SetActive(false);
            ses_kapali.SetActive(true);
            PlayerPrefs.SetInt("sesDurum", 0);
        }
        else if (durum == "kapali") //SES AÇMA
        {
            ses_acik.SetActive(true);
            ses_kapali.SetActive(false);
            PlayerPrefs.SetInt("sesDurum", 1);
        }
    }
}
