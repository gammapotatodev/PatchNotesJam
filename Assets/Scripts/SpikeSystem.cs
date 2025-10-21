using UnityEngine;
using UnityEngine.InputSystem;

public class SpikeSystem : MonoBehaviour
{
  [SerializeField] GameObject deathScreen;
  [SerializeField] AudioSource deathSound;
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      deathSound.Play();
      Destroy(GameObject.FindGameObjectWithTag("Player"));
      deathScreen.SetActive(true);
    }
  }
}
