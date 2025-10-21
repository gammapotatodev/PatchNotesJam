using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  [SerializeField] GameObject finalPanel;
  [SerializeField] GameObject deathPanel;

  private void Update()
  {
    if(deathPanel.activeSelf)
    {
      if(Keyboard.current.spaceKey.wasPressedThisFrame)
      {
        RestartButton();
      }
    }
  }

  public void RestartButton()
  {
    Scene currentScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(currentScene.name);
  }

  public void NextLevelButton()
  {
    Destroy(GameObject.FindGameObjectWithTag("Player"));
    SceneTransition.SwitchLevel("Level2");
  }

  public void Level3Button()
  {
    Destroy(GameObject.FindGameObjectWithTag("Player"));
    SceneTransition.SwitchLevel("Level3");
  }

  public void FinishButton()
  {
    SceneTransition.SwitchLevel("MainMenu");
  }

  public void FinishDemoButton()
  {
    Destroy(GameObject.FindGameObjectWithTag("Player"));
    finalPanel.SetActive(true);
  }
}
