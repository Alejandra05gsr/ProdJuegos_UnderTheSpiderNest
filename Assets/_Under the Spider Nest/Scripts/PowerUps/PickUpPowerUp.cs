using UnityEngine;

public class PickUpPowerUp : MonoBehaviour
{
    public PowerUps powerUp; // arrastras el del Player

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        powerUp.gameObject.SetActive(true);

        powerUp.ActivatePowerUp();

        Destroy(gameObject);
    }
}


