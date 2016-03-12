using UnityEngine;
using System.Collections;
using System;

public class SetDiaryState : MonoBehaviour {

    public string gender;
    public string secondLevelChoice;
    public string thirdLevelChoice;

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
        if (!System.String.IsNullOrEmpty(thirdLevelChoice))
        {   
            DiaryControl.control.thirdLevelChoice = thirdLevelChoice;
        }
        DiaryControl.control.autoFillDiary();
    }
}
