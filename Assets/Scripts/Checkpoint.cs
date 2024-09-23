using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clip;

    private void OnTriggerEnter(Collider other)
    {
        _animator.SetTrigger("Entry");
        _audioSource.PlayOneShot(_clip);
    }
}
