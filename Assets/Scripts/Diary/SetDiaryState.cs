using UnityEngine;
using System.Collections;
using System;

public class SetDiaryState : MonoBehaviour {

    public string gender;
    public string secondLevelChoice;
    public string thirdLevelChoice;

    protected bool stateChanged;

    void Start()
    {
        stateChanged = false;
        if (DiaryControl.control.gender != gender ||
            DiaryControl.control.secondLevelChoice != secondLevelChoice ||
            DiaryControl.control.thirdLevelChoice != thirdLevelChoice)
        {
            stateChanged = true;
        }

        if (!System.String.IsNullOrEmpty(gender))
        {
            DiaryControl.control.gender = gender;
        }
        if (!System.String.IsNullOrEmpty(secondLevelChoice))
        {   
            DiaryControl.control.secondLevelChoice = secondLevelChoice;
        }
        if (!System.String.IsNullOrEmpty(thirdLevelChoice))
        {   
            DiaryControl.control.thirdLevelChoice = thirdLevelChoice;
        }
        DiaryControl.control.autoFillDiary();

        if (stateChanged)
        {
            GameObject.Find("Diary").GetComponent<Animator>().SetBool("NewEntry", true);
        }
    }
}
