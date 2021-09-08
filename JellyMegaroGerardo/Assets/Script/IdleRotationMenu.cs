using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IdleRotationMenu : MonoBehaviour
{
    public Vector3 rotation;
    public float speed;
    [SerializeField]
    private Ease _moveEase = Ease.Linear;
    void Start()
    {
        transform.DORotate(rotation, 2,RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetRelative().SetEase(_moveEase); 
    }

}
