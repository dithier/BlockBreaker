﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip breakBlock;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    

    // cached reference
    Level level;
    GameStatus gameStatus;

    // state variables
    [SerializeField] int timesHit; // TODO only serialized for debug purposes

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
        else
        {
            PlayBlockDestroySFX();
        }
        
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array for " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        TriggerSparklesVFX();
        gameStatus.AddToScore();
        Destroy(gameObject);
        level.BlockDestroyed();
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakBlock, Camera.main.transform.position);

    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
        
    }
}
