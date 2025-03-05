using UnityEngine;

public class CarScript : MonoBehaviour
{
    GameObject wheel;
    Transform keyhole;
    ParkStick stick;
    Transform turnl;
    Transform turnr;
    Transform screen;
    Transform signstop;
    Transform signturn;
    Transform currentsign;

    GameObject cloud1;
    GameObject cloud2;
    GameObject hill;
    GameObject road;
    GameObject land;
    GameObject sky;

    ShakyScript sroad;
    ShakyScript shill;
    ShakyScript sland;



    public int score = 0; // When the car is in park, you can see your score.
    public int maxscore = 0; // This is the maximum amount of points you could have earned during this scene. Each perfect encounter is +3, each flawed is +1.
    public int turns = 0; // The number of turns (from turn sign) where you turned on your turn signal before turning.
    public int stops = 0; // The number of stop signs where you stopped before passing the sign.
    public int parks = 0; // The number of times you put the car in park after making sure it was stopped.


    private float signprog = 0; // From 0 to 100, fades from 0-20, and you have until 80 (80 to 100 fades out) to respond.
    private int signtype = 0; // 0 is cooldown, 1 is stop, 2 is turn right, 3 is turn left.
    private int currentpoints = 0; // this is added to score each event, but by being more than zero, you know the event has concluded.
    
    private bool lturn = false;
    private bool rturn = false;
    private float spin = 0;
    private bool brakes = false;
    private bool accel = false;
    private float basespeed = 50;
    private float maxspeed = 100;
    public float speed = 0;
    public bool failedpark = false; // turns true whenever parked incorrectly.

    private float hillspeed = 0;
    private float landspeed = 0;

    private PlayerData playerData;

    private AudioSource drivesound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wheel = GameObject.Find("carwheel_0");
        
        keyhole = transform.Find("carkey_0");
        stick = transform.Find("carshift_0").GetComponent<ParkStick>();
        turnl = transform.Find("carturn_1");
        turnr = transform.Find("carturn_0");
        screen = transform.Find("carscreen_0");

        cloud1 = GameObject.Find("bgcloud_0");
        cloud2 = GameObject.Find("bgcloud_1");
        hill = GameObject.Find("bghill_1");
        road = GameObject.Find("bgroad_0");
        signstop = road.transform.Find("signstop");
        signturn = road.transform.Find("signturn");
        land = GameObject.Find("bgland_0");
        sky = GameObject.Find("bgsky_0");
        hillspeed = hill.GetComponent<ShakyScript>().degree;
        landspeed = land.GetComponent<ShakyScript>().degree;
        drivesound = transform.GetComponent<AudioSource>();

        shill = hill.GetComponent<ShakyScript>();
        sland = land.GetComponent<ShakyScript>();
        sroad = road.GetComponent<ShakyScript>();

        playerData = Data.GetPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        brakes = false;
        accel = false;
        


        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            brakes = true;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            accel = true;
        }

        

        if (stick.carState == 3) // We're Driving!!!
        {
            if (brakes)
            {
                // Grind to halt
                speed = speed / 1.14f;

                if (speed < 0.4f)
                {
                    speed = 0;
                }
            }
            else if (accel)
            {
                if (speed < maxspeed)
                {
                    speed++;
                    if (speed > maxspeed)
                    {
                        speed = maxspeed;
                    }
                }
            }
            else
            {
                
                
                if (speed <= basespeed - 1)
                {
                    speed++;
                }
                else if(speed >= basespeed + 1)
                {
                    speed--;
                }
                else
                {
                    speed = basespeed;
                }
            }
            


        }
        else
        {
            speed = 0;
        }



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
            
        }
        else if (rturn && !lturn)
        {
            spin--;
            
        }
        else if (!(lturn || rturn))
        {
            spin = spin / 1.04f;
            if (spin < 0.01f)
            {
                spin = 0;
            }
        }






        //Debug.Log(speed);
        //Visual effects for speed and stuff

        sland.degree = landspeed * (speed / maxspeed);
        sroad.degree = landspeed * (speed / maxspeed);
        shill.degree = hillspeed * (speed / maxspeed);

        if (speed > 0)
        {
            if (signprog == 0 && Random.Range(1, 150) == 49)
            {
                
                signprog += Time.deltaTime * 80 * (speed / maxspeed);
                signtype = Random.Range(1, 4);

                if (signtype == 1)
                {
                    currentsign = signstop;
                }
                else if (signtype == 2)
                {
                    currentsign = signturn;
                    signturn.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    currentsign = signturn;
                    signturn.GetComponent<SpriteRenderer>().flipX = true;
                }

                currentsign.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1,((float) signprog ) / 20f);
                currentsign.position = currentsign.GetComponent<SignScript>().startpos + (currentsign.GetComponent<SignScript>().endpoint.position - currentsign.GetComponent<SignScript>().startpos) / 100;
                currentsign.localScale = currentsign.GetComponent<SignScript>().startscale + (currentsign.GetComponent<SignScript>().endpoint.localScale - currentsign.GetComponent<SignScript>().startscale) / 100;

            }
            else if (signprog > 0 && signprog < 20 )
            {
                signprog += Time.deltaTime * 80 * (speed / maxspeed);
                currentsign.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, ((float)signprog) / 20f);
                currentsign.position = currentsign.GetComponent<SignScript>().startpos + (currentsign.GetComponent<SignScript>().endpoint.position - currentsign.GetComponent<SignScript>().startpos) * signprog / 100;
                currentsign.localScale = currentsign.GetComponent<SignScript>().startscale + (currentsign.GetComponent<SignScript>().endpoint.localScale - currentsign.GetComponent<SignScript>().startscale) * signprog / 100;

            }
            else if (signprog > 0 && signprog < 80)
            {
                signprog += Time.deltaTime * 80 * (speed / maxspeed);
                currentsign.position = currentsign.GetComponent<SignScript>().startpos + (currentsign.GetComponent<SignScript>().endpoint.position - currentsign.GetComponent<SignScript>().startpos) * signprog / 100;
                currentsign.localScale = currentsign.GetComponent<SignScript>().startscale + (currentsign.GetComponent<SignScript>().endpoint.localScale - currentsign.GetComponent<SignScript>().startscale) * signprog / 100;

                if (currentpoints == 0)
                {
                    if (signtype == 1 && brakes)
                    {
                        maxscore += 10;
                        currentpoints += 10;
                        score += 10;
                        playerData.drivingPoint+=10;
                        signstop.GetComponent<SignScript>().endpoint.GetComponent<AudioSource>().Play();
                        stops++;
                    }
                    else if (signtype == 2 && spin < 0 && rturn)
                    {
                        maxscore += 10;
                        if (turnr.GetComponent<TurnSignal>().turning)
                        {
                            currentpoints += 10;
                            score += 10;
                            playerData.drivingPoint += 10;
                            signstop.GetComponent<SignScript>().endpoint.GetComponent<AudioSource>().Play();
                            turns++;
                        }
                        else
                        {
                            currentpoints--;
                        }
                    }
                    else if (signtype == 3 && spin > 0 && lturn)
                    {
                        maxscore += 10;
                        if (turnl.GetComponent<TurnSignal>().turning)
                        {
                            currentpoints += 10;
                            score += 10;
                            playerData.drivingPoint += 10;
                            signstop.GetComponent<SignScript>().endpoint.GetComponent<AudioSource>().Play();
                            turns++;
                        }
                        else
                        {
                            currentpoints--;
                        }
                    }
                }
            }
            else if (signprog > 0 && signprog < 100)
            {
                signprog += Time.deltaTime * 80 * (speed / maxspeed);
                currentsign.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f - (((float)signprog - 80f) / 20f));
                currentsign.position = currentsign.GetComponent<SignScript>().startpos + (currentsign.GetComponent<SignScript>().endpoint.position - currentsign.GetComponent<SignScript>().startpos) * signprog / 100;
                currentsign.localScale = currentsign.GetComponent<SignScript>().startscale + (currentsign.GetComponent<SignScript>().endpoint.localScale - currentsign.GetComponent<SignScript>().startscale) * signprog / 100;



                
            }

            if (signprog >= 100)
            {
                signprog = 0;
                signtype = 0;
                if (currentpoints == 0)
                {
                    maxscore += 10;
                }
                currentpoints = 0;


            }

            playerData.drivingMiles += 0.0001f;
            if (!drivesound.isPlaying)
            {
                
                //score++;
                //maxscore++;
                //drivesound.Play();
            }
        else
            {
                drivesound.Pause();
            }
        }
    }

    
}
