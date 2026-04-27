using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // This converts the screen co-ordinates to world co-ordinates and stores this in screenbounds
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y;
        //get the positions of the object width and height.
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;

        //This section fo code uses 2 clamp functions in order to lock a character into the constraints of the screen.
        //Last line assigns the clamped co-ordinates back to the object
    }
}
