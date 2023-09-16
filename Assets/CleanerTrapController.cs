using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerTrapController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        GameManager.instance.fallenBalls++;
//        collision.gameObject.SetActive(false);

    }

}
