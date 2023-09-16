using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelSetter : MonoBehaviour
{

    public Button[] btnLevels;
    public Sprite[] spriteLevels;

    // Start is called before the first frame update
    void Start()
    {

        // PlayerPrefs.SetInt(Helper.USER_LEVEL, 1);
        for (int i = 0; i < Mathf.Min(PlayerPrefs.GetInt(Helper.USER_HIGH_SCORE, 1)) && i < btnLevels.Length; i++)
        {
            // for setting other sprite
            //btnLevels[i].GetComponent<Image>().sprite = spriteLevels[i];
            
            // for situations where there is a layer/key attached & we de don't need to use other sprite 
            btnLevels[i].transform.GetChild(0).gameObject.SetActive(false);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
