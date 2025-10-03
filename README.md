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
- [Player Animations 2D Tutorial 01:](#Player Animations 2D Tutorial 01)

## Folder and file structure

```
./
├── Assets/                                      
│   ├── Animations/                                  
|   |   ├── Animations/                          
|   │   ├── Controllers/                                         
|   │
│   ├── Scenes/                                    
|   ├── Sprites/                                 
|   |   ├── Enemies/                            
|   │   ├── Player/                           
|   │                               
│
└── Packages/                                     

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
  
  <img width="1033" height="569" alt="image" src="https://github.com/user-attachments/assets/4103bd21-c503-4dd9-a138-a68fc363695b" />

- Abrir el IDE de Unity, crear dos objetos vacíos mediante la vista Hierarchy opción crear
qué se encuentra en la esquina superior izquierda. Renombra los objetos como
PlayerObject y EnemyObject.

<img width="405" height="505" alt="image" src="https://github.com/user-attachments/assets/0e1b9724-3f7b-4e20-8779-0a08bbda629b" />

- Para el objeto PlayerObject selecciona la opción Add Component | Sprite Renderer.

  <img width="1098" height="464" alt="image" src="https://github.com/user-attachments/assets/5c197e66-eb00-445e-9070-e0d8f2f7bca4" />

Utiliza el mismo proceso para el objeto EnemyObject.

<img width="1098" height="464" alt="image" src="https://github.com/user-attachments/assets/35a06a0e-530e-4037-9783-eff166ff7d0a" />


- Guarda la escena como LevelOne, primeramente crea un folder llamado Scenes y dentro de ella guarda.

<img width="1045" height="744" alt="image" src="https://github.com/user-attachments/assets/748e2a4f-aec9-4e59-afaf-8213a0d64347" />

- Descargar el archivo de imágenes qué viene junto al tutorial, selecciona el archivo Player.png, EnemyIdle_1.png, EnemyWalk_1.png y arrastrarlos al folder correspondiente dentro de la carpeta sprites
- Cambiar las propiedades del objeto Player.png dentro de la vista Inspector tal como lo muestra la siguiente imagen, verificalo y después da clic en Apply.

<img width="1098" height="518" alt="image" src="https://github.com/user-attachments/assets/c7ffa1c6-d0a8-4c0a-b7d3-3fa32ac254cf" />


- Ubica la opción Window|2D|Sprite Editor de la vista Inspector para dividir la hoja de sprites en inviduales. Presiona el botón Slice de la esquina superior izquierda y cambia las propiedades como muestra la siguiente imagen, una vez qué termines de modificar las propiedades presiona el botón de la parte inferior derecha del cuadro de diálogo.
- Ahora presione el botón "Apply" para aplicar el corte a la hoja de sprites. Cerrar el Editor de Sprite.

<img width="672" height="602" alt="image" src="https://github.com/user-attachments/assets/81e3c394-3578-4ef2-ab0f-990f952e74b3" />


- Pongamos estos sprites a trabajar. Seleccione el PlayerObject. En la vista Inspector, a la derecha de la propiedad Sprite verá un pequeño círculo, selecciona un sprite para cuando estamos en la vista Game.

<img width="1098" height="535" alt="image" src="https://github.com/user-attachments/assets/58402be5-dc61-490d-9054-828c2be576cf" />


- Slice del enemigo.

<img width="1098" height="511" alt="image" src="https://github.com/user-attachments/assets/8a1fb5ad-0b46-4079-a436-6ffca7715f8a" />


- Expanda los sprites del Player haciendo clic en la pequeña flecha junto a él en el Vista de proyecto. Selecciona los cuatro primeros sprites con tecla Ctrl + clic izquierdo del ratón
- Arrastra los sprites seleccionados sobre el objeto PlayerObject.
-	Guarda la animación en la carpeta Animaciones y nombrar como player-walk-east.

<img width="1075" height="463" alt="image" src="https://github.com/user-attachments/assets/701ec338-f391-4922-904d-e6d037873dfd" />


-	Ahora seleccione PlayerObject y observe la vista del Inspector. Observa cómo tenemos dos componentes nuevos : Sprite Renderer y Animator. Un componente Sprite Renderer es responsable de mostrar o renderizar un sprite. Unity también agregó un componente Animator, qué contiene un Animator Controller, que permite la reproducción de animaciones.
- Renombra el controller como PlayerController y arrastralo a la carpeta
Animations|Controllers.

<img width="1098" height="886" alt="image" src="https://github.com/user-attachments/assets/90d53eed-03c2-47b8-b523-79b68787d640" />


- Agreguemos el resto de nuestras animaciones. Vuelve a la carpeta Sprites y selecciona las animaciones y vuélvelas a arrastrar sobre el objeto PlayerObject de la vista Hierarchy.

<img width="1098" height="534" alt="image" src="https://github.com/user-attachments/assets/32a1b7c5-346f-4020-aef0-40bef8c56ea6" />


- Seleccionar el objeto Main Camera y establecer la propiedad size a 1.
 Presionar el botón Play.

<img width="1098" height="439" alt="image" src="https://github.com/user-attachments/assets/993ba647-6215-4a4c-896e-0c57c9493895" />


- Desafío

- Ahora crear y guardar las animaciones para nuestro EnemyWalk_1 y Animaciones
EnemyIdle_1. Cada una de estas animaciones contiene cinco sprites cada. Nombra las
animaciones: enemy-walk-1 y enemy-idle-1. Rebautizar EnemyObject Animation
Controller a EnemyController y muévalo a la subcarpeta Animaciones ➤ Controladores.
Mueve las animaciones enemigas a la subcarpeta Animaciones ➤ Animaciones.
Animaciones del enemigo
<img width="1098" height="286" alt="image" src="https://github.com/user-attachments/assets/e861ebcf-7b3e-4b5d-a4ba-ba05f194fda4" />


- Controllers del enemigo y player.

<img width="809" height="1042" alt="image" src="https://github.com/user-attachments/assets/28c4863e-74e0-4ff8-b67c-39fc280e98b7" />


- Resultado Final

Link de video:

https://drive.google.com/file/d/1IfTfOp4qSTgwEd1WWyECRa-A-8ycgUiF/view?usp=sharing








## License
[MIT](https://github.com/website-templates/portfolio_one-page-template/blob/master/LICENSE.md)
