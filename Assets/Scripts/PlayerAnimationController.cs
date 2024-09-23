using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer casualRenderer;
    [SerializeField] private SkinnedMeshRenderer middleRenderer;
    [SerializeField] private SkinnedMeshRenderer richRenderer;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        UpdateAnimationBasedOnModel();
    }

    private void UpdateAnimationBasedOnModel()
    {
        if (casualRenderer.enabled)
        {
            animator.Play("CasualAnimation");  // Заменить на реальное имя анимации для casual
        }
        else if (middleRenderer.enabled)
        {
            animator.Play("MiddleAnimation");  // Заменить на реальное имя анимации для middle
        }
        else if (richRenderer.enabled)
        {
            animator.Play("RichAnimation");  // Заменить на реальное имя анимации для rich
        }
    }

    private void Update()
    {
        // Обновляем анимацию каждый кадр, если состояние изменилось
        UpdateAnimationBasedOnModel();
    }
}
