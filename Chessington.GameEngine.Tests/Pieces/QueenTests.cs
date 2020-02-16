﻿using System.Collections.Generic;
 using Chessington.GameEngine.Pieces;
 using NUnit.Framework;

 namespace Chessington.GameEngine.Tests.Pieces
 {
     [TestFixture]
     public class QueenTests
     {
         private Board _board;
         private Piece _queen;
         private List<Square> _moveList; 

         [SetUp]
         public void SetUp()
         {
             _board = new Board();
             _queen = new Queen(Player.Black);
             _moveList = new List<Square>();
         }
     }
 }