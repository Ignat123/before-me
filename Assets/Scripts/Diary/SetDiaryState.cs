using UnityEngine;
using System.Collections;

public class SetDiaryState : MonoBehaviour {

    public string gender;
    public string secondLevelChoice;

    void Start()
    {
        DiaryControl.control.gender = gender;
        DiaryControl.control.secondLevelChoice = secondLevelChoice;
        DiaryControl.control.autoFillDiary();
    }
}
