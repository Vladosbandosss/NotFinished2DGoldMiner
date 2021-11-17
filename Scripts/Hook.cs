using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
   [SerializeField] private Transform itemHolder;
    private bool itemAttached;

    private HookMovement hookMovement;

    //playerAnim

    private void Awake()
    {
        hookMovement = GetComponent<HookMovement>();
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == TagManager.SMALLGOLD ||
            target.tag == TagManager.MIDLEGOLD ||
            target.tag == TagManager.LARGEGOLD ||
            target.tag == TagManager.LARGESTONE ||
            target.tag == TagManager.MIDDLESTONE)
        {
            itemAttached = true;
            target.transform.parent = itemHolder;
            target.transform.position = itemHolder.position;

            // hookMovement.moveSpeed=target.GetComponent<It>
            //hookMovement.HookAttachedItem();
            if (target.tag == TagManager.SMALLGOLD || target.tag == TagManager.MIDLEGOLD || target.tag == TagManager.LARGEGOLD)
            {

            }
        }//item
    }
















}//
