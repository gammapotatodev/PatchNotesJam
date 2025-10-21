using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
  private Animator animator;
  private AsyncOperation loadingSceneOperation;
  
  private static SceneTransition instance;
  private static bool isLoadingEnd = false;

  public static void SwitchLevel(string sceneName)
  {
    instance.animator.SetTrigger("LoadingStart");
    instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
    instance.loadingSceneOperation.allowSceneActivation = false;
  }

  public void OnAnimationOver()
  {
    isLoadingEnd = true;
    loadingSceneOperation.allowSceneActivation = true;
  }
  private void Start()
  {
    instance = this;
    animator = GetComponent<Animator>();
    if (isLoadingEnd)
    {
      animator.SetTrigger("LoadingEnd");
    }
  }
}
