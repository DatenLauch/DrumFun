# DrumFun

Dieses Projekt entstand im Rahmen einer Studienleistung für das Modul “Audio- und Videotechnik” und "Mensch-Maschine Interaktion". Es handelt sich hierbei um ein Rhythmus-Spiel, welches den Umgang mit einem Schlagzeug spielerisch fördern soll.

## Installation
Das Programm ist vorerst nur über einen Unity Editor ausführbar, welches über den Unity-Hub installiert werden kann: 
https://unity.com/de/download Das Projekt verwendet und empfiehlt einen Editor der Version 2021.3.22f1.
   1. Download des Projekts über GitHub.
   2. Entpacken der Zip-Datei in einen Wunschordner.
   3. Der Ordner enthält jetzt Git-Dateien und das eigentliche Unity Projekt in einem Unterordner “MMI AVT Project” (ohne Bindestriche). Um nun das Unity Projekt zu öffnen, muss dieses über den Unity Hub ausgewählt und gestartet werden.
  4. Im Unity Hub “Projects” → “open” → “add project from disk” → Ordner “MMI AVT Project” → add project.
  5. Doppelklick auf das hinzugefügtes Projekt zum Öffnen im Editor.
  6. Die Szene “DrumFunMain” per Doppelklick öffnen.
  7. Das Spiel kann nun über den "Play Button" im Editor gestartet werden.

## Spielanleitung
Ziel ist es, die sich nähernden farbigen Kugeln so genau wie möglich zur Musik zu treffen, indem 3 Drums aktiviert werden. Diese können entweder über einen Midi-Controller oder die Tastatur angesteuert werden. Das Spiel kann mit “esc” pausiert werden und bietet dort die Möglichkeit, die Lautstärke zu ändern. Nachdem das Level abgeschlossen wurde, erscheint ein Scorescreen, welcher das erzielte Ergebnis anzeigt. Bei mehreren Durchläufen hat der Spieler nun die Möglichkeit, den persönlichen Fortschritt zu überprüfen, indem die Ergebnisse verglichen werden. Tastenbelegung

## Midi-Controller
Ein Midi-Controller kann als Eingabegerät verwendet werden, indem der Input über die Noten “D2”, “C2” und “G2” gesendet wird. Diese Noten wurden als Standard gewählt, da diese mit dem Schlagzeug “Roland TD-1K” getestet wurden (Snare, Floor Tom und Hi-Hat). Um zu erfahren, welche Noten ein Midi-Controller wann sendet, können im MidiInputScript.cs die Zeilen 28-37 auskommentiert werden, damit genauere Informationen auf der Konsole angezeigt werden. Um die Belegung nun zu ändern, müssen die entsprechenden Noten aus Zeile 39-47 ausgetauscht werden.

## Tastatur & Maus
Die Drums können auch über die Tasten 1, 2 und 3 aktiviert werden. Pause mit “esc”. Alle UI-Elemente wie etwa Buttons und Slider werden per Maus bedient.

## Levels und Musik
Das Projekt hat momentan nur ein spielbares Level. Es ist aber möglich, neue Levels und Musik zu verwenden. Dazu muss das Spawner-Objekt angepasst werden.

## Level
Das Level wird durch eine Mididatei generiert. Der Pfad muss in den Parameter “Music-Clip” im Spawner-Objekt eingetragen werden. Der Spawner spawnt auf 3 Bahnen Kugeln, welche dann auf den Spieler zurollen. Dabei ist eine Bahn jeweils für eine einzige Musiknote zuständig (Bahn 1 = C#2, Bahn 2 = C2, Bahn 3 = D2). Wenn während des Spielens in der Mididatei die Note C#2 vorkommt, wird ein Objekt auf Bahn 1 generiert und rollt auf den Spieler zu. Es dauert mit den verwendeten Standardwerten 3 Sekunden bis die Kugel den Spieler erreicht. Damit die Musik und das Level synchron zueinander verlaufen, müssen beide Dateien deswegen mindestens 3 Sekunden Stille am Anfang haben und dann zur gleichen Zeit starten. Durch das Setzen von Häkchen lassen sich Bahnen aktivieren oder deaktivieren.

## Musik
Die Musikdatei muss im .wav Format sein und kann per Drag-and-drop als Parameter “Music-Clip” im Spawner-Objekt ausgetauscht werden.

## Bibliotheken
__TextMesh Pro__ (Version 3.0.6)
  * Verwendet für bessere UI-Elemente.
  * Download über Unity Package Manager im Editor.
    
__DryWetMidi__ (Version 7.0.0)
  * Für den Umgang mit Midi-Dateien zum Generieren des Levels.
  * https://assetstore.unity.com/packages/tools/audio/drywetmidi-222171
    
 __Minis__ (Version 1.0.10)
  * Um Midi-Controller als Input zu verwenden.
  * https://github.com/keijiro/Minis
