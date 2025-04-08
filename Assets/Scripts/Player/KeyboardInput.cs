using UnityEngine;

public class KeyboardInput : IPlayerInput
{
    public int GetHorizontalInput()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)) return -1;
        if(Input.GetKeyDown(KeyCode.RightArrow)) return 1;
        return 0;
    }
}
