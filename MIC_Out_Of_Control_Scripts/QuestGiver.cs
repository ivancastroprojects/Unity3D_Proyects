using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public static Quest[] quests;
    public static QuestGiver instance;

    private void Awake()
    {
        if (instance == null && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MENU"))
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
            Destroy(gameObject);
    }
    public void Start()
    {
        //GameManager.manager.questWindow.SetActive(false);

        quests = new Quest[7];
        for (int i = 0; i < quests.Length; i++)
        {
            quests[i] = new Quest();
            quests[i].goal = new QuestGoal();
        }
        chainQuests();  
    }

    public void chainQuests()
    {
        quests[0].npc = "Note 1";
        quests[0].title = "Note 1 of Main Scientist";
        quests[0].description = "Find the Research Laboratory.";
        quests[0].goal.goalType = QuestGoal.GoalType.Find;

        quests[0].activateAdds = false;
        quests[0].activateChronometer = false;
        quests[0].activateSyringe = false;


        quests[1].npc = "Note 2";
        quests[1].title = "Note 2 of Main Scientist";
        quests[1].description = "Talk with fourth patient.";
        quests[1].goal.goalType = QuestGoal.GoalType.Find;

        quests[1].activateAdds = false;
        quests[1].activateChronometer = false;
        quests[1].activateSyringe = false;


        quests[2].npc = "fourthpatient";
        quests[2].title =  "Horror in build MIC";
        quests[2].description = "Find the scientists. Follow the trail of blood.";
        quests[2].goal.goalType = QuestGoal.GoalType.Find;

        quests[2].activateAdds = true;
        quests[2].activateChronometer = false;
        quests[2].activateSyringe = false;


        quests[3].npc = "guardscientist";
        quests[3].title = "Without light and without defenses";
        quests[3].description = "";
        quests[3].descriptionExtra1 = "0/1   Activates the electrical current of the MIC";
        quests[3].descriptionExtra2 = "0/1   Get the vaccine from the lab";
        quests[3].goal.goalType = QuestGoal.GoalType.Gathering;
        quests[3].goal.requiredAmount = 2;

        quests[3].activateAdds = true;
        quests[3].activateChronometer = true;
        quests[3].activateSyringe = false;


        quests[4].npc = "guardscientist";
        quests[4].title = "End the mutation";
        quests[4].description = "";
        quests[4].descriptionExtra1 = "0/10   Mutants healed";
        quests[4].descriptionExtra2 = "0/1   Fifth patient healed";
        quests[4].goal.goalType = QuestGoal.GoalType.Kill;
        quests[4].goal.requiredAmount = 11;

        quests[4].activateAdds = true;
        quests[4].activateChronometer = false;
        quests[4].activateSyringe = true;


        quests[5].npc = "mainscientist";
        quests[5].title = "Hero without cap";
        quests[5].description = "Talk to the Guard Scientist and the Director";
        quests[5].goal.goalType = QuestGoal.GoalType.Find;

        quests[5].activateAdds = false;
        quests[5].activateChronometer = false;
        quests[5].activateSyringe = false;

        quests[6].npc = "director";
        quests[6].title = "End of game";
        quests[6].description = "¡Congratulations!";
    }

    public void AcceptQuest(GameObject NPC)
    {

        if (!quests[0].complete && quests[0].npc == NPC.name)
        {
            InsertIndexMision(0);
        }
        else if(quests[3].complete && quests[4].npc == NPC.name)
        {
            InsertIndexMision(4);
        }
        else
        {
            for (int i = 1; i < quests.Length; i++)
            {

                if ((quests[i - 1].complete) && (quests[i].npc == NPC.name))
                {
                    InsertIndexMision(i);
                    return;
                }
            } 
        }
    }
    public void InsertIndexMision(int index)
    {
        GameManager.manager.active = false;
        GameManager.manager.questWindow.SetActive(true);
        GameManager.manager.titleBox.text = "" + quests[index].title;

        if (quests[index] == quests[3] || quests[index] == quests[4])
        {
            GameManager.manager.descriptionBox.text = "";
            GameManager.manager.descriptionBoxExtra1.text = "" + quests[index].descriptionExtra1;
            GameManager.manager.descriptionBoxExtra2.text = "" + quests[index].descriptionExtra2;
        } else
        {
            GameManager.manager.descriptionBoxExtra1.text = "";
            GameManager.manager.descriptionBoxExtra2.text = "";
            GameManager.manager.descriptionBox.text = "" + quests[index].description;
        }

        quests[index].isActive = true;
        GameManager.manager.quest = quests[index];
    }
}
