using UnityEngine;

public class KontaktZPrzeszkoda : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Kontakt z przeszkodą!");
        }
    }
}