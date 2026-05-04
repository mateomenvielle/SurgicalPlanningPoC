# Voice-Controlled 3D Surgical Planning PoC (Unity)

## Overview
This project is a Proof of Concept for a voice-controlled 3D surgical planning system built in Unity. It allows real-time interaction with anatomical 3D models using voice commands to control a resection plane and perform mesh segmentation.

---

## Features
- Import of 3D anatomical model (STL → Unity)
- Voice-controlled resection plane movement (Up / Down)
- Runtime mesh slicing using plane intersection
- Segment removal (Proximal / Distal)
- Minimal UI status feedback system

---

## Voice Commands
- Up → Move plane upward
- Down → Move plane downward
- Cut → Execute mesh slicing
- Remove Proximal → Remove upper segment
- Remove Distal → Remove lower segment

Keyboard fallback:
- Space → Execute Cut

---

## Tech Stack
- Unity (C#)
- EzySlice (mesh slicing)
- KeywordRecognizer (voice commands)
- Blender (mesh preprocessing)

---

## How to Run
1. Open project in Unity (2022.3 LTS recommended)
2. Open scene:
   `Assets/Scenes/Main.unity`
3. Press Play
4. Use voice commands or keyboard fallback

---

## Architecture
The system is structured into modular components:
- Voice Input Layer
- Interaction Controller
- Geometry Processing Layer
- UI Feedback Layer

This separation allows scalability and future integration with robotic surgical systems.

---

## Limitations
- Prototype-level voice recognition (KeywordRecognizer)
- STL-based workflow (no DICOM pipeline)
- Uses third-party slicing library (EzySlice)

---

## Author
Mateo Menvielle