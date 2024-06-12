using SCI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    private CharacterAvatar characterAvatar;

    void Start()
    {
        characterAvatar = FindObjectOfType<CharacterAvatar>();
        characterAvatar.Initialize();
    }


}
