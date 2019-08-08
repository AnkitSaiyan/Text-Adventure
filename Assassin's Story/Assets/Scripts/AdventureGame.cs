using System.Collections;
using System.Collections.Generic;
using UnityEngine;  // To use class MonoBehavior Functionalities
using TMPro;    // To use TextMeshPro field

public class AdventureGame : MonoBehaviour
{
    // SerializeFiled used to make it appear in Inspector
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] State startingState;
    
    // state is an object of class State
    State state;
    int flag = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        state = startingState;
        // GetStateStory function called which returns Story text of the current state and
        // put it in the Text field of Story Text element of Canvas
        textComponent.text = state.GetStateStory();
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        //Copying the whole array of nextstates into nextStates
        var nextStates = state.GetNextStates();

        if (Input.GetKeyDown(KeyCode.S) && flag == 0)
        {
            state = nextStates[0];
            flag = 1;
        }
        /*else if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
        {
            
        }*/
        // Getting Key using for loop
        else if(flag != 0)
        {
            for (int i = 0; i < nextStates.Length; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    state = nextStates[i];
                }
            }
        }
        
        textComponent.text = state.GetStateStory();
    }
}
