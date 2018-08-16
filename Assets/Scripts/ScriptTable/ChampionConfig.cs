using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChampionConfig", menuName = "GameConfiguration/ChampionConfig", order = 1)]
public class ChampionConfig : ScriptableObject {

    public float Healt;
    public float Mana;

    public float speed;
}
