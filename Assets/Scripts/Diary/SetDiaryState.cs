using UnityEngine;
using System.Collections;
using System;

public class SetDiaryState : MonoBehaviour {

    public string gender;
    public string secondLevelChoice;

    void Start()
    {
        if (!System.String.IsNullOrEmpty(gender))
        {
            DiaryControl.control.gender = gender;
        }
        if (!System.String.IsNullOrEmpty(secondLevelChoice))
        {   
            DiaryControl.control.secondLevelChoice = secondLevelChoice;
        }
        DiaryControl.control.autoFillDiary();
    }
}
