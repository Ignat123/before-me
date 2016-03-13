﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System;


public class DiaryControl : MonoBehaviour
{
    public static DiaryControl control;
    public Text textObject;

    private List<string> entries;

    //Player Choices History
    public string gender;
    public string secondLevelChoice;
    public string thirdLevelChoice;

    public const string GENDER_MALE = "male";
    public const string GENDER_FEMALE = "female";
    public const string SECOND_CHOICE_CRISIS = "crisis";
    public const string SECOND_CHOICE_DRUGS = "drugs";
    public const string SECOND_CHOICE_PRIDE = "pride";
    public const string THIRD_CHOICE_FEAR = "fear";
    public const string THIRD_CHOICE_ANGER = "anger";
    public const string THIRD_CHOICE_LONELINESS = "loneliness";


    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
            entries = new List<string>();
            autoFillDiary();
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
        //

    }
        
    void Start()
    {
        textObject = textObject.GetComponent<Text>();
        refreshUIText();
    }


    //todo: think up a better way to chain diary entries
    public void autoFillDiary()
    {
        entries.Clear();
        try
        {
            setFirstLevelChoices();
            setSecondLevelChoices();
            setThirdLevelChoices();
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
        refreshUIText();
    }

    protected void addEntry(string key)
    {
        entries.Add(TextStorage.control.getEntryByKey(key));
    }

    protected void refreshUIText()
    {
        textObject.text = "";
        foreach (string textEntry in entries)
        {
            textObject.text += textEntry;
            textObject.text += "\n\n";
        }
    }

    protected void setFirstLevelChoices()
    {
        if (!System.String.IsNullOrEmpty(this.secondLevelChoice) || !System.String.IsNullOrEmpty(this.thirdLevelChoice))
        {
            this.gender = GENDER_MALE;
        }

        if (!System.String.IsNullOrEmpty(this.gender))
        {
            if (this.gender != GENDER_MALE && this.gender != GENDER_FEMALE)
            {
                throw new Exception("Gender variable in DiaryControl set inproperly.");
            }

            if (this.gender == GENDER_MALE)
            {
                addEntry("#maleGenderMemory");
            }
            else if (this.gender == GENDER_FEMALE)
            {
                addEntry("#femaleGenderMemory");
            }
        }
    }

    //todo: think up a better way to chain complex diary entries, this is looks too badly
    protected void setSecondLevelChoices()
    {
        if (!System.String.IsNullOrEmpty(this.thirdLevelChoice))
        {
            this.gender = SECOND_CHOICE_CRISIS;
        }

        if (!System.String.IsNullOrEmpty(this.secondLevelChoice))
        {

            if (this.gender == GENDER_MALE && this.secondLevelChoice == SECOND_CHOICE_CRISIS)
            {
                addEntry("#maleCrisis");
            }
            else if (this.gender == GENDER_MALE && this.secondLevelChoice == SECOND_CHOICE_DRUGS)
            {
                addEntry("#maleDrugs");
            }
            else if (this.gender == GENDER_MALE && this.secondLevelChoice == SECOND_CHOICE_PRIDE)
            {
                addEntry("#malePride");
            }
            else if (this.gender == GENDER_FEMALE && this.secondLevelChoice == SECOND_CHOICE_CRISIS)
            {
                addEntry("#femaleCrisis");
            }
            else if (this.gender == GENDER_FEMALE && this.secondLevelChoice == SECOND_CHOICE_DRUGS)
            {
                addEntry("#femaleDrugs");
            }
            else if (this.gender == GENDER_FEMALE && this.secondLevelChoice == SECOND_CHOICE_DRUGS)
            {
                addEntry("#femalePride");
            }
            else
            {
                throw new Exception("Gender or secondLevelChoice variable in DiaryControl set inproperly.");
            }
        }
    }

    protected void setThirdLevelChoices()
    {
        if (!System.String.IsNullOrEmpty(this.thirdLevelChoice))
        {
            if (this.gender == GENDER_MALE && this.thirdLevelChoice == THIRD_CHOICE_FEAR)
            {
                addEntry("#maleFear");
            }
            else if (this.gender == GENDER_MALE && this.thirdLevelChoice == THIRD_CHOICE_ANGER)
            {
                addEntry("#maleAnger");
            }
            else if (this.gender == GENDER_MALE && this.thirdLevelChoice == THIRD_CHOICE_LONELINESS)
            {
                addEntry("#maleLoneliness");
            }
            else if (this.gender == GENDER_FEMALE && this.thirdLevelChoice == THIRD_CHOICE_FEAR)
            {
                addEntry("#femaleFear");
            }
            else if (this.gender == GENDER_FEMALE && this.thirdLevelChoice == THIRD_CHOICE_ANGER)
            {
                addEntry("#femaleAnger");
            }
            else if (this.gender == GENDER_FEMALE && this.thirdLevelChoice == THIRD_CHOICE_LONELINESS)
            {
                addEntry("#femaleLoneliness");
            }
            else
            {
                throw new Exception("Gender or thirdLevelChoice variable in DiaryControl set inproperly.");
            }
        }
    }
}