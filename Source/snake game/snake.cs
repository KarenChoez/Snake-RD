using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace snake_game
{
   public class snake
   {
       private Rectangle[] snakeRec;// la serpiente
       private SolidBrush pincel; // "pincel" con el que se pinta 
       private int x, y, width, height;// coordenadas y posicion
      
       public Rectangle[] SnakeRec // returna la serpiente actual
       {
           get { return snakeRec; }
       
       
       }

       public snake()
       {
           snakeRec = new Rectangle[3];// tamaño inicial de la serpiente
           pincel = new SolidBrush(Color.Black);// color de la serpiente

           x = 20;
           y = 0;
           width = 10;
           height = 10;
           for (int i = 0; i < snakeRec.Length; i++) // creacion de cada rectangulo que comprende ala serpiente
           {
               snakeRec[i] = new Rectangle(x, y, width, height);
               x -= 10;
           }
       }
       public void dibujaSnake(Graphics papel) // dibuja ala serpiente en el "papel" (campo de juego)
       {
           foreach (Rectangle rec in snakeRec)
           {
               papel.FillRectangle(pincel, rec);
           }
       }

       public void dibujaSnake() // dibuja ala serpiente en el "papel" (campo de juego) -- REPOCISIONA
       
       {
           for (int i = snakeRec.Length - 1; i > 0; i--)
           {
               snakeRec[i] = snakeRec[i - 1];
           }
       }

       // movimiento de la serpiente
       public void movimientoabajo()// pocisiona la cabeza hacia abajo
       {
           dibujaSnake();
           snakeRec[0].Y += 10; 
       }
       public void movimientoarriba()// pocisiona la cabeza hacia arriba
       {
           dibujaSnake();
           snakeRec[0].Y -= 10;
       }
       public void movimientoizquierda()// pocisiona la cabeza hacia la izquierda
       {
           dibujaSnake();
           snakeRec[0].X -= 10;
       }
       public void movimientoderecha()// pocisiona la cabeza hacia la derecha
       {
           dibujaSnake();
           snakeRec[0].X += 10;
       }
       public void crecimientodeSnake()// agrega un rectangulo mas ala serpiente
       {
           List<Rectangle> rec = snakeRec.ToList();
           rec.Add(new Rectangle(snakeRec[snakeRec.Length-1].X,snakeRec[snakeRec.Length-1].Y,width,height));
           snakeRec = rec.ToArray();
       
       }
    }
}
