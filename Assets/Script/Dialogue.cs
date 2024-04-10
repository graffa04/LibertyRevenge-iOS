using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI TextComponent; 
    public string[] lines;
    public float textSpeed;
    private int index;
    public GameObject actionButton;
    public GameObject PlayerFire;
    public GameObject Panel;
    public GameObject Panel2;
    // Start is called before the first frame update
    void Start()
    {
        TextComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(TextComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                TextComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine()); 
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            TextComponent.text += c; 
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            TextComponent.text = string.Empty;
            StartCoroutine(TypeLine());

            if(index == 4)
            {
                DoAction(); 
            }
        }
        else 
        {
            gameObject.SetActive(false);            
        }
    }
    public void DoAction()
    {
        
        if (Panel != null)
        {
            Debug.Log("Azione eseguita!");

            Destroy(Panel.gameObject);

            Panel2.gameObject.SetActive(true);

            PlayerFire.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Il riferimento al pannello è nullo.");
        }
    }
}
