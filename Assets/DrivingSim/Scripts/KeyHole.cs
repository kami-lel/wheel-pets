using UnityEngine;

public class KeyHole : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private SpriteRenderer sr;
    public bool keyTurn = false;
    private int maxTurn = 70;
    private int currentTurn = 0;
    private ParkStick stick;
    private TurnSignal lturn;
    private TurnSignal rturn;
    private AudioSource enginesound;
    
    void Start()
    {
        stick = transform.parent.Find("carshift_0").GetComponent<ParkStick>();
        sr = transform.gameObject.GetComponent<SpriteRenderer>();
        rturn = transform.parent.Find("carturn_0").GetComponent<TurnSignal>();
        lturn = transform.parent.Find("carturn_1").GetComponent<TurnSignal>();
        enginesound = transform.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (keyTurn)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                lturn.turning = true;
                if (rturn.turning == true)
                {
                    rturn.turning = false;
                }
            }
            else if (Input.GetKey(KeyCode.E))
            {
                rturn.turning = true;
                if (lturn.turning == true)
                {
                    lturn.turning = false;
                }
            }
        }


        if (currentTurn > 0)
        {

            sr.color = new Color(1+(float)currentTurn/(2*maxTurn),1,1,1);
            currentTurn--;
        }
    }

    private void OnMouseDown()
    {



        if (stick.carState == 0)
        {
            keyTurn = !keyTurn;
            currentTurn = maxTurn;
            sr.flipX = !sr.flipX;

            if (!keyTurn)
            {
                enginesound.Stop();
                lturn.turning = false;
                rturn.turning = false;
            }
            else
            {
                enginesound.Play();
            }
        }
        
    }
}
