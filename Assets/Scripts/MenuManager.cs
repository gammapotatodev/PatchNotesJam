using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
  public void StartGameButton()
  {
    SceneTransition.SwitchLevel("Level1");
  }

  public void ExitGameButton()
  {
    Application.Quit();
  }

  void Update()
  {
    if(Keyboard.current.escapeKey.wasPressedThisFrame && SceneManager.GetActiveScene().name != "MainMenu")
    {
      SceneTransition.SwitchLevel("MainMenu");
    }
  }
}
