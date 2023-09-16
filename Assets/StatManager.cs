using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatManager : MonoBehaviour
{
    public TextMeshProUGUI txtHighScore;
    // Start is called before the first frame update
    void Start()
    {
        txtHighScore.text = Helper.getHighScore()+"m";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
