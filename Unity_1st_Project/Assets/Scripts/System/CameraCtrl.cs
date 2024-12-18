using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float edgeThreshold = 30f;

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        float screenWidth = Screen.width;

        if (mousePosition.x < edgeThreshold)
        {
            transform.position +=Vector3.left*moveSpeed*Time.deltaTime;
            if (transform.position.x < -8.4f)
            {
                transform.position = new Vector3(-8.4f, 0, -1);
            }
        }

        else if (mousePosition.x > screenWidth-edgeThreshold)
        {
            transform.position +=Vector3.right*moveSpeed*Time.deltaTime;
            if (transform.position.x > 8.4f)
            {
                transform.position = new Vector3(8.4f, 0, -1);
            }
        }
    }
}
