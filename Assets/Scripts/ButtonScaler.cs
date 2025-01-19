//watched this youtube tutorial to help with this script: https://www.youtube.com/watch?v=P65cluuL11c

using UnityEngine;
public class ButtonScaler : MonoBehaviour
{
    public void PointerEnter()
    {
        transform.localScale = new Vector2(0.52f, 0.6866667f);
    }

    public void PointerExit()
    {
        transform.localScale = new Vector2(0.5f, 0.6666667f);
    }
}
