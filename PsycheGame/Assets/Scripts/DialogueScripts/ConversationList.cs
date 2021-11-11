using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A list of an NPCs conversations, in order
[CreateAssetMenu(fileName ="New ConversationList", menuName ="ConversationList")]
public class ConversationList : ScriptableObject
{
    public DialogueSO[] conversations;

}
