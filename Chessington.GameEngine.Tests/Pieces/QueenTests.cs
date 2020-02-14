﻿using System.Collections.Generic;
 using Chessington.GameEngine.Pieces;
 using NUnit.Framework;

 namespace Chessington.GameEngine.Tests.Pieces
 {
     [TestFixture]
     public class QueenTests
     {
         private Board _board;
         private Piece _king;
         private List<Square> _moveList; 

         [SetUp]
         public void SetUp()
         {
             _board = new Board();
             _king = new King(Player.Black);
             _moveList = new List<Square>();
         }
     }
 }