using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DFollow : MonoBehaviour
{
    public Transform target;
    public float damping = 1;                       //wie "Weich" die Kamera dem Ziel folgt
    public float lookAheadFactor = 3;               //wie weit die Kamera in die Gehrichtung schaut
    public float lookAheadReturnSpeed = 0.5f;       //wie schnell die Kamera beim stehenbleiben wieder auf das Ziel fokusiert
    public float lookAheadMoveThreshold = 0.1f;
    public float yPosRestriction;
    float offsetZ;
    Vector3 lastTargetPosition;
    Vector3 currentVelocity;
    Vector3 lookAheadPos;
    float nextTimeToSearch = 0f;

    // Start is called before the first frame update
    void Start()
    {
        lastTargetPosition = target.position;
        offsetZ = (transform.position - target.position).z;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            FindPlayer();                   //falls das target verloren gegangen sein sollte wird die Funktion FindPlayer() aufgerufen
            return;
        }

        float xMoveDelta = (target.position - lastTargetPosition).x;

        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        if(updateLookAheadTarget)
        {
            lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
        }
        else
        {
            lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

        newPos = new Vector3(newPos.x, Mathf.Clamp (newPos.y, yPosRestriction, Mathf.Infinity), newPos.z);

        transform.position = newPos;
        lastTargetPosition = target.position;
    }
    void FindPlayer()
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchresult = GameObject.FindGameObjectWithTag("Player");
            if (searchresult != null)                             //Falls ein GameObject gefunden wird, wird ein neues Ziel für die Kamera gesetzt
            {
                target = searchresult.transform;                    
            }
            nextTimeToSearch = Time.time + 0.5f;                  //Die Zeit zum Suchen wird erhöht, falls eine erneute Suche notwendig ist
        }
    }
}
