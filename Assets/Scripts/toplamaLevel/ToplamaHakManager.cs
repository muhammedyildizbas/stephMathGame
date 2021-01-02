using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplamaHakManager : MonoBehaviour
{
    [SerializeField]
    private GameObject  kalanHak1,kalanHak2,kalanHak3;
    // Start is called before the first frame update
   

    // Update is called once per frame
public void KalanHaklariKontrolEt(int kalanHak)
    {
        switch (kalanHak)
        {
            case 3:
                kalanHak1.SetActive(true);
                kalanHak2.SetActive(true);
                kalanHak3.SetActive(true);
                break;

            case 2:
                kalanHak1.SetActive(true);
                kalanHak2.SetActive(true);
                kalanHak3.SetActive(false);
                break;

            case 1:
                kalanHak1.SetActive(true);
                kalanHak2.SetActive(false);
                kalanHak3.SetActive(false);
                break;

            case 0:
                kalanHak1.SetActive(false);
                kalanHak2.SetActive(false);
                kalanHak3.SetActive(false);
                break;

        }

    }

}
