using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace App.UI.Screens.PlayerInfo
{
    public class PlayerInfoModel
    {
        public string[] Strings { get; }

        public PlayerInfoModel(params string[] strings)
        {
            Strings = strings;
        }
    }
}