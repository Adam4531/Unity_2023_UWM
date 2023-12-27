/*
 * Copyright (c) 2020 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public AudioSource lightningSource;
    public ParticleSystem sparkParticleSystem;
    private ParticleSystem particleSystemComponent;
    private ParticleSystem.EmissionModule emission;
    private ParticleSystem.EmissionModule sparkEmission;
    private Vector3 startPosition;

    [Range(0.1f, 1f)]
    public float intervalMin;

    [Range(2f, 120f)]
    public float intervalMax;

    void Awake()
    {
        startPosition = transform.position;
        particleSystemComponent = GetComponent<ParticleSystem>();
        emission = particleSystemComponent.emission;

        if (sparkParticleSystem != null)
        {
            sparkEmission = sparkParticleSystem.emission;
            sparkEmission.enabled = false;
        }

        emission.enabled = false;
        StartCoroutine(SpawnLightningStrike(Random.Range(intervalMin, intervalMax)));
    }

    private IEnumerator SpawnLightningStrike(float delay)
    {
        yield return new WaitForSeconds(delay);

        var randomPositionOffset = Random.insideUnitCircle * 10f;
        transform.position = new Vector3(transform.position.x + randomPositionOffset.x, transform.position.y + randomPositionOffset.y, transform.position.z);
        emission.enabled = true;

        if (sparkParticleSystem != null)
        {
            sparkEmission.enabled = true;
        }

        if (!lightningSource.isPlaying)
        {
            lightningSource.transform.position = transform.position;
            lightningSource.Play();
        }

        var nextStrikeDelay = Random.Range(intervalMin, intervalMax);
        StartCoroutine(PrepareNextStrike(2f, nextStrikeDelay));
    }

    private IEnumerator PrepareNextStrike(float effectDelay, float nextStrikeDelay)
    {
        yield return new WaitForSeconds(effectDelay);

        emission.enabled = false;

        if (sparkParticleSystem != null)
        {
            sparkEmission.enabled = false;
        }

        transform.position = startPosition;
        StartCoroutine(SpawnLightningStrike(nextStrikeDelay));
    }
}
