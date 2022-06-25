using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WinPanel : MonoBehaviour
{
    public CanvasGroup group;

    public void showPanel()
    {
        group.interactable = true;
        group.DOFade(1,0.5f);
    }

    void OnEnable()
    {
        Package.onDelivered += showPanel;
    }

    private void OnDisable() 
    {
        Package.onDelivered -= showPanel;    
    }
}
