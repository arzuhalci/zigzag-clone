using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    Vector3 dir;
    public bool mouseClicked;

    // Start is called before the first frame update
    void Start()
    {
        dir = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            mouseClicked = true;
            if (dir == Vector3.forward)
            {
                dir = Vector3.left;
            }
            else
            {
                dir = Vector3.forward;
            }

        }
        float amountToMove = speed * Time.deltaTime;

        transform.Translate(dir * amountToMove);
        
        


    }

    public IEnumerator waitFrameEnd()
    {
        Debug.Log("frame sonuna beklendi");
        yield return new WaitForEndOfFrame();
    }

}
