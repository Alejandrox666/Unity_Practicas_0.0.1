# Unity_Practicas_0.0.1
# Ejecución de tutoriales juego en 2D 

Alumno: Alejandro Hernández Negrete

Grupo GIDS5103

Objetivo
El estudiante practicará los fundamentos de videojuegos en 2D con Unity.



<p align="center">
  <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRf9oYjAjQvY7TIldEY95WkvDe8Emb83C6FTQ&s" width="60%" alt="Descripción de la imagen">
</p>

## Contents

- [Folder and file structure](#folder-and-file-structure)
- [Requirements:](#requirements)
- [How to start](#how-to-start)
- [Site configuration](#site-configuration)
- [Tasks](#tasks)
    - [Cleanup](#cleanup)
    - [Dev](#dev)
    - [Build](#build)
    - [Rebuild](#rebuild)
    - [Server](#server)
    - [Sprite](#sprite)
- [Live reload](#live-reload)
- [License](#license)

## Folder and file structure

```
./
├── .editorconfig
├── gulpfile.js
├── package.json
├── README.md
|
├── gulp_tasks/                                * gulp tasks
|   ├── config/                                * gulp tasks config
│   |   ├── paths.js
│   |   └── aliases.js
│   |
|   └── task.js
|
├── screenshots/                               * responsive test screenshots
|
├── dev/                                       * site source
│   ├── images/                                * image sources
|   │
│   ├── pug/                                   * templates
|   |   ├── blocks/                            * blocks library
|   │   |   └── block.pug
|   │   ├── helpers/                           * helper mixins
|   │   ├── vendor/                            * third-party code
|   │   ├── layouts/                           * page layouts
|   │   └── pages/                             * main pages templates
|   │
│   ├── js/                                    * source js
|   |   ├── vendor/                            * vendor scripts library
|   |   ├── lib/                               * site scripts library
|   │   ├── head.js                            * head scripts
|   │   └── body.js                            * body scripts
|   │
|   ├── sass/                                  * sass preprocessor styles
|   |   ├── blocks/                            * blocks library
|   │   |   └── block.sass
|   │   ├── helpers/                           * mixins and vars
|   │   ├── vendor/                            * third-party code
|   │   ├── custom.sass
|   │   ├── noscript.sass
|   │   └── screen.sass
|   │
│   ├── helpers/                               * helper files
|   |   ├── favicon.ico
|   |   └── .htaccess
|   │
│   ├── fonts/                                 * font sources
|   │
│   └── data/                                  * configs and data for templates
│
└── build/                                     * built source
    ├── index.html
    ├── page.html
    |
    └── static/                                * static assets
        ├── css/                               * minified styles
        |
        ├── images/                            * minified images
        │
        ├── js/                                * minified assembled js
        |
        └── fonts/                             * @font-face-ready webfonts

```

## Requerimientos

- SO: Windows 7 (SP1+) / Windows 10 / Windows 11

- Procesador: X64 architecture with SSE2 instruction set support

- Memoria RAM: 4 GB mínimo (8 GB recomendado)

- Tarjeta gráfica: DX10, DX11, DX12-capable

- Almacenamiento: 8 GB de espacio libre

## Player Animations 2D Tutorial 01

- Crear un nuevo proyecto a través de Unity Hub. Seleccionar el número de versión más actual de acuerdo a las versiones instaladas en tu Unity Hub.
  <img width="1098" height="559" alt="image" src="https://github.com/user-attachments/assets/f01b2d8f-b929-4ef0-b2a3-333fe1714491" />

- Crear la estructura de proyecto de la imagen.
- Abrir el IDE de Unity, crear dos objetos vacíos mediante la vista Hierarchy opción crear
qué se encuentra en la esquina superior izquierda. Renombra los objetos como
PlayerObject y EnemyObject.
- Para el objeto PlayerObject selecciona la opción Add Component | Sprite Renderer.
Utiliza el mismo proceso para el objeto EnemyObject.
- Guarda la escena como LevelOne, primeramente crea un folder llamado Scenes y dentro de ella guarda.
- Descargar el archivo de imágenes qué viene junto al tutorial, selecciona el archivo Player.png, EnemyIdle_1.png, EnemyWalk_1.png y arrastrarlos al folder correspondiente dentro de la carpeta sprites
- Cambiar las propiedades del objeto Player.png dentro de la vista Inspector tal como lo muestra la siguiente imagen, verificalo y después da clic en Apply.
- Ubica la opción Window|2D|Sprite Editor de la vista Inspector para dividir la hoja de sprites en inviduales. Presiona el botón Slice de la esquina superior izquierda y cambia las propiedades como muestra la siguiente imagen, una vez qué termines de modificar las propiedades presiona el botón de la parte inferior derecha del cuadro de diálogo.
- Ahora presione el botón "Apply" para aplicar el corte a la hoja de sprites. Cerrar el Editor de Sprite.
- Pongamos estos sprites a trabajar. Seleccione el PlayerObject. En la vista Inspector, a la derecha de la propiedad Sprite verá un pequeño círculo, selecciona un sprite para cuando estamos en la vista Game.
- Slice del enemigo.
- Expanda los sprites del Player haciendo clic en la pequeña flecha junto a él en el Vista de proyecto. Selecciona los cuatro primeros sprites con tecla Ctrl + clic izquierdo del ratón
- Arrastra los sprites seleccionados sobre el objeto PlayerObject.
-	Guarda la animación en la carpeta Animaciones y nombrar como player-walk-east.
-	Ahora seleccione PlayerObject y observe la vista del Inspector. Observa cómo tenemos dos componentes nuevos : Sprite Renderer y Animator. Un componente Sprite Renderer es responsable de mostrar o renderizar un sprite. Unity también agregó un componente Animator, qué contiene un Animator Controller, que permite la reproducción de animaciones.
- Renombra el controller como PlayerController y arrastralo a la carpeta
Animations|Controllers.
- Agreguemos el resto de nuestras animaciones. Vuelve a la carpeta Sprites y selecciona las animaciones y vuélvelas a arrastrar sobre el objeto PlayerObject de la vista Hierarchy.
- Seleccionar el objeto Main Camera y establecer la propiedad size a 1.
 Presionar el botón Play
- Desafío
- Ahora crear y guardar las animaciones para nuestro EnemyWalk_1 y Animaciones
EnemyIdle_1. Cada una de estas animaciones contiene cinco sprites cada. Nombra las
animaciones: enemy-walk-1 y enemy-idle-1. Rebautizar EnemyObject Animation
Controller a EnemyController y muévalo a la subcarpeta Animaciones ➤ Controladores.
Mueve las animaciones enemigas a la subcarpeta Animaciones ➤ Animaciones.
Animaciones del enemigo
- Controllers del enemigo y player.
- Resultado Final











## License
[MIT](https://github.com/website-templates/portfolio_one-page-template/blob/master/LICENSE.md)
