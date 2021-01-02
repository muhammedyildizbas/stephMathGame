using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToplamaSureManager : MonoBehaviour
{
    [SerializeField]
    private Text SureText;
    int kalanSure;
    bool SureSaysinmi = true;

    ToplamaLeveliManager toplamaLeveliManager;

    private void Awake()
    {
        toplamaLeveliManager = Object.FindObjectOfType<ToplamaLeveliManager>();


    }

    // Start is called before the first frame update
    void Start()
    {
        kalanSure = 110;

        StartCoroutine(SureTimerRoutine());

    }

    IEnumerator SureTimerRoutine()
    {
        while (SureSaysinmi)
        {
            yield return new WaitForSeconds(1.5f);
            SureText.text = kalanSure.ToString();
            kalanSure--;
            if (kalanSure <= -1)
            {
                SureSaysinmi = false;
                SureText.text = "0";
                toplamaLeveliManager.SureBitti();
                toplamaLeveliManager.OyunBitti();

            }
        }
    }
}
