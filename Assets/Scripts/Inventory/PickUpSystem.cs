using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
  [SerializeField] AudioSource pickUpSound;

  private InventorySystem inventory;
  public GameObject slotItem;

  private void Start()
  {
    inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>();
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.CompareTag("Player"))
    {
      for(int i = 0; i < inventory.slots.Length; i++)
      {
        if (inventory.isFull[i] == false)
        {
          pickUpSound.Play();
          inventory.isFull[i] = true;
          Instantiate(slotItem, inventory.slots[i].transform);
          Destroy(gameObject);
          break; 
        }
      }
    }
  }
}
