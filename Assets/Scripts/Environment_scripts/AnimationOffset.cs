using UnityEngine;

public class AnimationOffset : MonoBehaviour
{
    private Animator animator;
    private float randomOffset;
    void Start()
    {
        animator = GetComponent<Animator>();
        randomOffset = Random.Range(0f, 1f);
        animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, 0, randomOffset);
    }
}
