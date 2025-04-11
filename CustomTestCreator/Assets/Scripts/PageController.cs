using UnityEngine;

public class PageController : MonoBehaviour
{
    public void DisplayPage(GameObject page)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);

        page.SetActive(true);
    }
}
