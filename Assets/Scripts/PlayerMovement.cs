using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] float playerSpeed = 10f;
  [SerializeField] float rotationSpeed = 100f;
  [SerializeField] float jumpForce = 8f;

  private Rigidbody2D rb;

  public Animator animator;
  public AudioSource jumpAudio;
  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {

    if(Keyboard.current.aKey.isPressed)
    {
      transform.Translate(Vector2.left *  playerSpeed * Time.deltaTime, Space.World);
      transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
    if(Keyboard.current.dKey.isPressed)
    {
      transform.Translate(Vector2.right * playerSpeed * Time.deltaTime, Space.World);
      transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }
    if (Keyboard.current.spaceKey.wasPressedThisFrame)
    {
      jumpAudio.Play();
      rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
      animator.SetBool("Jump", true);
    }
    else
    {
      animator.SetBool("Jump", false);
    }
  }
}
