using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSpirit : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem spiritFastCloud;
    public ParticleSystem spiritLineTrail;
    private int nMoveWaitTime = 6;

    void Start()
    {
        //StartCoroutine(MoveSpirit());
        spiritFastCloud.GetComponent<Animator>();
    }

    IEnumerator MoveSpirit()
    {
        yield return new WaitForSeconds(nMoveWaitTime);

        yield return new WaitForSeconds(nMoveWaitTime);

        yield return new WaitForSeconds(nMoveWaitTime);

        yield return new WaitForSeconds(nMoveWaitTime);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
