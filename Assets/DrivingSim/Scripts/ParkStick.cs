using UnityEngine;

public class ParkStick : MonoBehaviour
{
    public int carState = 0; // 0 -- Park, 1 -- Neutral, 2 -- Reverse, 3 -- Drive

    private SpriteRenderer sr;

    private SpriteRenderer psr;
    private SpriteRenderer dsr;
    private AudioSource sticksound;
    private CarScript car;
    private PlayerData playerData;
    private KeyHole key;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        key = transform.parent.Find("carkey_0").GetComponent<KeyHole>();
        sr = transform.gameObject.GetComponent<SpriteRenderer>();
        psr = transform.Find("carstick_0").GetComponent<SpriteRenderer>();
        dsr = transform.Find("carstick_1").GetComponent<SpriteRenderer>();
        sticksound = transform.GetComponent<AudioSource>();
        car = transform.parent.GetComponent<CarScript>();
        playerData = Data.GetPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        if (carState == 0 && psr.color != new Color(1, 1, 1, 1))
        {
            dsr.color = new Color(1, 1, 1, 0);
            psr.color = new Color(1, 1, 1, 1);
        }
        else if (carState == 3 && dsr.color != new Color(1, 1, 1, 1))
        {
            psr.color = new Color(1, 1, 1, 0);
            dsr.color = new Color(1, 1, 1, 1);
        }
    }

    private void OnMouseDown()
    {
        if (carState == 0 && key.keyTurn)
        {
            sticksound.Play();
            carState = 3;
            car.failedpark = false;
        }
        else
        {
            if (carState != 0)
            {
                sticksound.Play();
                car.maxscore += 3;
                if (car.speed > 0)
                {
                    car.failedpark = true;
                }
                else
                {
                    car.score += 3;
                    playerData.drivingPoint += 3;
                    car.parks++;
                }

                carState = 0;
            }
            

            
        }

    }
}
