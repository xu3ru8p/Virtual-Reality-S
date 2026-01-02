using UnityEngine;

public class FlagController : MonoBehaviour
{
    public GameObject flag;
    public GameObject objectB;

    private bool isGrabbed = false;

    private void Update()
    {
        if (isGrabbed && flag.activeSelf)
        {
            flag.SetActive(false);
            objectB.SetActive(true);
        }
    }

    public void OnGrab()
    {
        isGrabbed = true;
    }
}
