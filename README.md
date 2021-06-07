# Softwareentwicklung SoSe2021 - Aufgabe 06

??

## Bearbeitungzeit

SWE: ?? 2021 (Mm, BWM, ROB, BAI, BGIP, BBWL, BBL, MGIN)

Einführung in SWE: ?? 2021 (KGB, BENG, VTC, MB)

## Entwicklung einer Mobilfunkinfrastruktur

Sie setzen im Auftrag eines Kommunikationsdienstleisters einen neuen `Kommunikationskoordinator` um, der die Interaktion mit unterschiedlichen Endgeräten realsiert. Dabei sollen die Endgeräten in einer Gesamtliste erfasst werden und verschiedene Services dafür abgebildet werden: 

| Konfiguration   | eingebundene Geräte                          |
|-----------------|----------------------------------------------|
| einzelnes Gerät | Auslösen eines Alarmklingelns, Lokalisierung | 
| Gerätepaar      | Sprachanruf, Textnachricht                   |

Dabei soll für die Logik des `Kommunikationskoordinators` folgende Regeln gelten:

+ Sprachanrufe können nur realisiert werden, wenn das Gerät nicht stumm geschalten und online ist. Das Telefon antwortet im zweiten Fall mit einem Fehlercode.
+ Sprachanrufe, die eine Nummer adressieren, die nicht in der Liste der Geräte 
+ Textnachrichten werden zugestellt wenn das Gerät Online ist. Der Mechanismus funktioniert aber nur für das Betriebssystem `OS_A`.
+ das Alarmklingeln wird auf allen Geräten mit dem Betriebssystem `OS_B` ausgeführt, wennn sie online sind.
+ Lokalisierungen sind für nur für Smartphones möglich 

Da der Kunde Ihre Lösung nicht auf die realen Geräte seiner Nutzer "loslassen" möchte, werden Sie beauftragt die Leistungsfähigkeit des `Kommunikationskoordinator` zunächst in einer Simulationsumgebung zu zeigen. Diese liest Konfigurationsdateien, die die verfügbaren Instanzen der Smartphones umfassen und testet die angeführten Serviceanforderungen. 

Dafür sollen zwei Typen von Telefonen berücksichtigt werden, allgemeine Mobiltelefone und Smartphones. Nur Letztere unterstützen eine Methode `getPosition()`. 
Ein erfolgreicher Service - Anruf, Textnachricht, Alarmklingeln, Positionsabfrage - werden auf dem Display des Mobiltelefons (der Konsole) angezeigt.

| Membertyp   | Name                                                   | Type                    | Bemerkung                                 |
|:----------- |:------------------------------------------------------ |:----------------------- | ----------------------------------------- |
| Eigenschaft | `PhoneNumber`                                          | `string`                |                                           |
|             | `PhoneState`                                           | `enum{normal, silent}`  | `silent` nur von Smartphones unterstützt! |
|             | `ConnectionState`                                      | `enum{online, offline}` |                                           |
| Methoden    | `receiveACall(string incommingNumber)`                 |                         |                                           |
|             | `receiveAMessage(string incommingNumber, string text)` |                         |                                           |
|             | `getPosition()`                                        |                         | Nur von Smartphones unterstützt!          | 
|             | `getOS()`                                              |                         |                                           |

Im Kommunikationskoordinator sind statische Informationen zu den Telefonen gespeichert - die Telefonnummer, das Betriebbsystem und der Verbindungsstatus (offline, online), alle Eigenschaften darüber hinaus müssen bei den simulierten Telefonen angefragt werden. 


``` 
                            +----------------------------------------+
                            | ServicesTests.csv                      |
                            |  1 02234 ruft 23424                    |
                            |  2 02234 ruft 0000 (unbekannte Nummer) |
                            |  3 Alarmklingeln für 012332            |
                            |  4 Positionsinformation für 023432     |
                            +----------------------------------------+
                                                |
                                                v
 +----------------------+      +-----------------------------------+       +---------------+
 | PhoneData.csv        |      | MobilfunkSimulation               |       | Ergebnis.csv  |
 |  - Telefonnummer     |      |                                   |       | 1 erfolgreich |
 |  - Betriebssystem    | -- > |  Liste mit Instanzen der Telefone |  -- > | 2 gescheitert |
 |  - Telefonstatus     |      |  +-----------------------------+  |       | 3 erfolgreich |
 |  - Verbindungsstatus |      |  | KommunikationsKoordinator   |  |       | 4 gescheitert |
 |  - (Position)        |      |  |                             |  |       +---------------+
 +----------------------+      |  | Liste BasisTelefonDaten     |  |
                               |  +-----------------------------+  |
                               +-----------------------------------+
                                                          
```

Setzen Sie die Aufgabe in drei Stufen um: 

1. Dafür entwirft zunächst der Senior Developer (und Projekt Maintainer) eine Klassenstruktur in UML mit PlantUML. Legen Sie das Diagramm als Bild im Issue "UML_Modell" ab, diskutieren Sie den Entwurf mit Ihrem Partner und verfeinern Sie diesen ggf.
2. Teilen Sie sich die Aufgaben auf ordnen Sie diese in Issues zu und implementieren Sie diese. 
3. Der Senior Developer entwirft variierende Implementierungen von `ServicesTests.csv` und `SmartphoneData.csv` und tauscht diese ggf. mit anderen Teams aus. Beide prüfen in den jeweiligen Verantwortlichkeiten, die Korrektheit der Ergebnisse und bessern ggf. nach.

## Hilfen 

+ Die beispielhafte Dateien für SmartphoneData.csv und ServicesTests.csv finden sich in Projektordner.
+ Das Einlesen von csv Inhalten wird in [DeserializationInCsharp](https://www.youtube.com/watch?v=kuOb8_U2jzE) erläutert.
