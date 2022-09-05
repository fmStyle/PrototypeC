using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject dialogueText;
    public float conversationTime;
    public List<string> dialogueLines = new List<string>();
    bool didDialogueStart = false;
    
    int lineIndex;

    void Awake(){
        dialoguePanel.SetActive(false);
        // diGetComponent<TextMeshProUGUI>()
    }
    public void StartDialogue(){
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueText.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }
    /// Returns true when dialogue ends
    public bool NextDialogueLine(){
        lineIndex++;
        if (lineIndex < dialogueLines.Count){
            StartCoroutine(ShowLine());
        } 
        else if (lineIndex == dialogueLines.Count){
            lineIndex = dialogueLines.Count;
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueText.SetActive(false);
            return true;
            // dialogueMark.SetActive(true);
        }
        return false;
    }
    public bool ConversationStarted(){
        return didDialogueStart;
    }
    public bool ConversationFinished(){
        if (lineIndex == dialogueLines.Count) return true;
        return                                        false;
    }

    public bool LineEnded(){
        if (dialogueText.GetComponent<TextMeshProUGUI>().text == dialogueLines[lineIndex]){
            return true;
        } else{
            return false;
        }
    }
    IEnumerator ShowLine(){
        dialogueText.GetComponent<TextMeshProUGUI>().text = "";
        foreach(char ch in dialogueLines[lineIndex]){
            dialogueText.GetComponent<TextMeshProUGUI>().text += ch;
            yield return new WaitForSeconds(conversationTime);
        }
    }
    public void EndLine(){
        StopAllCoroutines();
        dialogueText.GetComponent<TextMeshProUGUI>().text = dialogueLines[lineIndex];
    }
    public bool IsDialogActive(){
        if (dialoguePanel.activeSelf)return true;
        return false;
    }

}
