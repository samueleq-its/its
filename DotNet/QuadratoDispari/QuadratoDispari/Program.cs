/* 1 = 1
 * 4 = 1 + 3
 * 9 = 1 + 3 + 5
 * 16 = 1 + 3 + 5 + 7
 * 25 = 1 + 3 + 5 + 7 + 9
 */

// input = n
// output => n^2 = 1 + 3 + 5 + 7 + 9 + ...

// gestire 0 e num negativo

Console.Write("n:");
int n = int.Parse(Console.ReadLine());

int quadrato = n * n;

string dispari = "";
for (int i = 0; i < n; i++)
{
	dispari += $" + {i*2+1}";
}

Console.Write($"{quadrato} =" + dispari.Substring(2));