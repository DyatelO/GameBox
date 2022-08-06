using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/AnimationSet", fileName = "AnimationData")]
public class MovementAnimantionSettings : ScriptableObject
{
    [SerializeField] private List<AnimationClip> animationClips;

    public List<AnimationClip> AnimationClips;
}
