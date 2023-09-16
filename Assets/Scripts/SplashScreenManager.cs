using System.Collections;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    public string nextScene= "Main";

    private float startTime;
    public float waitingSeconds = 5;

    public GameObject progressBar;

    // for preventing language loading redundancy
    private bool active = false;

    // project specific for progress bar
    public GameObject mover, destnation;

    // 
    // Start is called before the first frame update
    void Start()
    {
//        moveUp();
    }


    // Update is called once per frame
    void Update()
    {
        float now = Time.time;

        /*        if (now - startTime > waitingSeconds)
                    SceneManager.LoadScene(nextScene);*/

        
        
        
        if (progressBar.transform.position.y >= destnation.transform.position.y)//        if (System.String.Format("{0:.#}", progressBar.transform.position.y) >= System.String.Format("{0:.#}", destnation.transform.position.y))
        {
            SceneManager.LoadScene(nextScene);
        }

        //            rotateProgressBar();
        moveUp();
        //moveRight();

    }

    void rotateProgressBar()
    {
        progressBar.gameObject.transform.Rotate(0, 0, 1 * 100);

    }

    private void moveUp()
    {
        progressBar.gameObject.transform.Translate(Vector2.up * Time.deltaTime * 3);
    }

    private void moveRight()
    {
        progressBar.gameObject.transform.Translate(Vector2.right * Time.deltaTime * 2);
    }

 




}
