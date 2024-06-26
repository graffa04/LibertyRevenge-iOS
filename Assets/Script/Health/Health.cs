using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set;}
    public GameOverScreen gameOverScreen;
    public GameObject spritePrefab; 
    
    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if(currentHealth > 0)
        {
            //player hurt
        } 
        else if (currentHealth == 0 )
        {
            gameOverScreen.Setup((int)currentHealth);

            gameObject.SetActive(false);
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);

    }
}
