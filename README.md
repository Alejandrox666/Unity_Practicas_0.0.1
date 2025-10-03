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


## License
[MIT](https://github.com/website-templates/portfolio_one-page-template/blob/master/LICENSE.md)
