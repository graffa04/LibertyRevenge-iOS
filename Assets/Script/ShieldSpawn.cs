using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ShieldSpawn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject spritePrefab; 
    public Vector3 spawnPosition; 
    private GameObject instantiatedSprite; 
    public void OnPointerDown(PointerEventData eventData)
    {
        
        instantiatedSprite = Instantiate(spritePrefab, spawnPosition, Quaternion.identity);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
       
        if (instantiatedSprite != null)
        {
            Destroy(instantiatedSprite);
            instantiatedSprite = null;
        }
    }
}
