using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    bool win;
    public Text result;
    public Text resultPoint;
    public Button next;
    public Button redo;

    void Start()
    {
        if (BumpAndCollision.win)
        {
            result.text = "WIN";
            next.gameObject.SetActive(true);
        }
        else
        {
            result.text = "LOSE";
            redo.gameObject.SetActive(true);
        }
        resultPoint.text = BumpAndCollision.point.ToString();
    }
}
