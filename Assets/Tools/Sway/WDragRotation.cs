using UnityEngine;
using System.Collections;
using Player;

public class WDragRotation : MonoBehaviour 
{
    //common settings -> (d, dT, s) 
    //  -> Camera lags (-2.5f, -5f, 5)
    //  -> Weapon lags (2.5f, 5f, 5)

    //Heirarchy
    //  Player
    //      Camera
    //          GunParent  -> attach here if gun animated <-
    //              Gun

    [SerializeField] 
    private Rigidbody body;
    [SerializeField] 
    private ToolChanger changer;

    [Range(0, 1f)]
    [SerializeField]
    float verticalSwayAmount = 0.5f;

    [Range(0, 1f)]
    [SerializeField]
    float horiztonalSwayAmount = 1f;

    [Range(0, 15f)]
    [SerializeField]
    float swaySpeed = 4f;

    // Update is called once per frame
    void Update () 
    {

        if (body.velocity.magnitude > 1)
        {
            swaySpeed = 5;
        }
        else
        {
            swaySpeed = 1;
        }
        
        float x = 0, y = 0;
        y += verticalSwayAmount * Mathf.Sin((swaySpeed * 2) * Time.time);
        x += horiztonalSwayAmount * Mathf.Sin(swaySpeed * Time.time);

        Transform weapon = transform.GetChild(changer.activeToolIndex);
        weapon.localPosition = new Vector3(x, y, weapon.localPosition.z);
    }
}