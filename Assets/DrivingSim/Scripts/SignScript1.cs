using UnityEngine;

public class SignScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 startpos;
    public Vector3 startscale;
    void Start()
    {
        startscale = transform.localScale;
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
