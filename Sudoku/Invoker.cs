﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Invoker
    {

		static Stack<Command> undoStack = new Stack<Command>();
		static Stack<Command> redoStack = new Stack<Command>();
		
		public static void DoCommand(Command command)
		{
			command.Execute();
			undoStack.Push(command);
			redoStack.Clear();
		}

		public static void Undo()
		{
			if (undoStack.Count == 0)
				return;
			Command command = undoStack.Pop();
			command.Undo();
			redoStack.Push(command);
		}

		public static void Redo()
		{
			if (redoStack.Count == 0)
				return;
			Command command = redoStack.Pop();
			command.Execute();
			undoStack.Push(command);
		}
	}

}
