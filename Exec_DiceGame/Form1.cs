using System;

namespace Exec_DiceGame
{
	public partial class Form1 : Form
	{
		private DiceGame game;
		public Form1()
		{
			InitializeComponent();
			label1.Text = String.Empty;
			label2.Text = String.Empty;
			game = new DiceGame();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			game.NewGame();
			label1.Text = game.DisplayNewGameSetUp();
			game.Check();
			label2.Text = game.DisplayGameScore();
		}
	}
	public class DiceGame
	{
		private int dice1;
		private int dice2;
		private int dice3;
		private int dice4;
		private int[] uncheck = new int[4];
		private string result = string.Empty;

		public void NewGame()
		{
			int seed = Guid.NewGuid().GetHashCode();
			Random random = new Random(seed);
			dice1 = random.Next(1, 7);

			seed = Guid.NewGuid().GetHashCode();
			random = new Random(seed);
			dice2 = random.Next(1, 7);

			seed = Guid.NewGuid().GetHashCode();
			random = new Random(seed);
			dice3 = random.Next(1, 7);

			seed = Guid.NewGuid().GetHashCode();
			random = new Random(seed);
			dice4 = random.Next(1, 7);

			uncheck[0] = dice1;
			uncheck[1] = dice2;
			uncheck[2] = dice3;
			uncheck[3] = dice4;
		}
		public string DisplayNewGameSetUp()
		{
			
			return $"{dice1.ToString()} - {dice2.ToString()} - {dice3.ToString()} - {dice4.ToString()}";
		}
		public void Check()
		{
			int count = 0;
			int[] result = new int[3];
			int resulttag = 0;
			Array.Sort(uncheck);
			for (int i = 0; i < uncheck.Length - 1; i++)
			{
				if (uncheck[i] == uncheck[i + 1]) count++;
			}

			
			if (count == 0)
			{
				this.result = "四個數字都不相同\r\n請重新骰過";
				//ReRoll();
				//DisplayGameScore();
				//while (true)
				//{
				//	ReRoll();
				//	Check();
				//}
			}
			else
			{
				for (int i = 0; i < uncheck.Length - 1; i++)
				{
					result[i] = uncheck[i] * 10 + uncheck[i + 1];
				}
				if (result[0] % 11 == 0) resulttag = 1;
				else if (result[1] % 11 == 0) resulttag = 2;
				else if (result[2] % 11 == 0) resulttag = 3;

				if (resulttag == 1) this.result = $"得分是{uncheck[2] + uncheck[3]}";
				else if (resulttag == 2) this.result = $"得分是{uncheck[0] + uncheck[3]}";
				else if (resulttag == 3) this.result = $"得分是{uncheck[0] + uncheck[1]}";
				else this.result = "I'm Batman.";
			}
			
		}
		public void ReRoll()
		{
			int seed = Guid.NewGuid().GetHashCode();
			Random random = new Random(seed);
			dice1 = random.Next(1, 7);

			seed = Guid.NewGuid().GetHashCode();
			random = new Random(seed);
			dice2 = random.Next(1, 7);

			seed = Guid.NewGuid().GetHashCode();
			random = new Random(seed);
			dice3 = random.Next(1, 7);

			seed = Guid.NewGuid().GetHashCode();
			random = new Random(seed);
			dice4 = random.Next(1, 7);
		}
		public string DisplayGameScore()
		{
			return this.result;
		}
	}
}