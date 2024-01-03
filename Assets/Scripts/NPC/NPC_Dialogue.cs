using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogRange;
    public LayerMask playerLayer;
    public bool playerHit;
    public DialogueSettings dialogueSettings;
    private List<string> sentences = new List<string>();

    private void Start()
    {
        GetNPCInfo();
    }

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogRange, playerLayer);

        if (hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
            DialogueControl.instance.dialogObj.SetActive(false);
        }
    }

    void GetNPCInfo()
    {
        for (int i = 0; i < dialogueSettings.sentences.Count; i++)
        {
            sentences.Add(dialogueSettings.sentences[i].sentence.portuguese);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, dialogRange);
    }
}
