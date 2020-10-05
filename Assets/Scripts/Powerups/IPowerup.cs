using System.Collections.Generic;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/


namespace CarterGames.LostMyMarbles
{
    public interface IPowerup
    {
        void UseAbility(Rigidbody rb);
    }
}
