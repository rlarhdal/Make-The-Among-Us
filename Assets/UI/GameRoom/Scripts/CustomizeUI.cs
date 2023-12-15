using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class CustomizeUI : MonoBehaviour
{
    [SerializeField]
    private Image characterPrivew;

    [SerializeField]
    private List<ColorSelectButton> colorSelectButtons;  

    // Start is called before the first frame update
    void Start()
    {
        var inst = Instantiate(characterPrivew.material);
        characterPrivew.material = inst;
    }

    private void OnEnable()
    {
        UpadateColorButton();
        
        var roomSlots = (NetworkManager.singleton as AmongUsRoomManager).roomSlots;
        foreach (var player in roomSlots)
        {
            var aPlayer = player as AmongUsRoomPlayer;
            if(aPlayer.isLocalPlayer)
            {
                UpdatePriewColor(aPlayer.playerColor);
                break;
            }
        }
    }

    public void UpadateColorButton()
    {
        var roomSlots = (NetworkManager.singleton as AmongUsRoomManager).roomSlots;

        for(int i = 0; i < colorSelectButtons.Count; i++)
        {
            colorSelectButtons[i].SetInteractable(true);
        }

        foreach(var player in roomSlots)
        {
            var aPlayer = player as AmongUsRoomPlayer;
            colorSelectButtons[(int)aPlayer.playerColor].SetInteractable(false);
        }
    }

    public void UpdateSelectColorButton(EPlayerColor color)
    {
        colorSelectButtons[(int)color].SetInteractable(false);
    }

    public void UpdateUnSelectColorButton(EPlayerColor color)
    {
        colorSelectButtons[(int)color].SetInteractable(true);
    }

    public void UpdatePriewColor(EPlayerColor color)
    {
        characterPrivew.material.SetColor("_PlayerColor", PlayerColor.GetColor(color));
    }

    public void OnClickColorButton(int index)
    {
        if(colorSelectButtons[index].isInteractable)
        {
            AmongUsRoomPlayer.MyRoomPlayer.CmdSetPlayerColor((EPlayerColor)index);
            UpdatePriewColor((EPlayerColor)index);
        }
    }

    public void Open()
    {
        AmongUsRoomPlayer.MyRoomPlayer.lobbyPlayerCharacter.IsMoveable = false;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        AmongUsRoomPlayer.MyRoomPlayer.lobbyPlayerCharacter.IsMoveable = true;
        gameObject.SetActive(false);
    }
}
