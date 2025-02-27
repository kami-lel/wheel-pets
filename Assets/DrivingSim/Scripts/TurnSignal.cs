using UnityEngine;

public class TurnSignal : MonoBehaviour
{
    private float signspeed = 0.3f;
    private float signprog = 0;
    public bool turning = false;
    private SpriteRenderer sr;
    private KeyHole hole;
    private TurnSignal leftsignal;
    private TurnSignal rightsignal;
    private AudioSource turnsound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = transform.gameObject.GetComponent<SpriteRenderer>();
        hole = transform.parent.Find("carkey_0").GetComponent<KeyHole>();
        leftsignal = transform.parent.Find("carturn_0").GetComponent<TurnSignal>();
        rightsignal = transform.parent.Find("carturn_1").GetComponent<TurnSignal>();
        turnsound = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        signprog+= Time.deltaTime;
        if (turning && signprog > signspeed)
        {
            signprog = 0;

            if (sr.color == new Color(1,1,1,1))
            {
                sr.color = new Color(1.3f, 0.4f, 1.3f, 1);
                turnsound.Play();
            }
            else
            {
                sr.color = new Color(1, 1, 1, 1);
            }
        }
        else if (!turning && sr.color != new Color(1, 1, 1, 1))
        {
            sr.color = new Color(1, 1, 1, 1);
        }
    }

    private void OnMouseDown()
    {
        if (hole.keyTurn)
        {
            sr.color = new Color(1, 1, 1, 1);
            turning = !turning;
            if (leftsignal.turning && rightsignal.turning)
            {
                leftsignal.turning = false;
                rightsignal.turning = false;
                turning = !turning;
            }
        }
        
    }
}
