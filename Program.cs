/* clear && dotnet build && dotnet run */

class Tile {
	private char symbol;
	
	public char Symbol {
		get {return symbol;}
		set {symbol = value;}
	}
	
	public Tile(char symbol) {
		Symbol = symbol;
	}
	
	public override string ToString(){
		return "" + Symbol;
	}
}

class Board {
	private static Tile[] colors = {
		new Tile('@'), 
		new Tile('#'), 
		new Tile('$'), 
		new Tile('%'), 
		new Tile('&'), 
		new Tile('*'), 
		new Tile('+'), 
	};
	
	private int width;
	
	private int height;
	
	private Tile[][] tiles = null;
	
	public int Width {
		get {return width;}
		set {width = value;}
	}
	
	public int Height {
		get {return height;}
		set {height = value;}
	}
	
	public Board(int width, int height) {
		Width = width;
		Height = height;
		tiles = new Tile[Width][];
	}
}

public class Program {
	public static void Main(string[] args) {
		Tile t1 = new Tile('#');
		Console.WriteLine(t1);
	}
}
