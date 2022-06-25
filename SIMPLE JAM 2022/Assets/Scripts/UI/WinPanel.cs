using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class WinPanel : MonoBehaviour
{
    public CanvasGroup group;
    public TextMeshProUGUI text;

    public void showPanel()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        group.interactable = true;
        group.DOFade(1,0.5f);
    }

    void OnEnable()
    {
        Timer.timeOut += showLosePanel;
        Package.onDelivered += showPanel;
    }

    private void OnDisable() 
    {
        Timer.timeOut -= showLosePanel;
        Package.onDelivered -= showPanel;    
    }

    private void showLosePanel()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        text.color = Color.red;
        text.fontSize = 250;
        text.text = "YOU LOSE";
        group.interactable = true;
        group.DOFade(1,0.5f);
    }
}
