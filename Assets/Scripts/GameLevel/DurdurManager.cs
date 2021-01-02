using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class DurdurManager : MonoBehaviour
{
    [SerializeField]
    private GameObject durdurPanel;
    [SerializeField]
    private GameObject cocuk2;

    private void OnEnable()
    {
        Time.timeScale = 0f;
        cocuk2.GetComponent<RectTransform>().DOLocalMoveX(-26, 5f).SetEase(Ease.InBack);
    }
    private void OnDisable()
    {
        
        Time.timeScale = 1f;

    }
    public void baslatButon()
    {

        durdurPanel.SetActive(false);
    }
    
    
    
}
