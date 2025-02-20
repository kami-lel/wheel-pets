using UnityEngine;

public class WheelTurn : MonoBehaviour
{

    private bool lturn = false;
    private bool rturn = false;
    private float spin = 0;
    private AudioSource wheelsound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wheelsound = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        lturn = false;
        rturn = false;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            lturn = true;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rturn = true;
        }
        
        if (lturn && !rturn)
        {
            spin++;
            transform.Rotate(new Vector3(0, 0, 2));
            if (!wheelsound.isPlaying)
            {
                wheelsound.Play();
            }
            
        }
        else if (rturn && !lturn)
        {
            spin--;
            transform.Rotate(new Vector3(0, 0, -2));
            if (!wheelsound.isPlaying)
            {
                wheelsound.Play();
            }
        }
        else if (!(lturn || rturn))
        {
            transform.rotation = new Quaternion(0,0,0,0);
            spin = spin / 1.04f;
            transform.Rotate(0, 0, spin);
            wheelsound.Pause();
        }
        else
        {
            wheelsound.Pause();
        }

    }

}
