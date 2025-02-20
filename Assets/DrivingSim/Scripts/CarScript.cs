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


    private int signprog = 0; // From 0 to 100, fades from 0-20, and you have until 80 (80 to 100 fades out) to respond.
    private int signtype = 0; // 0 is cooldown, 1 is stop, 2 is turn right, 3 is turn left.
    private int currentpoints = 0; // this is added to score each event, but by being more than zero, you know the event has concluded.
    
    private bool lturn = false;
    private bool rturn = false;
    private float spin = 0;
    private bool brakes = false;
    private bool accel = false;
    private float basespeed = 50;
    private float maxspeed = 100;
    private float speed = 0;

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
        turnl = transform.Find("carturn_0");
        turnr = transform.Find("carturn_1");
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
                speed = speed / 1.01f;

                if (speed < 0.001f)
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
            if (Random.Range(1, 50) == 49)
            {
                playerData.drivingPoint++;
                score++;
                maxscore++;
            }
            playerData.drivingMiles += 0.0001f;
            if (!drivesound.isPlaying)
            {
                
                //drivesound.Play();
            }
        else
            {
                drivesound.Pause();
            }
        }
    }

    
}
