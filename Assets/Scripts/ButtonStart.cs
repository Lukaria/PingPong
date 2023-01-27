using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStart : MonoBehaviour
{
    public GameObject Text;
    public GameObject Ball;
    public void GameStart()
    {
        Instantiate(Ball);
        Text.SetActive(true);
        gameObject.SetActive(false);
    }
}
