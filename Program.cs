/* clear && dotnet build && dotnet run */
/* clear && astyle --recursive --style=java --indent=tab *.cs */

class Tile {
	private char symbol;

	public char Symbol {
		get {
			return symbol;
		}
		set {
			symbol = value;
		}
	}

	public Tile(char symbol) {
		Symbol = symbol;
	}

	public override string ToString() {
		return "" + Symbol;
	}
}

class Player {
	private string name;

	private int score;

	public Player(string name) {
		Score = 0;
		Name = name;
	}

	public string Name {
		get {
			return name;
		}
		set {
			name = value;
		}
	}

	public int Score {
		get {
			return score;
		}
		set {
			score = value;
		}
	}

	public override string ToString() {
		return "" + Name;
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

	private Player[] players = {new Player("Gosho"), new Player("Pesho")};

	private int turn;

	public int Width {
		get {
			return width;
		}
		set {
			width = value;
		}
	}

	public int Height {
		get {
			return height;
		}
		set {
			height = value;
		}
	}

	private void show() {
		for(int i=0; i<100; i++) {
			Console.WriteLine();
		}
		Console.Write(this + " ");
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
		turn = 0;
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

		turn = 0;
	}

	private void flood(int w, int h, int color) {
	}

	private bool play(char action) {
		bool found = false;
		foreach(Tile tile in colors) {
			if(tile.Symbol == action) {
				found = true;
				break;
			}
		}

		if(found == false) {
			return false;
		}

		if(action == ' ') {
			return false;
		}

		if(action == tiles[0][0].Symbol) {
			return false;
		}

		if(action == tiles[Width-1][Height-1].Symbol) {
			return false;
		}

		switch(turn % players.Length) {
		case 0:
			flood(0, 0, action);
			break;
		case 1:
			flood(Width-1, Height-1, action);
			break;
		}

		turn++;

		return true;
	}

	public void run() {
		char action = ' ';
		while(true) {
			show();
			action = Console.ReadLine()[0];

			if(action != 'q') {
				break;
			}

			play(action);
		}
	}

	public override string ToString() {
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
		result += "\n";
		result += "Player " + players[ turn%players.Length ] + " turn: ";

		return result.Trim();
	}
}

public class Program {
	public static void Main(string[] args) {
		Board board = new Board(13,7);
		board.reset();
		board.run();
	}
}

