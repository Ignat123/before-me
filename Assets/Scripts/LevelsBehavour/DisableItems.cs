using UnityEngine;
using System.Collections;

public class DisableItems : MonoBehaviour
{

    public PickUpHistoryItem fearItem;
    public PickUpHistoryItem angerItem;
    public PickUpHistoryItem lonelinessItem;

    // Use this for initialization
    void Start()
    {
        if (DiaryControl.control.secondLevelChoice == DiaryControl.SECOND_CHOICE_CRISIS)
        {
            angerItem.isTaken = true;
            lonelinessItem.isTaken = true;
        }
        else if (DiaryControl.control.secondLevelChoice == DiaryControl.SECOND_CHOICE_DRUGS)
        {
            fearItem.isTaken = true;
            lonelinessItem.isTaken = true;
        }
        else if (DiaryControl.control.secondLevelChoice == DiaryControl.SECOND_CHOICE_PRIDE)
        {
            fearItem.isTaken = true;
            angerItem.isTaken = true;
        }
    }
}
