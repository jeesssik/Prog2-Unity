 # REGISTRO DE CAMBIOS
 
 ##  Realizados

* git ignore
* la generación de salas muchas veces no genera una puerta de una sala a la otra. Y no se puede seguir avanzando ✔
* se están generando rooms randoms entre todas las prefabs de rooms ✔
* que la room inicial no tenga un enemigo (se identificó a los GO coo "Enemy" y se los eliminó en la room 0) ✔

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
 * chequear si los colliders están tomados en cuenta en la programación
 * Las animaciones de los enemigos son procedurales, falta las variables de control del animator
 * Está bien que el jugador atraviese a los enemigos?




