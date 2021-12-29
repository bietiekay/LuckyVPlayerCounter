# LuckyV Spielerzähler
(C) Daniel Kirstenpfad / LuckyV ist ein grosser deutscher GTA RP Server.

Icon: Icons made by https://www.freepik.com from https://www.flaticon.com/

[![Creative Commons License](https://i.creativecommons.org/l/by-sa/4.0/88x31.png)](http://creativecommons.org/licenses/by-sa/4.0/)  
LuckyV Spielerzähler by [luckyv.de](https://creativecommons.org/choose/luckyv.de) is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/).  
Based on a work at [schrankmonster.de](https://creativecommons.org/choose/schrankmonster.de).


Ich hatte [ja schon darüber geschrieben](https://www.schrankmonster.de/2021/04/28/joining-the-luckyv-gta-rp-developer-team/) dass ich beim Projekt “[LuckyV](https://luckyv.de/)” mitprogrammiere. Im Zuge dieser Programmierarbeit habe ich auch selbst begonnen GTA RP zu [spielen und zu streamen](https://www.twitch.tv/bietiekay).

Gleich zu Anfang habe ich mir meinen Stream so eingerichtet dass jeweils der aktuelle Spieler-Counter immer im Bild zu sehen war. Ich finde das einfach eine ganze witzige Information vor allem für LuckyV-Interessierte.

[![](https://www.schrankmonster.de/wp-content/uploads/2021/12/Screenshot-2021-12-27-171346-600x339.png)](https://www.twitch.tv/bietiekay)

rechts oben – die aktuelle Zahl der gleichzeitigen Spieler auf LuckyV

Meine ursprüngliche Implementierung war etwas kompliziert – zu kompliziert um sie einfach mit anderen zu teilen. 

Daher habe ich mich entschlossen den Zähler in eine eigene Windows Applikation zu verpacken die von Streamern einfach verwendet und in [OBS](https://obsproject.com/) eingebunden werden kann.

Daher gibt es ab sofort frei verfügbar ein [Github Repository mit dem Quelltext und der fertig verpackten Applikation.](https://github.com/bietiekay/LuckyVPlayerCounter)

[![](https://www.schrankmonster.de/wp-content/uploads/2021/12/Screenshot-2021-12-27-170727-600x405.png)](https://github.com/bietiekay/LuckyVPlayerCounter)

Das dann in seinen Stream einzubinden ist denkbar einfach:

-   Herunterladen – von [hier zum Beispiel](https://github.com/bietiekay/LuckyVPlayerCounter/releases)
-   Starten und prüfen ob die Zahl auch angezeigt wird – es sollte ungefähr so aussehen: 

![](https://www.schrankmonster.de/wp-content/uploads/2021/12/Screenshot-2021-12-27-155237-600x323.png)

Man kann das nun auf zwei Wegen einbinden. 

## Weg 1: Fensteraufnahme

In der Applikation kann man Hintergrundfarben sowie Schriftart und Farbe konfigurieren. Wenn man das erledigt hat wie man es haben will wählt man im Quellenmenü “Fensteraufnahme” und dann das Applikationsfenster.

![](https://www.schrankmonster.de/wp-content/uploads/2021/12/image.png)

Fensteraufnahme

[![](https://www.schrankmonster.de/wp-content/uploads/2021/12/image-1-600x356.png)](https://www.schrankmonster.de/wp-content/uploads/2021/12/image-1.png)

Diese Quelle kann man dann wie man möchte konfigurieren. z.B. mit Filtern um bis auf die Schrift alles transparent zu gestalten oder oder oder…

## Weg 2: playercount.txt

Wenn die Applikation läuft aktualisiert sie ständig eine Datei “playercount.txt” im gleichen Ordner. Man kann nun OBS so konfigurieren dass diese Datei regelmässig ausgelesen und angezeigt wird. 

Dazu fügt man ein “Text (GDI+)” im Quellenmenü hinzu und konfiguriert diese Quelle so dass der Text aus einer Datei gelesen wird:

[![](https://www.schrankmonster.de/wp-content/uploads/2021/12/image-2-600x382.png)](https://www.schrankmonster.de/wp-content/uploads/2021/12/image-2.png)

Hier kann man dann auch beliebig Schriftart, Größe und Farbe konfigurieren.
