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
        var roomSlots = (NetworkManager.singleton as AmongUsRoomManager).roomSlots;
        foreach (var player in roomSlots)
        {
            var aPlayer = player as AmongUsRoomManager;
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

    public void UpdatePriewColor(EPlayerColor color)
    {
        characterPrivew.material.SetColor("_PlayerColor", PlayerColor.GetColor(color));
    }

    public void OnClickColorButton(int index)
    {
        if(colorSelectButtons[index].isInteratable)
        {
            AmongUsRoomPlayer.MyRoomPlayer.CmdSetPlayerColor((EPlayerColor)index);
            UpdatePriewColor((EPlayerColor)index);
        }
    }
}
