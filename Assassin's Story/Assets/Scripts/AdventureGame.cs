using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] State startingState;

    State state;
    int flag = 0;

    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        
        var nextStates = state.GetNextStates();

        if (Input.GetKeyDown(KeyCode.S) && flag == 0)
        {
            state = nextStates[0];
            flag = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
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
