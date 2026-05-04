using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;

public class VoiceController : MonoBehaviour
{
    private KeywordRecognizer recognizer;
    private Dictionary<string, System.Action> actions;

    [SerializeField] private PlaneController plane;
    [SerializeField] private MeshSlicer slicer;
    [SerializeField] private UIStatus ui;

    void Start()
    {
        actions = new Dictionary<string, System.Action>();

        actions.Add("up", () => {
            plane.MoveUp();
            ui.SetStatus("Plane moved up");
        });

        actions.Add("down", () => {
            plane.MoveDown();
            ui.SetStatus("Plane moved down");
        });

        actions.Add("cut", () => {
            slicer.Slice();
            ui.SetStatus("Cut executed");
        });

        actions.Add("remove proximal", () => {
            slicer.RemoveProximal();
            ui.SetStatus("Proximal removed");
        });

        actions.Add("remove distal", () => {
            slicer.RemoveDistal();
            ui.SetStatus("Distal removed");
        });

        recognizer = new KeywordRecognizer(new List<string>(actions.Keys).ToArray());

        recognizer.OnPhraseRecognized += (args) =>
        {
            string cmd = args.text.ToLower();
            Debug.Log("🎤 " + cmd);

            if (actions.ContainsKey(cmd))
                actions[cmd].Invoke();
            else
                ui.SetStatus("Unknown command");
        };

        recognizer.Start();
        ui.SetStatus("Listening...");
    }

    void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.Stop();
            recognizer.Dispose();
        }
    }
}