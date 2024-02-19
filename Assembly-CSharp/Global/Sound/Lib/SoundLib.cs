﻿using System;
using System.Collections.Generic;
using Memoria;
using UnityEngine;
using Object = System.Object;
using MLog = Memoria.Prime.Log;

public class SoundLib : MonoBehaviour
{
	public static void PlayMovieMusic(String movieName, Int32 offsetTimeMSec = 0)
	{
		if (SoundLib.instance == (UnityEngine.Object)null)
		{
		    LogWarning("The instance is null.");
			return;
		}
		if (SoundLib.MusicIsMute)
		{
            return;
		}
		Int32 movieSoundIndex = SoundLib.GetMovieSoundIndex(movieName);
		if (movieSoundIndex != -1)
		{
			SoundLib.MovieAudioPlayer.PlayMusic(movieSoundIndex, offsetTimeMSec, SoundProfileType.MovieAudio);
		}
		else
		{
			SoundLib.LogError(movieName + " not found!");
		}
	}

	public static SoundProfile GetActiveMovieAudioSoundProfile()
	{
		return SoundLib.MovieAudioPlayer.GetActiveSoundProfile();
	}

	public static Int32 GetMovieSoundIndex(String movieName)
	{
		String soundName = String.Empty;
		if (String.Equals(movieName, "FMV000"))
		{
			soundName = "Sounds01/BGM_/music033";
			return SoundMetaData.GetSoundIndex(soundName, SoundProfileType.Music);
		}
		else if (String.Equals(movieName, "FMV059"))
		{
			soundName = "Sounds02/Movie_/FMV059A";
		}
		else if (String.Equals(movieName, "FMV060"))
		{
			String currentLanguage = FF9StateSystem.Settings.CurrentLanguage;
			String str = "FMV059C";
			if (currentLanguage == "Japanese")
			{
				str = "FMV059B";
			}
			soundName = "Sounds02/Movie_/" + str;
		}
		else if (String.Equals(movieName, "mbg102"))
		{
			soundName = "Sounds02/song_/song0504_0";
		}
		else if (String.Equals(movieName, "mbg103"))
		{
			soundName = "Sounds02/song_/song0505_0";
		}
		else if (String.Equals(movieName, "mbg105"))
		{
			soundName = "Sounds02/song_/song0503_0";
		}
		else if (String.Equals(movieName, "mbg106"))
		{
			soundName = "Sounds02/song_/song0507_0";
		}
		else if (String.Equals(movieName, "mbg107"))
		{
			soundName = "Sounds02/song_/song0506_0";
		}
		else if (String.Equals(movieName, "mbg108"))
		{
			soundName = "Sounds02/song_/song0501_0";
		}
		else if (String.Equals(movieName, "mbg110"))
		{
			soundName = "Sounds02/song_/song0502_0";
		}
		else if (String.Equals(movieName, "mbg111"))
		{
			soundName = "Sounds02/song_/song0509_0";
		}
		else if (String.Equals(movieName, "mbg112"))
		{
			soundName = "Sounds02/song_/song0510_0";
		}
		else if (String.Equals(movieName, "mbg113"))
		{
			soundName = "Sounds02/song_/song0508_0";
		}
		else if (String.Equals(movieName, "mbg115"))
		{
			soundName = "Sounds02/song_/song0511_0";
		}
		else if (String.Equals(movieName, "mbg116"))
		{
			soundName = "Sounds02/song_/song1040_0";
		}
		else if (String.Equals(movieName, "mbg117"))
		{
			soundName = "Sounds02/song_/song0512_0";
		}
		else if (String.Equals(movieName, "mbg118"))
		{
			soundName = "Sounds02/song_/song0513_0";
		}
		else
		{
			soundName = "Sounds02/Movie_/" + movieName;
		}
		return SoundMetaData.GetSoundIndex(soundName, SoundProfileType.MovieAudio);
	}

	public static void PauseMovieMusic(String movieName)
	{
		if (SoundLib.instance == (UnityEngine.Object)null)
		{
			return;
		}
		SoundLib.MovieAudioPlayer.PauseMusic();
	}

	public static void StopMovieMusic(String movieName, Boolean isForceStop = false)
	{
		if (SoundLib.instance == (UnityEngine.Object)null)
		{
			return;
		}
		if (!isForceStop)
		{
			if (String.Equals(movieName, "FMV000"))
			{
				SoundLib.Log("Don't stop sound for " + movieName + " if it is NOT forced to stop.");
			}
			else
			{
				SoundLib.MovieAudioPlayer.StopMusic();
			}
		}
		else if (String.Equals(movieName, "FMV000"))
		{
			Int32 ticks = 90;
			Int32 fadeOut = AllSoundDispatchPlayer.ConvertTickToMillisec(ticks);
			SoundLib.MovieAudioPlayer.StopMusic(fadeOut);
		}
		else
		{
			SoundLib.MovieAudioPlayer.StopMusic();
		}
	}

	public static void AddNewSound(String fileName, Int32 soundId, AudioSource source)
	{
		SoundLib.Log("No implementation");
	}

	public static void SeekMovieAudio(String movieName, Single time)
	{
		SoundLib.MovieAudioPlayer.SeekActiveSound((Int32)(time * 1000f));
	}

	public static void SeekMusic(Single time)
	{
		SoundLib.MusicPlayer.SeekActiveSound((Int32)(time * 1000f));
	}

	public static void LoadMovieResources(String basePath, String[] movies)
	{
		SoundLib.Log("No implementation");
	}

	public static void UnloadMovieResources()
	{
		SoundLib.Log("No implementation");
	}

	public static void Log(Object message)
	{
        //MLog.Message("[SoundLib] " + message);
    }

	public static void VALog(Object message)
    {
		if (Configuration.VoiceActing.LogVoiceActing)
			MLog.Message("[VoiceActing] " + message);
	}

	public static void LogError(Object message)
	{
        MLog.Error("[SoundLib] " + message);
    }

	public static void LogWarning(Object message)
	{
	    MLog.Warning("[SoundLib] " + message);
	}

    public static Boolean MusicIsMute { get; private set; }

	public static Boolean SoundEffectIsMute { get; private set; }

	public static void LoadGameSoundEffect(String jsonMetaData)
	{
		try
		{
			SoundLib.SoundEffectPlayer.LoadGameSoundEffect(jsonMetaData);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void LoadSceneSoundEffect(String jsonMetaData)
	{
		try
		{
			SoundLib.SoundEffectPlayer.LoadSceneSoundEffect(jsonMetaData);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void UnloadSoundEffect()
	{
		try
		{
			SoundLib.SoundEffectPlayer.UnloadSoundEffect();
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void UnloadAllSoundEffect()
	{
		try
		{
			SoundLib.SoundEffectPlayer.UnloadAllSoundEffect();
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static Boolean IsSoundEffectPlaying(Int32 soundIndex)
	{
		try
		{
			return SoundLib.SoundEffectPlayer.IsSoundEffectPlaying(soundIndex);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
		return false;
	}

	public static void StopSoundEffect(Int32 soundIndex)
	{
		try
		{
			SoundLib.SoundEffectPlayer.StopSoundEffect(soundIndex);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void StopAllSoundEffects()
	{
		try
		{
			SoundLib.SoundEffectPlayer.StopAllSoundEffects();
			SoundLib.SongPlayer.StopAllSoundEffects();
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void PlaySoundEffect(Int32 soundIndex, Single soundVolume = 1f, Single panning = 0f, Single pitch = 1f)
	{
		try
		{
			Int32 paramType = 0xD000;
			Int32 attr = 0;
			Int32 sndPos = 0;
			Int32 volume = (Int32)(soundVolume * 127);
			FF9Snd.ParameterChanger(ref paramType, ref soundIndex, ref attr, ref sndPos, ref volume);
			SoundLib.SoundEffectPlayer.PlaySoundEffect(soundIndex, soundVolume, panning, pitch);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static Int32 GetResidentSfxSoundCount()
	{
		return SoundMetaData.ResidentSfxSoundIndex[0].Count;
	}

	public static void LoadAllResidentSfxSoundData()
	{
		try
		{
			SoundLib.SfxSoundPlayer.LoadAllResidentSoundData();
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void UnloadAllResidentSfxSoundData()
	{
		try
		{
			SoundLib.SfxSoundPlayer.UnloadAllResidentSoundData();
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void LoadSfxSoundData(Int32 specialEffectID)
	{
		try
		{
			SoundLib.SfxSoundPlayer.LoadSoundData(specialEffectID);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static SoundProfile PlaySfxSound(Int32 soundIndexInSpecialEffect, Single soundVolume = 1f, Single panning = 0f, Single pitch = 1f)
	{
		SoundProfile result;
		try
		{
			result = SoundLib.SfxSoundPlayer.PlaySfxSound(soundIndexInSpecialEffect, soundVolume, panning, pitch);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
			result = (SoundProfile)null;
		}
		return result;
	}

	public static Boolean IsSfxSoundPlaying(Int32 soundIndexInSpecialEffect)
	{
		Boolean result;
		try
		{
			result = SoundLib.SfxSoundPlayer.IsPlaying(soundIndexInSpecialEffect);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
			result = false;
		}
		return result;
	}

	public static void StopSfxSound(Int32 soundIndexInSpecialEffect)
	{
		try
		{
			SoundLib.SfxSoundPlayer.StopSound(soundIndexInSpecialEffect);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void StopAllSfxSound()
	{
		try
		{
			SoundLib.SfxSoundPlayer.StopAllSounds();
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void PlaySong(Int32 soundIndex)
	{
		try
		{
			SoundLib.SongPlayer.PlaySong(soundIndex, 1f, 0f, 1f);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void StopSong(Int32 soundIndex)
	{
		try
		{
			SoundLib.SongPlayer.StopSong(soundIndex);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void StopAllSongs()
	{
		try
		{
			SoundLib.SongPlayer.StopAllSongs();
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void PlaySong(Int32 soundIndex, Single soundVolume, Single panning, Single pitch)
	{
		try
		{
			SoundLib.SongPlayer.PlaySong(soundIndex, soundVolume, panning, pitch);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void LazyLoadSoundResources()
	{
		try
		{
			if (!SoundLib.hasLoadedSoundResources)
			{
				SoundMetaData.LoadMetaData();
				FF9SndMetaData.LoadBattleEncountBgmMetaData();
				SoundLib.LoadAllResidentSfxSoundData();
				SoundLib.hasLoadedSoundResources = true;
			}
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void LoadMusic(String jsonMetaData)
	{
		try
		{
			SoundLib.MusicPlayer.LoadMusic(jsonMetaData);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void UnloadMusic()
	{
		try
		{
			SoundLib.MusicPlayer.UnloadMusic();
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void LoadMovieAudio(String jsonMetaData)
	{
		try
		{
			SoundLib.MovieAudioPlayer.LoadMusic(jsonMetaData);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void UnloadMovieAudio()
	{
		try
		{
			SoundLib.MovieAudioPlayer.UnloadMusic();
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void PlayMusic(Int32 soundIndex)
	{
		try
		{
			SoundLib.MusicPlayer.PlayMusic(soundIndex);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void SetNextLoopRegion(Int32 soundIndex)
	{
		try
		{
			SoundLib.MusicPlayer.NextLoopRegion(soundIndex);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void PlayMusic(Int32 soundIndex, Int32 fadeIn)
	{
		try
		{
			SoundLib.MusicPlayer.PlayMusic(soundIndex, fadeIn, SoundProfileType.Music);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void PauseMusic()
	{
		try
		{
			SoundLib.MusicPlayer.PauseMusic();
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

    public static void ResumeMusic()
    {
        try
        {
            SoundLib.MusicPlayer.ResumeMusic();
        }
        catch (Exception message)
        {
            SoundLib.LogError(message);
        }
    }

    public static Int32 GetActiveMusicSoundID()
	{
		try
		{
			return SoundLib.MusicPlayer.GetActiveSoundID();
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
		return -1;
	}

	public static void StopMusic()
	{
		try
		{
			SoundLib.MusicPlayer.StopMusic();
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void StopMusic(Int32 fadeOut)
	{
		try
		{
			SoundLib.MusicPlayer.StopMusic(fadeOut);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void SetMusicVolume(Single volume)
	{
		try
		{
			SoundLib.MusicPlayer.SetMusicVolume(volume);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void SetMusicPanning(Single panning)
	{
		try
		{
			SoundLib.MusicPlayer.SetMusicPanning(panning);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void SetMusicPitch(Single pitch)
	{
		try
		{
			SoundLib.MusicPlayer.SetMusicPitch(pitch);
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void TryUpdateMusicVolume()
	{
		if (FF9StateSystem.Settings.cfg.IsMusicEnabled)
			EnableMusic();
	}

	public static void EnableMusic()
	{
		try
		{
			SoundLib.AllSoundDispatchPlayer.UpdatePlayingMusicVolume();
			SoundLib.MusicPlayer.UpdateVolume();
			SoundLib.MovieAudioPlayer.UpdateVolume();
			SoundLib.MusicIsMute = false;
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void DisableMusic()
	{
		try
		{
			SoundLib.AllSoundDispatchPlayer.UpdatePlayingMusicVolume();
			SoundLib.MusicPlayer.UpdateVolume();
			SoundLib.MovieAudioPlayer.UpdateVolume();
			SoundLib.MusicIsMute = true;
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}
	
		
	public static void TryUpdateSoundVolume()
	{
		if (FF9StateSystem.Settings.cfg.IsSoundEnabled)
			EnableSoundEffect();
	}

	public static void EnableSoundEffect()
	{
		try
		{
			SoundLib.AllSoundDispatchPlayer.UpdatePlayingSoundEffectVolume();
			SoundLib.SfxSoundPlayer.UpdateVolume();
			SoundLib.SoundEffectPlayer.UpdateVolume();
			SoundLib.SongPlayer.UpdateVolume();
			SoundLib.SoundEffectIsMute = false;
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static void DisableSoundEffect()
	{
		try
		{
			SoundLib.AllSoundDispatchPlayer.UpdatePlayingSoundEffectVolume();
			SoundLib.SfxSoundPlayer.UpdateVolume();
			SoundLib.SoundEffectPlayer.UpdateVolume();
			SoundLib.SongPlayer.UpdateVolume();
			SoundLib.SoundEffectIsMute = true;
		}
		catch (Exception message)
		{
			SoundLib.LogError(message);
		}
	}

	public static AllSoundDispatchPlayer GetAllSoundDispatchPlayer()
	{
		return SoundLib.AllSoundDispatchPlayer;
	}

	public static void UpdatePlayingSoundEffectPitchByGameSpeed()
	{
		SoundLib.AllSoundDispatchPlayer.UpdatePlayingSoundEffectPitchFollowingGameSpeed();
	}

	public static void StopAllSounds(Boolean isAll = true)
	{
		try
		{
			SoundLib.MusicPlayer.StopMusic();
			SoundLib.SoundEffectPlayer.StopAllSoundEffects();
			SoundLib.SongPlayer.StopAllSoundEffects();
			SoundLib.MovieAudioPlayer.StopMusic();
			if (isAll)
			{
				SoundLib.AllSoundDispatchPlayer.StopAllSounds();
			}
			else
			{
				SoundLib.AllSoundDispatchPlayer.PauseAllSounds();
			}
			SoundLib.SfxSoundPlayer.StopAllSounds();
		}
		catch (Exception message)
		{
			SoundLib.LogWarning(message);
		}
	}

	public static void ClearSuspendedSounds()
	{
		SoundLib.AllSoundDispatchPlayer.ClearSuspendedSounds();
	}

	public static void SuspendSoundSystem()
	{
		if (!SoundLib.isSuspendAllSounds)
		{
			SoundLib.MovieAudioPlayer.PauseMusic();
			SoundLib.AllSoundDispatchPlayer.PauseAllSounds();
			SoundLib.SfxSoundPlayer.PauseAllSounds();
			SoundLib.VoicePlayer.PauseAllSounds();
			SoundLib.isSuspendAllSounds = true;
		}
	}

	public static void ResumeSoundSystem()
	{
		if (SoundLib.isSuspendAllSounds)
		{
			SoundLib.MovieAudioPlayer.ResumeMusic();
			SoundLib.AllSoundDispatchPlayer.ResumeAllSounds();
			SoundLib.SfxSoundPlayer.ResumeAllSounds();
			SoundLib.VoicePlayer.ResumeAllSounds();
			SoundLib.isSuspendAllSounds = false;
		}
	}

	private void Awake()
	{
		this.InitializePlugin();
		this.InitializeSoundPlayer();
		SoundLib.instance = this;
	}

	private void Update()
	{
		if (this.soundPlayerList != null)
		{
			foreach (SoundPlayer soundPlayer in this.soundPlayerList)
			{
				soundPlayer.Update();
			}
		}
		this.UpdatePauseState();
	}

	private void UpdatePauseState()
	{
		Boolean flag = PersistenSingleton<UIManager>.Instance.IsPause || UIManager.Field.isShowSkipMovieDialog;
		if (flag != PersistenSingleton<UIManager>.Instance.IsPause || (UIManager.Field != (UnityEngine.Object)null && UIManager.Field.isShowSkipMovieDialog))
		{
			flag = (PersistenSingleton<UIManager>.Instance.IsPause || UIManager.Field.isShowSkipMovieDialog);
		}
		if (flag != this.isPauseLastFrame)
		{
			if (flag)
			{
				SoundLib.SuspendSoundSystem();
			}
			else
			{
				SoundLib.ResumeSoundSystem();
			}
		}
		this.isPauseLastFrame = flag;
	}

	private void OnDestroy()
	{
		this.FinalizePlugin();
	}

	private void OnApplicationPause(Boolean pause)
	{
		if (pause)
		{
			ISdLibAPIProxy.Instance.SdSoundSystem_Suspend();
		}
		else
		{
			ISdLibAPIProxy.Instance.SdSoundSystem_Resume();
		}
	}

	private void OnQuit()
	{
		this.FinalizePlugin();
	}

	private Boolean InitializePlugin()
	{
		if (this.m_isInitialized)
		{
			return true;
		}
		SoundLib.Log("InitializePlugin()");
		Int32 num = ISdLibAPIProxy.Instance.SdSoundSystem_Create(String.Empty);
		if (num < 0)
		{
			return false;
		}
		this.m_isInitialized = true;
		GameObject gameObject = new GameObject("SoundLibWndProc");
		SoundLibWndProc soundLibWndProc = gameObject.AddComponent<SoundLibWndProc>();
		gameObject.transform.parent = base.transform;
		return true;
	}

	private void FinalizePlugin()
	{
		if (!this.m_isInitialized)
		{
			return;
		}
		SoundLib.Log("FinalizePlugin()");
		ISdLibAPIProxy.Instance.SdSoundSystem_Release();
		this.m_isInitialized = false;
	}

	private void InitializeSoundPlayer()
	{
		SoundLib.SoundEffectPlayer = new SoundEffectPlayer();
		SoundLib.MusicPlayer = new MusicPlayer();
		SoundLib.MovieAudioPlayer = new MovieAudioPlayer();
		SoundLib.SongPlayer = new SongPlayer();
		SoundLib.AllSoundDispatchPlayer = new AllSoundDispatchPlayer();
		SoundLib.SfxSoundPlayer = new SfxSoundPlayer();
		SoundLib.VoicePlayer = new VoicePlayer();
		this.soundPlayerList = new List<SoundPlayer>();
		this.soundPlayerList.Add(SoundLib.SoundEffectPlayer);
		this.soundPlayerList.Add(SoundLib.MusicPlayer);
		this.soundPlayerList.Add(SoundLib.MovieAudioPlayer);
		this.soundPlayerList.Add(SoundLib.SongPlayer);
		this.soundPlayerList.Add(SoundLib.AllSoundDispatchPlayer);
		this.soundPlayerList.Add(SoundLib.SfxSoundPlayer);
		this.soundPlayerList.Add(SoundLib.VoicePlayer);
	}

	private Boolean m_isInitialized;

	public static SoundEffectPlayer SoundEffectPlayer { get; private set; }
	
	public static VoicePlayer VoicePlayer { get; private set; }

	public static MusicPlayer MusicPlayer { get; private set; }

	public static MovieAudioPlayer MovieAudioPlayer { get; private set; }

	public static SongPlayer SongPlayer { get; private set; }

	public static AllSoundDispatchPlayer AllSoundDispatchPlayer { get; private set; }

	public static SfxSoundPlayer SfxSoundPlayer { get; private set; }

	private List<SoundPlayer> soundPlayerList;

	private static SoundLib instance;

	private static Boolean hasLoadedSoundResources;

	private static Boolean isSuspendAllSounds;

	private Boolean isPauseLastFrame;
}
