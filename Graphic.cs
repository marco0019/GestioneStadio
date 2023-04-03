using System;
using System.Threading;

namespace GestioneCampionato
{
	class Graphic
	{
		static string border = "═║╚╝╗╔";
		public static void WindowSize(int width, int height)
		{
			Console.SetWindowPosition(0, 0);
			Console.SetWindowSize(width, height);
			Console.SetBufferSize(width, height);/*
			if (Console.WindowWidth > width)
			{
				Console.SetWindowSize(width, height);
				Console.SetBufferSize(width, height);
			}
			else
			{
				Console.SetWindowSize(width, height);
				Console.SetBufferSize(width, height);
			}*/
		}
		public static void Rect(int x, int y, string text="  ", ConsoleColor bg=ConsoleColor.Black, ConsoleColor fg = ConsoleColor.Black, bool setBG= true)
		{
			Console.ResetColor();
			if (setBG) Console.BackgroundColor = bg;
			Console.ForegroundColor = fg;
			try
			{
				Console.SetCursorPosition(x, y);
				Console.Write(text);
			}
			catch(Exception ex)
			{
			}
			Console.ResetColor();
		}
		public static void Corner(int x, int y, int width, int height, ConsoleColor fg, int delay=0, bool setSize=false)
		{
			if(setSize)WindowSize(width + x + 2, height + y + 1);
			Console.CursorVisible = false;
			Rect(x, y, border[5].ToString(), fg: fg, setBG: false);
			Line(x, y + 1, height - 1, true, fg, delay);
			Rect(x, y + height, border[2].ToString(), fg: fg, setBG: false);
			Line(x + 1, y + height, width - 1, false, fg, delay);
			Line(x + 1, y, width - 1, false, fg, delay);
			Rect(x + width, y, border[4].ToString(), fg: fg, setBG: false);
			Line(x + width, y + 1, height - 1, true, fg, delay);
			Rect(x + width, y + height, border[3].ToString(), fg: fg, setBG: false);
		}
		static void Line(int x, int y, int size, bool vertical, ConsoleColor fg, int delay)
		{
			for (int i = 0; i < size; i++)
			{
				Rect(x + Convert.ToInt16(!vertical) * i, y + Convert.ToInt16(vertical) * i, border[Convert.ToInt16(vertical)].ToString(), fg: fg, setBG: false);
				Thread.Sleep(delay);
			}
		}
		public static int Word(int x, int y, string text, int font = 0, ConsoleColor fg = ConsoleColor.White, int delay = 0)
		{
			int posX = x;
			for (int i = 0; i < text.Length; i++) DrawLetter(ref x, y, Index(text[i]), font, UpperCase(text[i]), fg, delay);
			return x - posX;
		}
		static void DrawLetter(ref int x, int y, int index, int font, bool upperCase = false, ConsoleColor fg = ConsoleColor.White, int delay = 0)
		{
			string[][,] fonts ={new string[,]{{"          ", "          ", "  ______  ", " |      \\ ", "  \\▓▓▓▓▓▓\\", " /      ▓▓", "|  ▓▓▓▓▓▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓▓", "          ", "          ", "          " },{" __       ", "|  \\      ", "| ▓▓____  ", "| ▓▓    \\ ", "| ▓▓▓▓▓▓▓\\", "| ▓▓  | ▓▓", "| ▓▓__/ ▓▓", "| ▓▓    ▓▓", " \\▓▓▓▓▓▓▓ ", "          ", "          ", "          " },{"          ", "          ", "  _______ ", " /       \\", "|  ▓▓▓▓▓▓▓", "| ▓▓      ", "| ▓▓_____ ", " \\▓▓     \\", "  \\▓▓▓▓▓▓▓", "          ", "          ", "          " },{"       __ ", "      |  \\", "  ____| ▓▓", " /      ▓▓", "|  ▓▓▓▓▓▓▓", "| ▓▓  | ▓▓", "| ▓▓__| ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓▓", "          ", "          ", "          " },{"          ", "          ", "  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓    ▓▓", "| ▓▓▓▓▓▓▓▓", " \\▓▓     \\", "  \\▓▓▓▓▓▓▓", "          ", "          ", "          " },{"  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓_  \\▓▓", "| ▓▓ \\    ", "| ▓▓▓▓    ", "| ▓▓      ", "| ▓▓      ", " \\▓▓      ", "          ", "          ", "          " },{"          ", "          ", "  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓  | ▓▓", "| ▓▓__| ▓▓", " \\▓▓    ▓▓", " _\\▓▓▓▓▓▓▓", "|  \\__| ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓ " },{" __       ", "|  \\      ", "| ▓▓____  ", "| ▓▓    \\ ", "| ▓▓▓▓▓▓▓\\", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", " \\▓▓   \\▓▓", "          ", "          ", "          " },{" __ ", "|  \\", " \\▓▓", "|  \\", "| ▓▓", "| ▓▓", "| ▓▓", "| ▓▓", " \\▓▓", "    ", "    ", "    " },{"          ", "          ", "       __ ", "      |  \\", "       \\▓▓", "      |  \\", "      | ▓▓", "      | ▓▓", " __   | ▓▓", "|  \\__/ ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓ " },{" __       ", "|  \\      ", "| ▓▓   __ ", "| ▓▓  /  \\", "| ▓▓_/  ▓▓", "| ▓▓   ▓▓ ", "| ▓▓▓▓▓▓\\ ", "| ▓▓  \\▓▓\\", " \\▓▓   \\▓▓", "          ", "          ", "          " },{" __ ", "|  \\", "| ▓▓", "| ▓▓", "| ▓▓", "| ▓▓", "| ▓▓", "| ▓▓", " \\▓▓", "    ", "    ", "    " },{"              ", "              ", " ______ ____  ", "|      \\    \\ ", "| ▓▓▓▓▓▓\\▓▓▓▓\\", "| ▓▓ | ▓▓ | ▓▓", "| ▓▓ | ▓▓ | ▓▓", "| ▓▓ | ▓▓ | ▓▓", " \\▓▓  \\▓▓  \\▓▓", "              ", "              ", "              " },{"          ", "          ", " _______  ", "|       \\ ", "| ▓▓▓▓▓▓▓\\", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", " \\▓▓   \\▓▓", "          ", "          ", "          " },{"          ", "          ", "  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓  | ▓▓", "| ▓▓__/ ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓ ", "          ", "          ", "          " },{"          ", "          ", "  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓  | ▓▓", "| ▓▓__/ ▓▓", "| ▓▓    ▓▓", "| ▓▓▓▓▓▓▓ ", "| ▓▓      ", "| ▓▓      ", " \\▓▓      " },{"          ", "          ", "  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓  | ▓▓", "| ▓▓__| ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓▓", "      | ▓▓", "      | ▓▓", "       \\▓▓" },{"          ", "          ", "  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓   \\▓▓", "| ▓▓      ", "| ▓▓      ", " \\▓▓      ", "          ", "          ", "          " },{"          ", "          ", "  _______ ", " /       \\", "|  ▓▓▓▓▓▓▓", " \\▓▓    \\ ", " _\\▓▓▓▓▓▓\\", "|       ▓▓", " \\▓▓▓▓▓▓▓ ", "          ", "          ", "          " },{"   __     ", "  |  \\    ", " _| ▓▓_   ", "|   ▓▓ \\  ", " \\▓▓▓▓▓▓  ", "  | ▓▓ __ ", "  | ▓▓|  \\", "   \\▓▓  ▓▓", "    \\▓▓▓▓ ", "          ", "          ", "          " },{"          ", "          ", " __    __ ", "|  \\  |  \\", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", "| ▓▓__/ ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓ ", "          ", "          ", "          " },{"           ", "           ", " __     __ ", "|  \\   /  \\", " \\▓▓\\ /  ▓▓", "  \\▓▓\\  ▓▓ ", "   \\▓▓ ▓▓  ", "    \\▓▓▓   ", "     \\▓    ", "           ", "           ", "           " },{"              ", "              ", " __   __   __ ", "|  \\ |  \\ |  \\", "| ▓▓ | ▓▓ | ▓▓", "| ▓▓ | ▓▓ | ▓▓", "| ▓▓_/ ▓▓_/ ▓▓", " \\▓▓   ▓▓   ▓▓", "  \\▓▓▓▓▓\\▓▓▓▓ ", "              ", "              ", "              " },{"          ", "          ", " __    __ ", "|  \\  /  \\", " \\▓▓\\/  ▓▓", "  >▓▓  ▓▓ ", " /  ▓▓▓▓\\ ", "|  ▓▓ \\▓▓\\", " \\▓▓   \\▓▓", "          ", "          ", "          " },{"          ", "          ", " __    __ ", "|  \\  |  \\", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", "| ▓▓__/ ▓▓", " \\▓▓    ▓▓", " _\\▓▓▓▓▓▓▓", "|  \\__| ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓ " },{"          ", "          ", " _______", "|        \\", " \\▓▓▓▓▓▓▓▓", "  /    ▓▓ ", " /  ▓▓▓▓_ ", "|  ▓▓    \\", " \\▓▓▓▓▓▓▓▓", "          ", "          ", "          " }, { "          ", "          ", "          ", "          ", "          ", "          ", "          ", "          ", "          ", "          ", "          ", "          " }, { "  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓▓\\| ▓▓", "| ▓▓▓▓\\ ▓▓", "| ▓▓\\▓▓\\▓▓", "| ▓▓_\\▓▓▓▓", " \\▓▓  \\▓▓▓", "  \\▓▓▓▓▓▓ ", "          ", "          ", "          " },{ "   __   ", " _/  \\  ", "|   ▓▓  ", " \\▓▓▓▓  ", "  | ▓▓  ", "  | ▓▓  ", " _| ▓▓_ ", "|   ▓▓ \\", " \\▓▓▓▓▓▓", "        ", "        ", "        "},{"  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", " \\▓▓__| ▓▓", " /      ▓▓", "|  ▓▓▓▓▓▓ ", "| ▓▓_____ ", "| ▓▓     \\", " \\▓▓▓▓▓▓▓▓", "          ", "          ", "          " },{"  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", " \\▓▓__| ▓▓", "  |     ▓▓", " __\\▓▓▓▓▓\\", "|  \\__| ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓ ", "          ", "          ", "          " },{" __    __ ", "|  \\  |  \\", "| ▓▓  | ▓▓", "| ▓▓__| ▓▓", "| ▓▓    ▓▓", " \\▓▓▓▓▓▓▓▓", "      | ▓▓", "      | ▓▓", "       \\▓▓", "          ", "          ", "          " },{" _______  ", "|       \\ ", "| ▓▓▓▓▓▓▓ ", "| ▓▓____  ", "| ▓▓    \\ ", " \\▓▓▓▓▓▓▓\\", "|  \\__| ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓ ", "          ", "          ", "          " },{"  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓___\\▓▓", "| ▓▓    \\ ", "| ▓▓▓▓▓▓▓\\", "| ▓▓__/ ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓ ", "          ", "          ", "          " },{" ________ ", "|        \\", " \\▓▓▓▓▓▓▓▓", "    /  ▓▓ ", "   /  ▓▓  ", "  /  ▓▓   ", " /  ▓▓    ", "|  ▓▓     ", " \\▓▓      ", "          ", "          ", "          " },{"  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓__/ ▓▓", " >▓▓    ▓▓", "|  ▓▓▓▓▓▓ ", "| ▓▓__/ ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓ ", "          ", "          ", "          " },{"  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓__/ ▓▓", " \\▓▓    ▓▓", " _\\▓▓▓▓▓▓▓", "|  \\__/ ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓ ", "          ", "          ", "          " },{"  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓__| ▓▓", "| ▓▓    ▓▓", "| ▓▓▓▓▓▓▓▓", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", " \\▓▓   \\▓▓", "          ", "          ", "          " },{" _______  ", "|       \\ ", "| ▓▓▓▓▓▓▓\\", "| ▓▓__/ ▓▓", "| ▓▓    ▓▓", "| ▓▓▓▓▓▓▓\\", "| ▓▓__/ ▓▓", "| ▓▓    ▓▓", " \\▓▓▓▓▓▓▓ ", "          ", "          ", "          " },{"  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓   \\▓▓", "| ▓▓      ", "| ▓▓   __ ", "| ▓▓__/  \\", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓ ", "          ", "          ", "          " },{" _______  ", "|       \\ ", "| ▓▓▓▓▓▓▓\\", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", "| ▓▓__/ ▓▓", "| ▓▓    ▓▓", " \\▓▓▓▓▓▓▓ ", "          ", "          ", "          " },{" ________ ", "|        \\", "| ▓▓▓▓▓▓▓▓", "| ▓▓__    ", "| ▓▓  \\   ", "| ▓▓▓▓▓   ", "| ▓▓_____ ", "| ▓▓     \\", " \\▓▓▓▓▓▓▓▓", "          ", "          ", "          " },{" ________ ", "|        \\", "| ▓▓▓▓▓▓▓▓", "| ▓▓__    ", "| ▓▓  \\   ", "| ▓▓▓▓▓   ", "| ▓▓      ", "| ▓▓      ", " \\▓▓      ", "          ", "          ", "          " },{"  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓ __\\▓▓", "| ▓▓|    \\", "| ▓▓ \\▓▓▓▓", "| ▓▓__| ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓ ", "          ", "          ", "          " },{" __    __ ", "|  \\  |  \\", "| ▓▓  | ▓▓", "| ▓▓__| ▓▓", "| ▓▓    ▓▓", "| ▓▓▓▓▓▓▓▓", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", " \\▓▓   \\▓▓", "          ", "          ", "          " },{" ______ ", "|      \\", " \\▓▓▓▓▓▓", "  | ▓▓  ", "  | ▓▓  ", "  | ▓▓  ", " _| ▓▓_ ", "|   ▓▓ \\", " \\▓▓▓▓▓▓", "        ", "        ", "        " },{"    _____ ", "   |     \\", "    \\▓▓▓▓▓", "      | ▓▓", " __   | ▓▓", "|  \\  | ▓▓", "| ▓▓__| ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓ ", "          ", "          ", "          " },{" __    __ ", "|  \\  /  \\", "| ▓▓ /  ▓▓", "| ▓▓/  ▓▓ ", "| ▓▓  ▓▓  ", "| ▓▓▓▓▓\\  ", "| ▓▓ \\▓▓\\ ", "| ▓▓  \\▓▓\\", " \\▓▓   \\▓▓", "          ", "          ", "          " },{" __       ", "|  \\      ", "| ▓▓      ", "| ▓▓      ", "| ▓▓      ", "| ▓▓      ", "| ▓▓_____ ", "| ▓▓     \\", " \\▓▓▓▓▓▓▓▓", "          ", "          ", "          " },{" __       __ ", "|  \\     /  \\", "| ▓▓\\   /  ▓▓", "| ▓▓▓\\ /  ▓▓▓", "| ▓▓▓▓\\  ▓▓▓▓", "| ▓▓\\▓▓ ▓▓ ▓▓", "| ▓▓ \\▓▓▓| ▓▓", "| ▓▓  \\▓ | ▓▓", " \\▓▓      \\▓▓", "             ", "             ", "             " },{" __    __ ", "|  \\  |  \\", "| ▓▓\\ | ▓▓", "| ▓▓▓\\| ▓▓", "| ▓▓▓▓\\ ▓▓", "| ▓▓\\▓▓ ▓▓", "| ▓▓ \\▓▓▓▓", "| ▓▓  \\▓▓▓", " \\▓▓   \\▓▓", "          ", "          ", "          " },{"  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", "| ▓▓__/ ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓ ", "          ", "          ", "          " },{" _______  ", "|       \\ ", "| ▓▓▓▓▓▓▓\\", "| ▓▓__/ ▓▓", "| ▓▓    ▓▓", "| ▓▓▓▓▓▓▓ ", "| ▓▓      ", "| ▓▓      ", " \\▓▓      ", "          ", "          ", "          " },{"  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", "| ▓▓ _| ▓▓", "| ▓▓/ \\ ▓▓", " \\▓▓ ▓▓ ▓▓", "  \\▓▓▓▓▓▓\\", "      \\▓▓▓", "          ", "          " },{" _______  ", "|       \\ ", "| ▓▓▓▓▓▓▓\\", "| ▓▓__| ▓▓", "| ▓▓    ▓▓", "| ▓▓▓▓▓▓▓\\", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", " \\▓▓   \\▓▓", "          ", "          ", "          " },{"  ______  ", " /      \\ ", "|  ▓▓▓▓▓▓\\", "| ▓▓___\\▓▓", " \\▓▓    \\ ", " _\\▓▓▓▓▓▓\\", "|  \\__| ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓ ", "          ", "          ", "          " },{" ________ ", "|        \\", " \\▓▓▓▓▓▓▓▓", "   | ▓▓   ", "   | ▓▓   ", "   | ▓▓   ", "   | ▓▓   ", "   | ▓▓   ", "    \\▓▓   ", "          ", "          ", "          " },{" __    __ ", "|  \\  |  \\", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", "| ▓▓  | ▓▓", "| ▓▓__/ ▓▓", " \\▓▓    ▓▓", "  \\▓▓▓▓▓▓ ", "          ", "          ", "          " },{" __     __ ", "|  \\   |  \\", "| ▓▓   | ▓▓", "| ▓▓   | ▓▓", " \\▓▓\\ /  ▓▓", "  \\▓▓\\  ▓▓ ", "   \\▓▓ ▓▓  ", "    \\▓▓▓   ", "     \\▓    ", "           ", "           ", "           " },{" __       __ ", "|  \\  _  |  \\", "| ▓▓ / \\ | ▓▓", "| ▓▓/  ▓\\| ▓▓", "| ▓▓  ▓▓▓\\ ▓▓", "| ▓▓ ▓▓\\▓▓\\▓▓", "| ▓▓▓▓  \\▓▓▓▓", "| ▓▓▓    \\▓▓▓", " \\▓▓      \\▓▓", "             ", "             ", "             " },{" __    __ ", "|  \\  |  \\", "| ▓▓  | ▓▓", " \\▓▓\\/  ▓▓", "  >▓▓  ▓▓ ", " /  ▓▓▓▓\\ ", "|  ▓▓ \\▓▓\\", "| ▓▓  | ▓▓", " \\▓▓   \\▓▓", "          ", "          ", "          " },{" __      __ ", "|  \\    /  \\", " \\▓▓\\  /  ▓▓", "  \\▓▓\\/  ▓▓ ", "   \\▓▓  ▓▓  ", "    \\▓▓▓▓   ", "    | ▓▓    ", "    | ▓▓    ", "     \\▓▓    ", "            ", "            ", "            " },{" ________ ", "|        \\", " \\▓▓▓▓▓▓▓▓", "    /  ▓▓ ", "   /  ▓▓  ", "  /  ▓▓   ", " /  ▓▓___ ", "|  ▓▓    \\", " \\▓▓▓▓▓▓▓▓", "          ", "          ", "          " }, { "          ", "          ", "          ", "          ", "          ", "          ", "          ", "          ", "          ", "          ", "          ", "          " }},new string[,]{ { "▄▀█", "█▀█", }, { "█▄▄", "█▄█" }, { "█▀▀", "█▄▄" }, { "█▀▄", "█▄▀" }, { "█▀▀", "██▄" }, { "█▀▀", "█▀░" }, { "█▀▀", "█▄█" }, { "█░█", "█▀█" }, { "█", "█" }, { "░░█", "█▄█" }, { "█▄▀", "█░█" }, { "█░░", "█▄▄" }, { "█▀▄▀█", "█░▀░█" }, { "█▄░█", "█░▀█" }, { "█▀█", "█▄█" }, { "█▀█", "█▀▀" }, { "█▀█", "▀▀█" }, { "█▀█", "█▀▄" }, { "█▀", "▄█" }, { "▀█▀", "░█░" }, { "█░█", "█▄█" }, { "█░█", "▀▄▀" }, { "█░█░█", "▀▄▀▄▀" }, { "▀▄▀", "█░█" }, { "█▄█", "░█░" }, { "▀█", "█▄" }, { "  ", "  "},{" █▀█", " █▄█" },{" ▄█", "  █" },{" ▀█", " █▄" },{" ▀██", " ▄▄█" },{" █▄", "  █" },{" █▄", " ▄█" },{" █▀", " ██" },{" ▀█", "  █" },{" █▄█", " █▄█" },{" ██", " ▄█" },},new string[,]{{" █████╗ ", "██╔══██╗", "███████║", "██╔══██║", "██║  ██║", "╚═╝  ╚═╝" },{"██████╗ ", "██╔══██╗", "██████╔╝", "██╔══██╗", "██████╔╝", "╚═════╝ " },{" ██████╗", "██╔════╝", "██║     ", "██║     ", "╚██████╗", " ╚═════╝" },{"██████╗ ", "██╔══██╗", "██║  ██║", "██║  ██║", "██████╔╝", "╚═════╝ " },{"███████╗", "██╔════╝", "█████╗  ", "██╔══╝  ", "███████╗", "╚══════╝" },{"███████╗", "██╔════╝", "█████╗  ", "██╔══╝  ", "██║     ", "╚═╝     " },{" ██████╗ ", "██╔════╝ ", "██║  ███╗", "██║   ██║", "╚██████╔╝", " ╚═════╝ " },{"██╗  ██╗", "██║  ██║", "███████║", "██╔══██║", "██║  ██║", "╚═╝  ╚═╝" },{"██╗", "██║", "██║", "██║", "██║", "╚═╝" },{"     ██╗", "     ██║", "     ██║", "██   ██║", "╚█████╔╝", " ╚════╝ " },{"██╗  ██", "n██║ ██╔╝", "█████╔╝ ", "██╔═██╗ ", "██║  ██╗", "╚═╝  ╚═╝" },{"██╗     ", "██║     ", "██║     ", "██║     ", "███████╗", "╚══════╝" },{"███╗   ███╗", "████╗ ████║", "██╔████╔██║", "██║╚██╔╝██║", "██║ ╚═╝ ██║", "╚═╝     ╚═╝" },{"███╗   ██╗", "████╗  ██║", "██╔██╗ ██║", "██║╚██╗██║", "██║ ╚████║", "╚═╝  ╚═══╝" },{" ██████╗ ", "██╔═══██╗", "██║   ██║", "██║   ██║", "╚██████╔╝", " ╚═════╝ " },{"██████╗ ", "██╔══██╗", "██████╔╝", "██╔═══╝ ", "██║     ", "╚═╝     " },{" ██████╗ ", "██╔═══██╗", "██║   ██║", "██║▄▄ ██║", "╚██████╔╝", " ╚══▀▀═╝ " },{"██████╗ ", "██╔══██╗", "██████╔╝", "██╔══██╗", "██║  ██║", "╚═╝  ╚═╝" },{"███████╗", "██╔════╝", "███████╗", "╚════██║", "███████║", "╚══════╝" },{"████████╗", "╚══██╔══╝", "   ██║   ", "   ██║   ", "   ██║   ", "   ╚═╝   " },{"██╗   ██╗", "██║   ██║", "██║   ██║", "██║   ██║", "╚██████╔╝", " ╚═════╝ " },{"██╗   ██╗", "██║   ██║", "██║   ██║", "╚██╗ ██╔╝", " ╚████╔╝ ", "  ╚═══╝  " },{"██╗    ██╗", "██║    ██║", "██║ █╗ ██║", "██║███╗██║", "╚███╔███╔╝", " ╚══╝╚══╝ " },{"██╗  ██╗", "╚██╗██╔╝", " ╚███╔╝ ", " ██╔██╗ ", "██╔╝ ██╗", "╚═╝  ╚═╝" },{"██╗   ██╗", "╚██╗ ██╔╝", " ╚████╔╝ ", "  ╚██╔╝  ", "   ██║   ", "   ╚═╝   " },{"███████╗", "╚══███╔╝", "  ███╔╝ ", " ███╔╝  ", "███████╗", "╚══════╝" }, {"        ", "        ", "        ", "        ", "        ", "        "},{" ██████╗ ", "██╔═████╗", "██║██╔██║", "████╔╝██║", "╚██████╔╝", " ╚═════╝ " },{" ██", "n███║", "╚██║", " ██║", " ██║", " ╚═╝" },{"██████╗ ", "╚════██╗", " █████╔╝", "██╔═══╝ ", "███████╗", "╚══════╝" },{"██████╗ ", "╚════██╗", " █████╔╝", " ╚═══██╗", "██████╔╝", "╚═════╝ " },{"██╗  ██╗", "██║  ██║", "███████║", "╚════██║", "     ██║", "     ╚═╝" },{"███████╗", "██╔════╝", "███████╗", "╚════██║", "███████║", "╚══════╝" },{" ██████╗ ", "██╔════╝ ", "███████╗ ", "██╔═══██╗", "╚██████╔╝", " ╚═════╝ " },{"███████╗", "╚════██║", "   ██╔╝ ", "  ██╔╝  ", "  ██║   ", "  ╚═╝   " },{" █████╗ ", "██╔══██╗", "╚█████╔╝", "██╔══██╗", "╚█████╔╝", " ╚════╝ " },{" █████╗ ", "██╔══██╗", "╚██████║", " ╚═══██║", " █████╔╝", " ╚════╝ " },},new string[,]{{"a" },{"b" },{"c" },{"d" },{"e" },{"f" },{"g" },{"h" },{"i" },{"j" },{"k" },{"l" },{"m" },{"n" },{"o" },{"p" },{"q" },{"r" },{"s" },{"t" },{"u" },{"v" },{"w" },{"x" },{"y" },{"z" },{" " },{"0" },{"1" },{"2" },{"3" },{"4" },{"5" },{"6" },{"7" },{"8" },{"9" },{"A" },{"B" },{"C" },{"D" },{"E" },{"F" },{"G" },{"H" },{"I" },{"J" },{"K" },{"L" },{"M" },{"N" },{"O" },{"P" },{"Q" },{"R" },{"S" },{"T" },{"U" },{"V" },{"W" },{"X" },{"Y" },{"Z" },
				}
			};
			int[] sizes = { 12, 2, 6, 1 };
			for (int j = 0; j < fonts[font][font == 0 & upperCase ? index + 37 : index, 0].Length; j++)
				for (int i = 0; i < sizes[font]; i++)
				{ Rect(j + x, i + y, fonts[font][font == 0 & upperCase ? index + 37 : index, i][j].ToString(), setBG: false, fg: fg); Thread.Sleep(delay); }
			x += fonts[font][index, 0].Length + 1;// Incrementa la x così che la lettera non sovrascriva quelle precedenti
		}
		static int Index(char letter)
		{
			const string alphabet = "abcdefghijklmnopqrstuvwxyz 0123456789";
			for (int i = 0; i < alphabet.Length; i++)
				if (alphabet[i].ToString().ToLower() == letter.ToString().ToLower()) return i;
			return -1;
		}
		static bool UpperCase(char letter)
		{
			string alphabet = "abcdefghijklmnopqrstuvwxyz ".ToUpper();
			for (int i = 0; i < alphabet.Length; i++) if (alphabet[i] == letter) return true;
			return false;
		}
		public static void Clear(int type = 0, int delay = 0)
		{
			Console.CursorVisible = false;
			//Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
			//Console.SetWindowPosition(0, 0);
			Action[] transitions =
			{
				delegate ()
				{
					for(int i = 0; i < Console.WindowHeight; i++)
						for(int j = 0; j < Console.WindowWidth; j++){
							Rect(j, i, " ", setBG:false); Thread.Sleep(delay); }
				},
				delegate ()
				{
					for(int i = 0; i < Console.WindowWidth; i++)
						for(int j = 0; j < Console.WindowHeight; j++){
							Rect(i, j, " ", setBG:false); Thread.Sleep(delay); }
				},
				delegate ()
				{
					int[] center = {Console.WindowWidth / 2, Console.WindowHeight / 2};
					for(int radius = 0; radius < (int)Math.Sqrt(Math.Pow(center[0], 2) + Math.Pow(center[1], 2)); radius++)
					{
						for(double angle = 0; angle < Math.PI * 2; angle += Math.PI / 180)
						{
							if(Math.Cos(angle) * radius + center[0] < 0 | Math.Cos(angle) * radius + center[0] >= Console.WindowWidth | Math.Sin(angle) * radius + center[1] < 0 | Math.Sin(angle) * radius + center[1] >= Console.WindowHeight)continue;
							Rect((int)Math.Cos(angle) * radius + center[0], (int)Math.Sin(angle) * radius + center[1], setBG:false);
							Thread.Sleep(delay);
						}
					}
				},
				delegate ()
				{
					for(int i = 0; i < Console.WindowWidth; i++)
						for(int j = 0; j < Console.WindowHeight; j++)
							if((i + j) % 2 == 0)
							{
								Rect(i, j, setBG:false);
								Thread.Sleep(delay);
							}

					for(int i = 0; i < Console.WindowWidth; i++)
						for(int j = 0; j < Console.WindowHeight; j++)
							if((i + j) % 2 != 0)
							{
								Rect(i, j, setBG:false);
								Thread.Sleep(delay);
							}
				}
			};
			transitions[type % transitions.Length]();
			//Console.SetWindowPosition(0, 0);
		}
		public static void Switcher(string title, int x, int y, string[] texts, ref int index, int delay, int font = 0, bool responsive = false, bool center = false)
		{
			int[] lineHeight = { 1, 12, 2, 6, 1 };
			int width = 0;
			if (font != -1) width = Word(x + 3, y + 1, title, font: font, delay: 5) + 4;
			if (width < 50) width = 50;
			Corner(x, y, width, texts.Length + lineHeight[font + 1] + 3, ConsoleColor.White, delay: delay);
			DrawSwitcher(x, y, texts, index, lineHeight[font + 1] + 1, responsive, center, width);
			while (true)
				if (Console.KeyAvailable)
				{
					var key = Console.ReadKey(true).Key;
					if (key == ConsoleKey.W | key == ConsoleKey.UpArrow) { index = index > 0 ? index - 1 : texts.Length - 1; DrawSwitcher(x, y, texts, index, lineHeight[font + 1] + 1, responsive, center, width); }
					if (key == ConsoleKey.S | key == ConsoleKey.DownArrow) { index = index < texts.Length - 1 ? index + 1 : 0; DrawSwitcher(x, y, texts, index, lineHeight[font + 1] + 1, responsive, center, width); }
					if (key == ConsoleKey.Enter | key == ConsoleKey.Spacebar) break;
					if (key == ConsoleKey.LeftArrow | key == ConsoleKey.A) if (index + texts.Length / 2 < texts.Length) index += texts.Length / 2;
					if (key == ConsoleKey.D | key == ConsoleKey.RightArrow) if (index - (texts.Length - texts.Length / 2) > -1) index -= texts.Length - texts.Length / 2;
				}
		}

		static void DrawSwitcher(int x, int y, string[] texts, int index, int lineHeight, bool responsive, bool center, int width)
		{
			ConsoleColor[] color = { ConsoleColor.White, ConsoleColor.Black };
			if (center)
			{
				if (responsive)
					x += (width - 35) < 0 ? 0 : (width - 35) / 2;
				else x += (width - 55) < 0 ? 0 : (width - 55) / 2;
			}
			if(responsive) for (int i = 0; i < texts.Length; i++)
					Rect(x + 2, y + i + lineHeight + 1, StringFormat(i == index ? " <" + texts[i] + ">" : "  " + texts[i], 30, "center"), color[Convert.ToInt16(index != i)], color[Convert.ToInt16(index == i)], setBG: index == i);
			else
			{
				for (int i = 0; i < Math.Round(texts.Length / Convert.ToDouble(2) + .1); i++)
					Rect(x + 2, y + i * 2 + lineHeight + 1, i == index ? " <" + StringFormat(texts[i] + ">", 20) : "  " + StringFormat(texts[i], 20), color[Convert.ToInt16(index != i)], color[Convert.ToInt16(index == i)], setBG: index == i);
				for (int i = (int)Math.Round(texts.Length / Convert.ToDouble(2) + .1); i < texts.Length; i++) Rect(x + 27, y + (i - (int)Math.Round(texts.Length / Convert.ToDouble(2) + .1)) * 2 + lineHeight + 1, i == index ? " <" + StringFormat(texts[i] + ">", 20) : "  " + StringFormat(texts[i], 20), color[Convert.ToInt16(index != i)], color[Convert.ToInt16(index == i)], setBG: index == i);
			}
		}
		static string StringFormat(string text, int target, string textAlign="start")
		{
			int difference = target - text.Length;
			if (textAlign == "start") for (int i = 0; i < difference; i++) text += " ";
			else if (textAlign == "center") for (int i = 0; i < difference; i++) text = i % 2 != 0 ? " " + text : text + " ";
			else if (textAlign == "end") for (int i = 0; i < difference; i++) text = " " + text;
			return text;
		}
	}
}
