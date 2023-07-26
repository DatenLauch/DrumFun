using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MidiInputScript : MonoBehaviour
{
    [SerializeField] GameObject barManager;
    [SerializeField] LeftHitscanScript HitscanScript1;
    [SerializeField] HitscanScript HitscanScript2;
    [SerializeField] RightHitscanScript HitscanScript3;
    //int keyOffset;

    // Start is called before the first frame update
    void Start()
    {
        /* midi note number of lowest key in midi device    
        offset of 36 is used because this drum's lowest possible note starts at 36 (bass pedal with C2)
        keyOffset = 36; */

        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;
            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            midiDevice.onWillNoteOn += (note, velocity) =>
            {
                /*Debug.Log(string.Format(
                    "Note On #{0} ({1}) vel:{2:0.00} ch:{3} dev:'{4}'",
                    note.noteNumber,
                    note.noteNumber.GetType(),
                    note.shortDisplayName,
                    velocity,
                    velocity.GetType(),
                    (note.device as Minis.MidiDevice)?.channel,
                    note.device.description.product
                )); */

                if (note.shortDisplayName.Equals("D2"))
                {
                    HitscanScript1.playerHitsDrum();
                }
                if (note.shortDisplayName.Equals("C2"))
                {
                    HitscanScript2.playerHitsDrum();
                }
                if (note.shortDisplayName.Equals("G2"))
                {
                    HitscanScript3.playerHitsDrum();
                }
            };

            midiDevice.onWillNoteOff += (note) =>
            {
                /* Debug.Log(string.Format(
                    "Note Off #{0} ({1}) ch:{2} dev:'{3}'",
                    note.noteNumber,
                    note.shortDisplayName,
                    (note.device as Minis.MidiDevice)?.channel,
                    note.device.description.product
                )); */
            };
        };
    }
}