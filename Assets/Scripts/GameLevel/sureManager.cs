using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sureManager : MonoBehaviour
{
    [SerializeField]
    private Text SureText;
    int kalanSure;
    bool SureSaysinmi=true;

    GameManager gameManager;
   

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();


    }

    void Start()
    { 
       kalanSure = 51;

        StartCoroutine(SureTimerRoutine());     

    }

    IEnumerator SureTimerRoutine()
    {
        while (SureSaysinmi)
        {
            yield return new WaitForSeconds(1f);
            SureText.text = kalanSure.ToString();
            kalanSure--;
            if (kalanSure <= -1)
            {
                
                SureSaysinmi = false;
                SureText.text = "0";
                gameManager.SureBitti();
                gameManager.OyunBitti();
              

            }
            
        }
    }
    
}
