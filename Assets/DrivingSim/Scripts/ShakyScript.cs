using UnityEngine;

public class ShakyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float posx;
    private float posy;
    public bool active = false;
    public float degree = 1;

    public float xrad = 0.5f;
    public float yrad = 0.5f;

    public float xmag = 1; // speed, randomized each trial change.
    public float ymag = 1; // speed, randomized each trial change.

    public int xcool = 0;
    public int ycool = 0;

    public float yamount = 0;
    public float xamount = 0;

    private float xprog = 0.5f; // Starting positions. From 0 to 1
    private float yprog = 0.5f;

    void Start()
    {
        posx = transform.position.x;
        posy = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (xcool > 0)
            {
                xamount = 0;
                xcool--;

                if (xcool == 0)
                {
                    if (transform.position.x < posx)
                    {
                        xmag = Random.Range(0.5f, 1f);
                        xprog = 0;
                        //xamount = 0.1f;
                    }
                    else
                    {
                        xmag = -Random.Range(0.5f, 1f);
                        //xamount = 0.1f;
                        xprog = 0;
                    }
                }

            }
            else if (xmag > 0)
            {
                if (transform.position.x > posx + xrad)
                {
                    //Debug.Log("Erm I should be here");
                    xmag = 0;
                    xamount = 0;
                    xcool = Random.Range(12, 120);
                    xprog = 1;
                }
                else
                {

                    xamount = 0.01f * degree * xmag;
                    xprog = xprog + (0.01f * degree * xmag) / (2 * xrad);


                }

            }
            else if (xmag < 0)
            {
                if (transform.position.x < posx - xrad)
                {
                    xmag = 0;
                    xamount = 0;
                    xcool = Random.Range(12, 120);
                    xprog = 1;
                }
                else
                {
                    xamount = 0.01f * degree * xmag;
                    xprog = xprog + (0.01f * degree * xmag) / (2 * xrad);
                }
            }


            if (ycool > 0)
            {
                yamount = 0;
                ycool--;

                if (ycool == 0)
                {
                    if (transform.position.y < posy)
                    {
                        ymag = Random.Range(0.5f, 1f);
                        yprog = 0;
                        //xamount = 0.1f;
                    }
                    else
                    {
                        ymag = -Random.Range(0.5f, 1f);
                        //xamount = 0.1f;
                        yprog = 0;
                    }
                }

            }
            else if (ymag > 0)
            {
                if (transform.position.y > posy + yrad)
                {
                    //Debug.Log("Erm I should be here");
                    ymag = 0;
                    yamount = 0;
                    ycool = Random.Range(12, 120);
                    yprog = 1;
                }
                else
                {

                    yamount = 0.01f * degree * ymag;
                    yprog = yprog + (0.01f * degree * ymag) / (2 * yrad);


                }

            }
            else if (ymag < 0)
            {
                if (transform.position.y < posy - yrad)
                {
                    ymag = 0;
                    yamount = 0;
                    ycool = Random.Range(12, 120);
                    yprog = 1;
                }
                else
                {
                    yamount = 0.01f * degree * ymag;
                    yprog = xprog + (0.01f * degree * ymag) / (2 * yrad);
                }
            }



            transform.position = new Vector3(transform.position.x + Mathf.Sqrt(2f)*Mathf.Sin(Mathf.PI*xprog) * xamount, transform.position.y + Mathf.Sqrt(2f) * Mathf.Sin(Mathf.PI * yprog) * yamount, 0); 
            //Debug.Log(transform.position.x);
        }
        
    }
}
