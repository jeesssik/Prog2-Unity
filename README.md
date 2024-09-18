  REGISTRO DE CAMBIOS
 
# Aplicacion de SOLID al archivo DungeonGenerator



<h3>1. Single Responsability Principle:</h3>
El archivo <b>DungeonGenerator</b> tenía muchas responsabilidades (generar laberinto, habitacioners y lo de GUI). Se le sacó la lógica de la generación de mazmorras y se separaron responsabilidades en: <br><br>

- <b>MazeGenerator</b>: es una clase que se encarga de generar los laberintos.
- <b>Cell</b>: clase que maneja las celdas del laberinto y cómo se conectan.
- <b>DungeonGenerator</b>: ahora sólo coordina el proceso de generación general de la mazmorra.


<h3>2. Open/Close:</h3>
Se implementó <b>ImazeGenerator</b> llegando al caso de necesitar nuevos tipos de laberintos de mazmorras y no tener que modificar el código en <b>DungeonGenerator</b>.

<h3>3. Liskov:</h3>
Se puedea sustituit cualquier implementación de <b>IMazeGenerator</b> sin romper el código.


<h3>4. Interface Segregation:</h3>
El uso de la interfaz <b>ImazeGenerator</b> (que define sólo métodos relevantes para la generación del laberinto) asegura que <b>GameController</b> no tenga que implementar nada que no necesite.



<h3>5. Dependency Inversion Principle:</h3>
En vez de instanciar <b>Mazegenerator</b> directamente en <b>DungeonGenerator</b> se crea la interfaz <b>IMazeGenerator</b> para depender de la abstracción y no de una implementación concreta.

---------------------------------------------------------------
<br><br>




# Aplicación de patrón Factory

- <b>IMazeGeneratorFactory</b>: especifica el método de creación del generadora de laberinto.

Se implementa la fábrica en <b>Mazegenerator</b>

Se modifica el <b>GameController</b> para implementar la fábrica en vez de crear una instancia de <b>Mazegenerator</b>.

<br><br><br>

-----------------------------------------------------------


<br><br><br>

 ## Cambios no importantes (por ahora) Realizados

* git ignore
* la generación de salas muchas veces no genera una puerta de una sala a la otra. Y no se puede seguir avanzando ✔
* se están generando rooms randoms entre todas las prefabs de rooms ✔
*  la room inicial no tiene que tener un enemigo (se identificó a los "Enemy" y se los eliminó en la room 0) ✔

---------------------------------------------------

* ~~Colliders en jugador y enemigos para que no sean atravesables ✔~~
* Se cambió las animaciones del jugador pde AC_character por DogControl.✔
* El jugador ya ataca on left click a los enemigos cuando están en rango ✔
* El destroy de enemigo en la sala 0 solo ocultaba su imagen pero el bicho a veces se incializada (aunque no se veía)
  se cambió el <b>Destroy</b> por <b>enemy.SetActive(false)</b> ✔






 ## A chequear:
 * El dungeongenerator no debería poner puertas si el dungeon no da a otro
 * las puertas que dan hacia la nada
 * marcar cual es la final room, que tenga al boos final o algo
 * Las animaciones de los enemigos son procedurales, falta las variables de control del animator
 * Está bien que el jugador atraviese a los enemigos?




