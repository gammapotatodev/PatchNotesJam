using UnityEngine;

public class DoorSystem : MonoBehaviour
{
  [SerializeField] AudioSource doorSound;

  private InventorySystem playerInventory;
  private int keyCounter;

  public GameObject closedDoor;
  public GameObject openedDoor;
  public Animator animator;

  private void Start()
  {
    playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>();
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.CompareTag("Player"))
    {
      keyCounter = 0;
      for (int i = 0; i < playerInventory.slots.Length; i++)
      {
        if (playerInventory.isFull[i] == true)
        {
          keyCounter++;
        }
      }
      if(keyCounter == 3)
      {
        doorSound.Play();
        closedDoor.SetActive(false);
        openedDoor.SetActive(true);
        animator.SetTrigger("ShowTrigger");
      } 
    }
  }
  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      animator.SetTrigger("CloseTrigger");
    }
  }
}
