using UnityEngine;

public class guide : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private SpriteRenderer sr;
    void Start()
    {
        sr = transform.Find("bookopen_0").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (sr.color == new Color(1,1,1,1))
        {
            sr.color = new Color(1, 1, 1, 0);
            
        }
        else
        {
            sr.color = new Color(1, 1, 1, 1);
        }
    }
}
