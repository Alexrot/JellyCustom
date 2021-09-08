using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BumpAndCollision : MonoBehaviour
{
    public static int point;
    public static bool win;
    public Text vite;
    public Text coinGet;
    static int viteStat=2;

    public GameObject endingScreen;
    public GameObject controls;


    public float nextMove;
    int direction = 0;
    int rotation = 0;

    bool coinMultiplier=false;
    public float movimentBack = 5;
    public float movimentSpeed = 12;
    public float speedBack = 0.5f;

    public float speedUpTime = 2;
    public float acceleration = 1.5f;
    
    public float rotationSpeed = 0.23f;

    static Renderer rend;
    [SerializeField]
    private Ease _moveEase = Ease.Linear;

    void Start()
    {
        if (PlayerData.skin != null)
        {
            rend = GetComponent<Renderer>();
            ChangeSkin();
        }
    }

    public static void ChangeSkin()
    {
        rend.sharedMaterial = PlayerData.skin;
         new BumpAndCollision().SummonBuff(PlayerData.skinBuff);
    }

    public void SummonBuff(int buff)
    {
        switch (buff)
        {
            case 3:
                movimentSpeed = 7f;
                acceleration = 3;
                break;
            case 4:
                coinMultiplier = true;
                break;
            case 5:
                viteStat = 2;
                break;
            default:
                movimentSpeed = 12f;
                acceleration = 2;
                coinMultiplier = false;
                viteStat = 2;
                break;
        }
    }

    public void StartGame()
    {
        
        vite.text = viteStat.ToString();
        nextMove = 37.2f;
        transform.DOMoveZ(nextMove, movimentSpeed).SetEase(_moveEase);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other);

        if (other.CompareTag("Gate"))
        {
            Hit();
            StartCoroutine(Bump());
        }
        else if(other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            if (coinMultiplier)
            {
                point+=2;
            }
            else
            {
                point++;
            }
            
            coinGet.text = point.ToString();
        }
        else if (other.CompareTag("Check"))
        {
            direction++;
            rotation = rotation + 90;
            CalcNewDirection();
        }
        else if (other.CompareTag("Check2"))
        {
            direction++;
            rotation = rotation - 90;
            CalcNewDirection();
        }
        else if (other.CompareTag("End"))
        {
            DOTween.Kill(transform);
            Goal();
        }
        else if (other.CompareTag("Speed"))
        {
            StartCoroutine(SpeedUp());
        }
    }

    private IEnumerator Bump()
    {
        switch (direction)
        {
            case 0:
                movimentBack = transform.position.z - 1;
                DOTween.Kill(transform);
                transform.DOMoveZ(movimentBack, speedBack).SetEase(_moveEase);
                yield return new WaitForSeconds(speedBack);
                transform.DOMoveZ(nextMove, (movimentSpeed * (Mathf.Abs(nextMove - transform.position.z)) / nextMove)).SetEase(_moveEase);
                break;
            case 1:
                movimentBack = transform.position.x - 1;
                DOTween.Kill(transform);
                transform.DOMoveX(movimentBack, speedBack).SetEase(_moveEase);
                yield return new WaitForSeconds(speedBack);
                transform.DOMoveX(nextMove, (movimentSpeed * (Mathf.Abs(nextMove - transform.position.x)) / nextMove)).SetEase(_moveEase);
                break;
            case 2:
                movimentBack = transform.position.z - 1;
                DOTween.Kill(transform);
                transform.DOMoveZ(movimentBack, speedBack).SetEase(_moveEase);
                yield return new WaitForSeconds(speedBack);
                transform.DOMoveZ(nextMove, (movimentSpeed * (Mathf.Abs(nextMove - transform.position.z)) / nextMove)).SetEase(_moveEase);
                break;

        }
    }

    public IEnumerator SpeedUp()
    {
        if (direction == 0|| direction == 2) 
        {
            DOTween.Kill(transform);
            transform.DOMoveZ(nextMove, ((movimentSpeed/ acceleration) * (Mathf.Abs(nextMove - transform.position.z)) / nextMove)).SetEase(_moveEase);
            yield return new WaitForSeconds(speedUpTime);
            transform.DOMoveZ(nextMove, (movimentSpeed * (Mathf.Abs(nextMove - transform.position.z)) / nextMove)).SetEase(_moveEase);
        }
        else
        {

            DOTween.Kill(transform);
            transform.DOMoveX(nextMove, ((movimentSpeed / acceleration) * (Mathf.Abs(nextMove - transform.position.x)) / nextMove)).SetEase(_moveEase);
            yield return new WaitForSeconds(speedUpTime);
            transform.DOMoveX(nextMove, (movimentSpeed * (Mathf.Abs(nextMove - transform.position.x)) / nextMove)).SetEase(_moveEase);
        }

    }

    public void Hit()
    {
        viteStat--;
        if (viteStat < 0)
        {
            controls.SetActive(false);
            DOTween.Kill(transform);
            win = false;
            endingScreen.SetActive(true);
            
            DOTween.Kill(transform);
        }
        vite.text = viteStat.ToString();
    }

    public void Goal()
    {
        win = true;
        controls.SetActive(false);
        endingScreen.SetActive(true);
    }
   
    public void CalcNewDirection()
    {
        DOTween.Kill(transform);
        StartCoroutine(RotateToDir(new Vector3(0, rotation, 0)));
        switch (direction)
        {
            case 1:
                nextMove = 37;
                transform.DOMoveX(37, movimentSpeed).SetEase(_moveEase);
                break;
            case 2:
                nextMove = 74;
                transform.DOMoveZ(74, movimentSpeed).SetEase(_moveEase);
                break;

        }
    }


    private IEnumerator RotateToDir(Vector3 rotation)
    {
        transform.DORotate(rotation, rotationSpeed, RotateMode.FastBeyond360).SetEase(_moveEase);
        yield return new WaitForSeconds(rotationSpeed);
    }
}
