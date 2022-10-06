using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// NPC looks better than Npc so we use that naming
// ReSharper disable once InconsistentNaming
public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextAsset textFile;
    
    private string[] _dialogue;
    private int _index;

    public float textSpeed;
    private bool _playerIsClose;
    private bool _scrollingDone;
    
    
    
    // Use this for initialization
    void Start () 
    {
        // Make sure there this a text
        // file assigned before continuing
        if(textFile != null)
        {
            // Add each line of the text file to
            // the array using the new line
            // as the delimiter
            _dialogue = ( textFile.text.Split( '\n' ) );
        }
        
        ZeroText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _playerIsClose)
        {

            if (dialoguePanel.activeInHierarchy)
            {
                if (_scrollingDone)
                {

                    NextLine();
                }
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (dialogueText.text == _dialogue[_index] && !_scrollingDone)
        {
            _scrollingDone = true;
        }
    }

    private void ZeroText()
    {
        dialogueText.text = "";
        _index = 0;
        _scrollingDone = false;
        dialoguePanel.SetActive(false);
        StopAllCoroutines();
    }

    private IEnumerator Typing()
    {
        foreach (char letter in _dialogue[_index])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (_index < _dialogue.Length - 1)
        {
            _index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerIsClose = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerIsClose = false;
            ZeroText();
        }
    }

}
