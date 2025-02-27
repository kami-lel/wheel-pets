using UnityEngine;

public class SpritePop : MonoBehaviour
{

    public int raisepop = 0;
    public int raiselast = 0;
    public int raisemax = 15;
    public float raiseamount = 0.4f;
    public float xsize = 0.12206f;
    public float ysize = 0.2789f;

    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(xsize * (1 + raiseamount * (float)raisepop / raisemax), ysize * (1 + raiseamount * (float)raisepop / raisemax), ysize); ;

        if (raisepop == raiselast && raisepop >= 1)
        {
            raisepop--;
        }
        raiselast = raisepop;


    }

    private void OnMouseOver()
    {
        if (raisepop < raisemax)
        {
            raisepop++;
        }
        //transform.rotation.Set(0, 0, 0, 0);
    }
}
