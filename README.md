# Softwareentwicklung SoSe2021 - Aufgabe 06

Mit dem Aufgabenblatt sollen Ihre Fähigkeiten des objektorientierten Entwurf weiter trainiert werden. Thematisiert wird außerdem das Testen der Entwurf realisiernden  Implementierung.

## Bearbeitungzeit

SWE: 21.6.- 2.7. 2021 (Mm, BWM, ROB, BAI, BGIP, BBWL, BBL, MGIN)


## Entwicklung einer Mobilfunkinfrastruktur

Sie setzen im Auftrag eines Kommunikationsdienstleisters einen neuen `Kommunikationskoordinator` um, der die Interaktion mit unterschiedlichen Endgeräten realsiert. Dabei sollen die Endgeräte in einer Gesamtliste erfasst werden und verschiedene Services dafür abgebildet werden:

| Konfiguration   | eingebundene Geräte                          |
|-----------------|----------------------------------------------|
| einzelnes Gerät | Auslösen eines Alarmklingelns, Lokalisierung |
| Gerätepaar      | Sprachanruf, Textnachricht                   |

Bei der Realisierung der Services soll dabei eine Reihe Regeln gelten, z.B.:

+ Sprachanrufe können nur ausgelöst werden, wenn das Gerät `online` ist.
+ Sprachanrufe werden nur entgegengenommen werden, wenn das Gerät nicht stumm geschalten (Status `normal`) und `online` ist.
+ Textnachrichten können generell nur an Geräte mit dem Betriebsystem `OS_A` verschickt werden, und nur dann, wenn sie online sind `online` ist.
+ das Alarmklingeln wird nur auf Geräten mit dem Betriebssystem `OS_B` ausgeführt.
+ Lokalisierungen sind für nur für Smartphones möglich.

Da der Kunde Ihre Lösung nicht auf die realen Geräte seiner Nutzer "loslassen" möchte, werden Sie beauftragt die Leistungsfähigkeit des Kommunikationskoordinator zunächst in einer Simulationsumgebung zu zeigen.

Berücksichtigt werden sollen dabei zwei Typen von Telefonen, allgemeine Mobiltelefone und Smartphones, die über eine in der Tabelle erfaßte (oder ähnliche) Funktionalität verfügen sollen.
Ein erfolgreicher Service - Anruf, Textnachricht, Alarmklingeln, Positionsabfrage - werden auf dem Display des Mobiltelefons (der Konsole) angezeigt.

| Membertyp   | Name                                                   | Bemerkung                                 |
|:----------- |:------------------------------------------------------ |:---------------------------------------- |
| Eigenschaft | `PhoneNumber`                                          | z. B. 02123                               |
|             | `PhoneState`                                           | `normal`, `silent`                        |
|             | `ConnectionState`                                      | `online`, `offline`                       |
|             | `Position`                                             | z.B. (54.3,12.5) nur von Smartphones unterstützt! |
|             | `OS     `                                              | z.B. `OS_A`, `OS_B`                            |
| Methoden    | `receiveACall(string incommingNumber)`                 |                                           |
|             | `receiveAMessage(string incommingNumber, string text)` |                                           |
|             | `ringAnAlarm()`                                        |                                           |

Der Konfigurationssimulator:

+ soll die Datei [SmartPhoneData](https://github.com/ComputerScienceLecturesTUBAF/SoftwareentwicklungSoSe2021_Aufgabe_07/blob/main/SmartPhoneData.csv), die die Daten für die verfügbaren Geräte enthält, lesen und die Liste der Geräte-Instanzen erstellen.   
+ Weiterhin erhält der Kommunikationskoordinator eine Liste der Tests, die ebenfalls in einer Datei zur Verfügung gestellt werden ([ServicesTests.csv](https://github.com/ComputerScienceLecturesTUBAF/SoftwareentwicklungSoSe2021_Aufgabe_07/blob/main/ServicesTests.csv)).
+ Kommunikationskoordinator testet die Serviceanforderungen, in dem er die in den Tests genannten Methoden in speziellen Testmethoden aufruft. Dabei wird überprüft, ob die entsprechenden Rahmenbedigungen erfüllt sind. Die Ergebnisse des Testens werden in der weiteren Datei (Ergebnis.csv) protokolliert.

```
                                      +------------------------------------------------+
                                      | ServicesTests.csv                              |
                                      |  1 Anruf von 03231 an 02234                    |
                                      |  2 Anruf von 02234 an 0000 (unbekannte Nummer) |
                                      |  3 Alarmklingeln für 012332                    |
                                      |  4 Positionsinformation für 023432             |
                                      +------------------------------------------------+
                                                              |
                                                              v
 +---------------------------------------+      +-----------------------------------+       +---------------+
 | SmartPhoneData.csv                    |      | MobilfunkSimulation               |       | Ergebnis.csv  |
 |  03231,OS_A,normal,online             |      |                                   |       | 1 erfolgreich |
 |  02234,OS_B,silent,online, 54.3,12.5  | -- > |  Liste der Tests                  |  -- > | 2 gescheitert |
 |  03232,OS_A,normal,offline            |      |  +-----------------------------+  |       | 3 erfolgreich |
 |  02125,OS_B,silent,offline, 54.3,12.5 |      |  | KommunikationsKoordinator   |  |       | 4 gescheitert |
 +---------------------------------------+      |  |        Liste der Telefone   |  |       +---------------+
                                                |  +-----------------------------+  |
                                                +-----------------------------------+

```

Setzen Sie die Aufgabe in drei Stufen um:

1. Dafür entwirft zunächst der Senior Developer (und Projekt Maintainer) eine Klassenstruktur in UML mit PlantUML. Legen Sie das Diagramm als Bild im Issue "UML_Modell" ab, diskutieren Sie den Entwurf mit Ihrem Partner und verfeinern Sie diesen ggf.
2. Teilen Sie sich die Aufgaben auf ordnen Sie diese in Issues zu und implementieren Sie diese.
3. Der Senior Developer entwirft variierende Implementierungen von `ServicesTests.csv` und `SmartPhoneData.csv` und tauscht diese ggf. mit anderen Teams aus. Beide prüfen in den jeweiligen Verantwortlichkeiten, die Korrektheit der Ergebnisse und bessern ggf. nach.

## Hilfen

+ Die beispielhafte Dateien für SmartPhoneData.csv und ServicesTests.csv finden sich in Projektordner.
+ Das Einlesen von csv Inhalten wird in [DeserializationInCsharp](https://www.youtube.com/watch?v=kuOb8_U2jzE) erläutert.
