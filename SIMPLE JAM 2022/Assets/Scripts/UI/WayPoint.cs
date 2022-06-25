using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WayPoint : MonoBehaviour
{
    public Image sprite;
    public Transform target;

    public TextMeshProUGUI distance;

    float minX,maxX,minY,maxY;
    // Update is called once per frame
    void Update()
    {
        distance.text = Vector3.Distance(transform.position,target.position).ToString("F0");
        minX = sprite.GetPixelAdjustedRect().width / 2;
        maxX = Screen.width - minX;
        minY = sprite.GetPixelAdjustedRect().height / 2;
        maxY = Screen.height - minX;
        Vector2 pos = Camera.main.WorldToScreenPoint(target.position);

        if(Vector3.Dot(target.position - transform.position,transform.forward) <0)
        {
            if(pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }
        pos.x = Mathf.Clamp(pos.x,minX,maxX);
        pos.y = Mathf.Clamp(pos.y,minY,maxY);
        sprite.transform.position = pos;
    }
}
