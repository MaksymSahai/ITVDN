using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePokemonHelper : MonoBehaviour
{
    public PokemonModel MyPokemonModel { get; set; }

    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }
    public string Name { get; set; }

    public bool IsDead { get; set; }

    public void Load(PokemonModel myPokemonModel)
    {
        MyPokemonModel = myPokemonModel;

        MaxHealth = MyPokemonModel.Health;
        Health = MyPokemonModel.Health;
        Level = MyPokemonModel.Exp;
        Name = myPokemonModel.PokemonType.ToString();
    }

    internal void TakeDamage(int damage)
    {
        int health = Health - damage;

        if (health <= 0)
        {
            Health = 0;
            IsDead = true;
        }

        Health = health;
    }
}
