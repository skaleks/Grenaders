using UnityEngine;

public class Gunsight : MonoBehaviour
{

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void ON()
    {
        gameObject.SetActive(true);
    }

    public void OFF()
    {
        gameObject.SetActive(false);
    }
}
