using UnityEngine;

public class KeyboardInput : IPlayerInput
{
    /// <summary>
    /// Returns the horizontal input based on the arrow keys
    /// </summary>
    /// <returns> The horizontal input </returns>
    public int GetHorizontalInput()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) return -1;
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) return 1;
        return 0;
    }
}
