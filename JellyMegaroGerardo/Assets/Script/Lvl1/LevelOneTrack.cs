using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelOneTrack : MonoBehaviour
{

    public float moviment = 360f;
    public float movimentBack = 5;

    public Text vite;
    //quando si colpisce ai lati il gate ci sono 2 collisioni potrei risolvere rimuovendo 1 collider
    public Transform player;
    int viteStat = 4;
    public Text coin;

    public float speed;
    public float speedBack;
    [SerializeField]
    private Ease _moveEase = Ease.Linear;

    // Start is called before the first frame update
    void Start()
    {
        vite.text = (viteStat / 2).ToString();
        
    }

    public void Hit()
    {
        viteStat--;
        vite.text = (viteStat / 2).ToString();
    }

    public void Run()
    {
        player.transform.DOMoveZ(moviment, speed).SetEase(_moveEase);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {

            StartCoroutine(Bump());
        }
        else if (other.CompareTag("Coin"))
        {

        }
    }

    private IEnumerator Bump()
    {

        DOTween.Kill(transform);
        player.transform.DOMoveZ(movimentBack, speedBack).SetEase(_moveEase);
        yield return new WaitForSeconds(speedBack);
        player.transform.DOMoveZ(moviment, speed).SetEase(_moveEase);
    }
}
