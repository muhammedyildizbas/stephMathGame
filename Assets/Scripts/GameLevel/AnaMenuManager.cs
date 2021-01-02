using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class AnaMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject anaMenuPanel;

    private void OnEnable()
    {
        Time.timeScale = 0f;

    }
    private void OnDisable()
    {
        Time.timeScale = 1f;

    }
    public void hayirButon()
    {
        anaMenuPanel.SetActive(false);
    }
    
    
    
}
