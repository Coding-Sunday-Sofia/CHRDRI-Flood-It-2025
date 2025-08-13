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
	private static readonly Random PRNG = new Random();

	private static Tile[] colors = {
		new Tile(' '), 
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
		for(int w=0; w<Width; w++) {
			tiles[w] = new Tile[ Height ];
		}
		for(int w=0; w<Width; w++) {
			for(int h=0; h<Height; h++) {
				tiles[w][h] = colors[0];
			}
		}
	}

	public void reset() {
		for(int h=0; h<Height; h++) {
			for(int w=0; w<Width; w++) {
				int index = PRNG.Next(1, colors.Length-1);
				tiles[w][h] = colors[ index ];
			}
		}
		
		while(tiles[0][0] == tiles[Width-1][Height-1]) {
			int index = PRNG.Next(1, colors.Length-1);
			tiles[0][0] = colors[ index ];
		}
	}
	
	public override string ToString(){
		string result = "";
		
		for(int h=0; h<Height; h++) {
			for(int w=0; w<Width; w++) {
				result += tiles[w][h];
			}
			result += "\n";
		}
		
		for(int c=1; c<colors.Length; c++) {
			bool used = false;

			if(tiles[0][0] == colors[c]) {
				used = true;
			}
			if(tiles[Width-1][Height-1] == colors[c]) {
				used = true;
			}

			if(used == true) {
				result += "[" + colors[c] + "]";
			} else {		
				result += " " + colors[c] + " ";
			}
		}
		
		return result.Trim();
	}
}

public class Program {
	public static void Main(string[] args) {
		Board board = new Board(13,7);
		board.reset();
		Console.WriteLine(board);
	}
}
