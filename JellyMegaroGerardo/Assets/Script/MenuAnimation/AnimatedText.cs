using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimatedText : MonoBehaviour
{
    public float strech;
    public float speed;
    [SerializeField]
    private Ease _moveEase = Ease.Linear;
    //bool exit=true;

    public void OnMouseEnter()
    {
        int n = Random.Range(0, 2);
        print(n);
        if (n == 1)//&&exit)
        {
            transform.DOScaleX(0.5f, speed);
            transform.DOScaleY(1.5f, speed);
            //exit = false;
        }
        else
        {
            transform.DOScaleX(1.5f, speed);
           // exit = false;
        }
        
    }

    public void OnMouseExit()
    {
        transform.DOScaleX(1, speed);
        transform.DOScaleY(1, speed);
        //exit = true;
    }
}
