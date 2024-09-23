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
            animator.Play("CasualAnimation");  // �������� �� �������� ��� �������� ��� casual
        }
        else if (middleRenderer.enabled)
        {
            animator.Play("MiddleAnimation");  // �������� �� �������� ��� �������� ��� middle
        }
        else if (richRenderer.enabled)
        {
            animator.Play("RichAnimation");  // �������� �� �������� ��� �������� ��� rich
        }
    }

    private void Update()
    {
        // ��������� �������� ������ ����, ���� ��������� ����������
        UpdateAnimationBasedOnModel();
    }
}
