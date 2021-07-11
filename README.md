Asset-Ordner:

- Animations
> LevelFade
> MainMenu_Animation
> Player

- Environment
> background
> props
> Sprites
> Tiles

- Fonts

- Palettes
> EnvironmentPalette
> TilePalette

- Physics
> slip

- Prefabs
> Button
> Cinemachine
> Collectible
> Deathzone
> Drone
> Levelende
> Player
> UI Canvas

- Resources (Sound)

- Scenes
> BaseCityGame (Level 1)
> GameOver
> Level2 (Level 2)
> MainMenu

- Scripts
> Camera2DFollow

steuert die Kamerabewegung
=> Einstellungen, wie schnell die Kamera den Spieler verfolgt, wie weit in die Bewegungsrichtung geblickt wird, wie schnell die Kamera beim Stoppen ebenfalls anhält
=> Methode FindPlayer zum Fokussieren auf den Spieler mittels FindGameOjectWithTag "Player"

#Wie funktioniert das?
- Script an MainCamera angeschlossen
- Wichtig: target = "Player" und Einstellungen s.o. modifizieren

> deathzone

berührt der Spieler die Deathzone, wird Kill aus GameMaster aufgerufen

#Wie funktioniert das?
- GameObject mit BoxCollider 
- checkt nach Tag "Player"
- angeschlossenes Script mit OnCollisionEnter-Funktion

***Notes: alternativ isTrigger bei BoxCollider aktivieren und OnTriggerEnter2D verwenden

> GameMaster

initialisiert Player am festgelegten Spawnpoint, Checkpoint-Methode, um neuen Spawnpoint auf Checkpoint festzulegen, Respawn-Methode, die Spieler am Spawnpoint instanziiert, KillPlayer-Methode, die Lebenspunkte des Spielers dekrementiert, wenn sie aufgerufen wird
GameOver mit SceneManager.LoadScene geladen + Respawn, wenn m_Life == 0 

***Notes: 

- SerializeField deswegen, damit die Lebenspunkte über die Level persistent bleiben, oder was macht das genau?
- 
- Bei mir kann der Lebenspunktescore unter Null fallen (?!)

#Wie funktioniert das?
- livesText als GameObject
- statische Variable gm wird benutzt, um GameMaster-Object aufzurufen
- es soll nur einen gm gleichzeitig geben => == null
- Prefab GM konstruiert mit angehängtem Script GameMaster + Parallaxing (s.u.)
***Unity-Buch programmiert so:
public static GameMaster gm = null;
void Awake ()
{
if gm != null && gm != this)
{ 
Destroy(gameObject);
}
else
{
gm = this;
}}
void Start()
{
SetupScene();
}
public void SetupScene()
{
////
}}

> Drone

steuert die Bewegungen der Drohne
=> Initialisierung der Position, Geschwindigkeit
=> Patroullieren mittels Math.PingPong
=> Flippen mit flipX

***NOTE: 
- Im ersten Level haben sie sich nicht mehr bewegt - habe ich geändert, sie bewegen sich jetzt langsam (speed 2, range unterschiedlich)
- Die sind jetzt immer an derselben Stelle, ja? Soll das so bleiben oder sollen die sich randomly verteilen?

> DroneVertical

steuert die Bewegungen der Drohne in vertikaler Richtung
=> Initialisierung der Position, Geschwindigkeit
=> Patroullieren mittels Math.PingPong in y-Richtung

> End_Screen

konstruiert einen Endscreen
=> Restart mit Level 1 (BaseCityGame)
=> Hauptmenü (MainMenu)

***NOTE: Zweites Level starten Button fehlt noch

> GegnerMovement

enthält noch nix

***NOTE: Brauchen wir das extra? Drone ist ja nicht so superlang

> LadderBehaviour

steuert, wie der Spieler die Leitern benutzt
=> mittels OnTriggerStay kann der Spieler die Leiter mittels "W" hoch- und mittels "S" heruntersteigen 
=> sonst verharrt er in seiner Position auf der Leiter

***NOTE: Der Spieler "prallt" manchmal von irgendwas ab, wenn er in die Nähe der Leitern kommt - aber nur manchmal

> LevelChanger

Transition-Animation (LevelFade) aufgerufen bei Klick auf Button, Levelindex inkrementiert, nach vollständigem FadeOut => nächstes Level geladen

***Note:
Den entsprechenden Button gibt's im Interface noch nicht, ja?

> Levelende

beim Berühren des Spielers mit Levelende => Levelende

#Wie funktioniert das?

- GameObject mit BoxCollider und OnCollisionEnter2D
=> Tag "Player" => nächstes Level laden

***Note:
Hier habe ich die Bonuspunkte eingefügt, aber das will nicht so richtig - darum jetzt GameMaster
Sollten wir das extra lassen oder auch in den GameMaster schieben?

In Build Settings müssen noch die übrigen Szenen in der richtigen Reihenfolge reingezogen werden, glaube ich. Nach Level 2 können wir entweder wieder Level1 starten lassen oder wollen wir einen WIN-Screen oder so?

> MenuManager

enthält StartGame-Methode zum Laden der aktuellen Szene und QuitGame-Methode, die Spiel beendet

***Note: hängt das schon wo dran??

> Parallaxing

speichert und passt die Hintergründe und die Kamera während des Spielverlaufs an

> PlayerController

initialisiert und definiert sämtliche Parameter für das Verhalten bei Bewegung des Spielers - wie wird gesprungen, gelaufen etc.?
=> geht in die Knie beim Landen
=> beim Crouching wird Collider deaktiviert (*** warum?)
=> Flip() beim Bewegen nach rechts/links
=> bei Berührung mit Gegner-Tag: KillPlayer-Methode aufgerufen
=> bei Berührung mit Collectible: Score hochgezählt und Zerstörung des Collectibles; 10 Bonuspunkte bei allen Leben

***Note: 
Hatte es einen Grund, warum die Leben auskommentiert waren? 
Ich bin so schlecht in diesem Spiel und schaffe es nicht mehr bis zum Ende mit 3 Leben - kann mir jemand sagen, ob es jetzt funktioniert mit den Bonuspunkten?

> PlayerMovement

Spielerbewegungskontrolle mittels Tasten

> SoundManager

Sound bei jump, hit, coins

> Bullet

erzeugt GameObject an Firepoint (bisher hat den nur der erste Enemy2)
Wenn eine Kugel den Spieler trifft => KillPlayer aufgerufen

> Enemy2

Bei Berühren des Spielers => KillPlayer aufgerufen (ich bin mir nicht sicher, ob das funktioniert. Bei mir stirbt immer das Teil)
Berührt der Spieler die Killbox, dann wird das Object zerstört und explodiert (theoretisch)

***Note: Flip-Methode auskommentiert bisher, weil ich die Animation überall wie besprochen ausgestellt habe

> Spawnpoint

wenn der Spieler den Checkpoint erreicht => Spawnpoint aktualisiert auf Checkpointposition

> Shooting

Script zum Schießen - funktioniert bisher so lala

> Zeichnung

leer

- Sprites
- TextMesh
- Tiles


SpawnPoints:

> SpawnPoint (Start)
> SpawnPoint (Checkpoint)

=> festgelegte Stellen, an denen GameObjects gespawnt werden
theoretisch kann man Enemy-Spawn-Stellen machen und dort tauchen die Gegner dann in festgelegten Intervallen auf













aktuelle Version 
-Leitern funktionieren jetzt besser, aber noch keine Animationen und man fällt wegen der Gravitation noch langsam nach unten wenn man sich auf der Leiter nicht bewegt.

- Wenn man das Spielende erreicht (die Antenne auf dem Turm ganz oben) wird in der Console "Nächstes Level" ausgegeben

- Paar Drohnen eingefügt mit Random Geschwindigkeit (Können bis jetzt nur übersprungen werden)

- Wenn man von den Häusern fällt, kommt man in die Deathzone und die Szene wird neu gestartet

Collectibles:
- Objekte werden gesammelt und gezählt, ausgegeben als Score: xy im linken oberen Bildrand
- Script angepasst von PlayerController
=> Start-Methode zum Initialisieren des Collectible-Counters und eine EnterOnTrigger-Methode eingefügt

- Komisch: 

> Textfeld verschwindet manchmal, wenn ich neu öffne und taucht nicht mehr auf - liegt das an irgendeiner falschen Layer??
