using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private AudioClip FireSoundClip;
    private AudioSource audioSource;
    public Projectile ProjectilePrefab;
    public Transform LaunchOffSet;
    public Button PlayerFire;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsMouseOverButton())
        {
            audioSource.clip = FireSoundClip;
            audioSource.Play();
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f; 

            Vector3 direction = (targetPosition - LaunchOffSet.position).normalized;

            Projectile newProjectile = Instantiate(ProjectilePrefab, LaunchOffSet.position, Quaternion.identity);
            newProjectile.SetDirection(direction);
        }
    }

    bool IsMouseOverButton()
    {
        if (PlayerFire == null)
            return false;

        RectTransform rectTransform = PlayerFire.transform as RectTransform;
        if (rectTransform == null)
            return false;

        Vector2 mousePosition = Input.mousePosition;
        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition);
    }
}
