using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRecognizer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private SpriteRenderer sr;
    private ParkStick stick;
    private KeyHole key;
    private Transform scoretext;
    private TMPro.TextMeshProUGUI themesh;
    private CarScript car;
    void Start()
    {
        scoretext = transform.Find("Canvas").Find("ScoreText");
        themesh = scoretext.GetComponent<TMPro.TextMeshProUGUI>();
        sr = transform.gameObject.GetComponent<SpriteRenderer>();
        stick = transform.parent.parent.Find("carshift_0").GetComponent<ParkStick>();
        key = transform.parent.parent.Find("carkey_0").GetComponent<KeyHole>();
        car = transform.parent.parent.GetComponent<CarScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if ((!key.keyTurn) && stick.carState == 0 && sr.color != new Color(1, 1, 1, 1))
        {
            sr.color = new Color(1, 1, 1, 1);
            themesh.color = new Color(1, 1, 1, 0);
        }
        else if (key.keyTurn && stick.carState == 0 && sr.color != new Color(0, 0, 0, 1))
        {
            sr.color = new Color(0, 0, 0, 1);
            themesh.color = new Color(1, 1, 1, 1);
            themesh.text = ("Score: " + car.score+"/" + car.maxscore);
        }
        else if (stick.carState > 0 && sr.color != new Color(1, 1, 1, 0))
        {
            sr.color = new Color(1, 1, 1, 0);
            themesh.color = new Color(1, 1, 1, 0);
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
