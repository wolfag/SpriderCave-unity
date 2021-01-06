using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private Player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(gameObject.name=="Left Button")
        {
            player.SetMoveLeft(true);
        }else
        {
            player.SetMoveLeft(false);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.StopMoving();
    }
}
