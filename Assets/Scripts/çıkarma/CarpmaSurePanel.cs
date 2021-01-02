using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarpmaSurePanel : MonoBehaviour
{
    [SerializeField]
    private Text SureText;
    int kalanSure;
    bool SureSaysinmi = true;

   CarpmaLeveliManager carpmaLeveliManager;

    private void Awake()
    {
        carpmaLeveliManager = Object.FindObjectOfType<CarpmaLeveliManager>();


    }
    // Start is called before the first frame update
    void Start()
    {
        kalanSure = 90;

        StartCoroutine(SureTimerRoutine());

    }

    // Update is called once per frame
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
                carpmaLeveliManager.SureBitti();
                carpmaLeveliManager.OyunBitti();


            }

        }
    }
}
