using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySelection : MonoBehaviour
{
    private const float _dist = 0.55f;
    private int _currentSelection = 0;
    private int _newSelection = 0;
    
    private KeyCode[] keyCodes = {
            KeyCode.Alpha1,
            KeyCode.Alpha2,
            KeyCode.Alpha3,
            KeyCode.Alpha4,
            KeyCode.Alpha5,
            KeyCode.Alpha6,
            KeyCode.Alpha7,
            KeyCode.Alpha8,
            KeyCode.Alpha9,
            KeyCode.Alpha0,
        };
    

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                _newSelection = i;
            }
        }

        if (_currentSelection != _newSelection)
        {
            transform.Translate(-(_currentSelection - _newSelection) * _dist, 0, 0);
            _currentSelection = _newSelection;
        }
    }
}
