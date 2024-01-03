using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogObj; //Dialogue window
    public Image profileSprite;
    public Text speechText;
    public Text actornameText; //NPC name

    [Header("Settings")]
    public float typingSpeed;

    private bool isShowing; //Visible Window
    private int index;
    private string[] sentences;

    public static DialogueControl instance;

    //Called before any start on scripts hierarchy
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {

    }

    public void Speech(string[] text)
    {
        if (!isShowing)
        {
            dialogObj.SetActive(true);
            sentences = text;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
