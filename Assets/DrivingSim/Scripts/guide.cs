using UnityEngine;

public class guide : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private PlayerData playerData;

    private SpriteRenderer sr;
    private SpriteRenderer sr1;
    private SpriteRenderer sr2;
    private SpriteRenderer sr3;
    void Start()
    {
        playerData = Data.GetPlayerData();
        sr1 = transform.Find("bookopen_0").GetComponent<SpriteRenderer>();
        sr2 = transform.Find("frenchbook_0").GetComponent<SpriteRenderer>();
        sr3 = transform.Find("spanishbook_0").GetComponent<SpriteRenderer>();
        sr = sr1;
        if (playerData.language == "es")
        {
            sr = sr3;
        }
        else if (playerData.language == "fr")
        {
            sr = sr2;
        }
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
