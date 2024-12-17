using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class GetHandsData : MonoBehaviour
{
    public OVRHand rightHand; // Référence à la main droite
    public OVRSkeleton rightSkeleton; // Référence au squelette de la main droite

    private Vector3 oldLinearPosition;
    private Vector3 oldAngularPosition;
    private Vector3 diffLinearPosition;
    private Vector3 diffAngularPosition;
    private Vector3 linearVelocity;
    private Vector3 angularVelocity;
    private StreamWriter sw;

    void Start()
    {
        foreach (var bone in rightSkeleton.Bones)
        {
           oldLinearPosition = bone.Transform.position;
           oldAngularPosition = bone.Transform.eulerAngles;
        }
        sw = new StreamWriter(Application.persistentDataPath + "/monFichier.txt");
    }
    void Update()
    {
        if (rightHand.IsTracked)
        {
            
            Debug.Log("La main gauche est suivie !");

            // Parcourir les os pour afficher leurs positions
            foreach (var bone in rightSkeleton.Bones)
            {
                //Linear velocity calcul
                diffLinearPosition = bone.Transform.position - oldLinearPosition;
                linearVelocity = diffLinearPosition / Time.deltaTime;
                oldLinearPosition = bone.Transform.position;
                
                //Angular position calcul
                diffAngularPosition = bone.Transform.eulerAngles - oldAngularPosition;
                angularVelocity = diffAngularPosition / Time.deltaTime;
                oldAngularPosition = bone.Transform.position;

                float linearMagnitude = linearVelocity.magnitude;

                /*sw.WriteLine($"ID: {bone.Id}, Linear magnitude: {linearMagnitude}, Angular velocity: {angularVelocity}");*/
                Debug.Log($"[Velocity] ID: {bone.Id}, Linear magnitude: {linearMagnitude}, Angular velocity: {angularVelocity}");
            }
        }
        else
        {
            Debug.Log("La main gauche n'est pas suivie.");
        }
       
    }

   /* void OnDrawGizmos()
    {
        if (rightSkeleton != null || Application.isPlaying || rightSkeleton.Bones != null)
        {
            foreach (var bone in rightSkeleton.Bones)
            {
                Gizmos.DrawSphere(bone.Transform.position, 0.001f);
            }
        }
    }*/

    private void OnDestroy()
    {
        sw.Close();
    }
}
