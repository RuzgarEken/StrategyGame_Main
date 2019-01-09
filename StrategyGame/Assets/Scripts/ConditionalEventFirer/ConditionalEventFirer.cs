using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalEventFirer : MonoBehaviour
{
    public GameEvent E_AllConditionsOccured;
    public List<EventCondition> conditions;

    public void Reset()
    {
        for(int i = 0; i < conditions.Count; i++)
        {
            conditions[i].occured = false;
        }
    }

    public void OnConditionEventOccured(StringVariable eventCondition)
    {
        for(int i = 0; i < conditions.Count; i++)
        {
            if(conditions[i].eventCondition == eventCondition)
            {
                conditions[i].occured = true;
                CheckAllConditionsOccured();
                return;
            }
        }
    }

    public void CheckAllConditionsOccured()
    {
        for(int i = 0; i < conditions.Count; i++)
        {
            if (!conditions[i].eventCondition)
                return;
        }

        E_AllConditionsOccured.Raise();
    }

}
