using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.isGameOver = true;
        Destroy(collision.gameObject);
    }
}
