using UnityEngine.Audio;
using UnityEngine;
using System;

public class GameSounds : MonoBehaviour
{
   
    public AudioClip clip;

    public AudioSource background_trainingcamp;
    public AudioSource keypick;
    public AudioSource doors_open;
    public AudioSource doors_open2;
    public AudioSource health;
    public AudioSource score;
    public AudioSource padlock_access;
    public AudioSource padlock_deined_not;
    public AudioSource coin;

    public AudioSource gameWin;
    public AudioSource gameLose;
    public AudioSource playerRip;
    
    public AudioSource use_pistol;
    public AudioSource use_riffle;
    public AudioSource use_ak47;
    public AudioSource use_awp;
    public AudioSource reload;
    public AudioSource gunpick;

    public AudioSource buttonSelect;
    public AudioSource buttonPress;

    public AudioSource jump;
    public AudioSource player_stone_walk;


    public void BG_Sound() => background_trainingcamp.Play();
    public void BG_SoundStop() => background_trainingcamp.Stop();
    public void KeySound() => keypick.Play();
    public void DoorsSound() => doors_open.Play();
    public void DoorsSound2() => doors_open2.Play();
    public void HealthSound() => health.Play();
    public void ScoreSound() => score.Play();
    public void padlock_granted() => padlock_access.Play();
    public void padlock_deined() => padlock_deined_not.Play();
    public void CoinSound() => coin.Play();
    public void Win() => gameWin.Play();
    public void Lose() => gameLose.Play();
    public void Death() => playerRip.Play();
  
    public void Pistol() => use_pistol.Play();

    public void Riffle() => use_riffle.Play();
    public void AK47() => use_ak47.Play();
    public void AWP() => use_awp.Play();
    public void ReloadWeapon() => reload.Play();
    public void GunPick() => gunpick.Play();
    public void ButtonSelected() => buttonSelect.Play();
    public void ButtonPress() => buttonPress.Play();


    public void PlayerJump() => jump.Play();

    public void PlayerStoneWalk() => player_stone_walk.Play();
    
}