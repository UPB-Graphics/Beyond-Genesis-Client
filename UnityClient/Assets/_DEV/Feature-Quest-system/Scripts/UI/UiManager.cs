using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public GameObject questListParent;
    public GameObject questPrefab;
    public List<GameObject> addedQuests = new List<GameObject>();

    void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }
        instance = this;
    }

    public void AddQuest(Quest quest)
    {
        GameObject temp = Instantiate(questPrefab);
        temp.transform.SetParent(questListParent.transform);
        temp.transform.localScale = new Vector3(1, 1, 1);
        temp.GetComponent<QuestPrefabHelper>().quest = quest;
    }
}
