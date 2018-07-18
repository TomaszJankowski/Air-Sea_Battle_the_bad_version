using UnityEngine;

public class FadeToScene : MonoBehaviour {

    [HideInInspector]
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("FadeInOptions");
    }
}
