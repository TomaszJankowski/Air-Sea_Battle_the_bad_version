using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlChanger : MonoBehaviour {

    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public int lvlToLoad;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void FadeToLevel(int lvlIndex)
    {
        lvlToLoad = lvlIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        animator.SetTrigger("FadeIn");
        SceneManager.LoadScene(lvlToLoad);
    }
}
