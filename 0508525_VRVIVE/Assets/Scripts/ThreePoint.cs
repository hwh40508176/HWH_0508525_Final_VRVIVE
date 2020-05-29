using UnityEngine;

public class ThreePoint : MonoBehaviour
{
    public bool inThreePoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            inThreePoint = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            inThreePoint = false;
        }
    }

}
