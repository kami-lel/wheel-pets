using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRecognizer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private SpriteRenderer sr;
    private ParkStick stick;
    void Start()
    {
        sr = transform.gameObject.GetComponent<SpriteRenderer>();
        stick = transform.parent.parent.Find("carshift_0").GetComponent<ParkStick>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stick.carState == 0 && sr.color != new Color(1, 1, 1, 1))
        {
            sr.color = new Color(1, 1, 1, 1);
        }
        else if (stick.carState > 0 && sr.color == new Color(1, 1, 1, 1))
        {
            sr.color = new Color(1, 1, 1, 0);
        }
    }

    private void OnMouseDown()
    {
        //Debug.Log("Should be working!");
        if (sr.color == new Color(1,1,1,1))
        {
            //Debug.Log("Why not?");
            SceneManager.LoadScene("TitleScene");
            //GameObject.Find("SceneManager").GetComponent<SceneChange>().lo
        }
    }
}
