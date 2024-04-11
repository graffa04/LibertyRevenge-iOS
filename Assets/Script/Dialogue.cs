using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public float doubleClickThreshold = 0.5f; 
    private float lastClickTime = 0f;
    public TextMeshProUGUI TextComponent; 
    public string[] lines;
    public float textSpeed;
    private int index;
    public GameObject actionButton;
    public GameObject PlayerFire;
    public GameObject PlayerShield;
    public GameObject Panel;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject JoeBiden;
    public GameObject Balloon;
    public GameObject JoeBiden1;
    public GameObject Balloon1;
    public GameObject PlayGame;
    // Start is called before the first frame update
    void Start()
    {
        TextComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
    {
        if (Time.time - lastClickTime < doubleClickThreshold)
        {
            OnDoubleClick();
        }

        lastClickTime = Time.time;
    }
    }

    void OnDoubleClick()
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

            if(index == 5)
            {
                Fire(); 
            } 
            
            if(index == 6)
            {
                Shield();
            } 

            if(index == 8)
            {
                PlayGame.gameObject.SetActive(true);
            }
        }
        else 
        {
            gameObject.SetActive(false);            
        }
    }
    public void Fire()
    {
        
        if (Panel != null)
        {
            Destroy(Panel.gameObject);

            Panel2.gameObject.SetActive(true);

            PlayerFire.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Il riferimento al pannello è nullo.");
        }
    }

    public void Shield()
    {
        if (Panel2 != null)
        {
            Destroy(Panel2.gameObject);
            
            Destroy(PlayerFire.gameObject);

            Panel3.gameObject.SetActive(true);

            // Puoi utilizzare anche CanvasGroup se gli oggetti sono UI
            CanvasGroup joeBidenCanvasGroup = JoeBiden1.GetComponent<CanvasGroup>();
            if (joeBidenCanvasGroup != null)
            {
                joeBidenCanvasGroup.alpha = 1f; // Imposta l'opacità desiderata (0 = trasparente, 1 = opaco)
            }

            CanvasGroup balloonCanvasGroup = Balloon1.GetComponent<CanvasGroup>();
            if (balloonCanvasGroup != null)
            {
                balloonCanvasGroup.alpha = 1f; // Imposta l'opacità desiderata (0 = trasparente, 1 = opaco)
            }

            Destroy(JoeBiden.gameObject);

            Destroy(Balloon.gameObject);

            PlayerShield.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Il riferimento al pannello è nullo.");
        }
    }
}
