using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public static float morfingSpeed;
    public GameObject player;

    public void AdjustSize(float size)
    {
        player.transform.DOScaleX(Mathf.Abs(1.5f -size), morfingSpeed);
        player.transform.DOScaleY(Mathf.Abs(0.5f+size), morfingSpeed);
    }
}


