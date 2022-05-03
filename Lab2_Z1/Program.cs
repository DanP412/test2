using System;
using System.Collections.Generic;

int n;
int m;
int num;
string key;
string[] map = new string[101];

n = int.Parse(Console.ReadLine());

for (int tests = 0; tests < n; tests++)

{
	m = int.Parse(Console.ReadLine());
	num = 0;

	for (int i = 0; i < 101; i++)
		map[i] = "";
	for (int opp = 0; opp < m; opp++)
	{
		var o = Console.ReadLine().Split(':');
		if (o[0] == "ADD")
		{
			key = o[1];
			if (add(map, key))
				num++;
		}
		else if (o[0] == "DEL")
		{
			key = o[1];
			if (del(map, key))
				num--;
		}
	}
	Console.WriteLine(num);
	for (int i = 0; i < 101; i++)
	{
		if (map[i] != "")
			Console.WriteLine(i + ":" + map[i]);
	}
}

static bool add(string[] map, string key)
{
	int h;
	int hash;
	int new_hash;
	h = 0;

	for (int i = 0; i < key.Length; i++)
	{
		h += (int)key[i] * (i + 1);
	}

	hash = (h * 19) % 101;

	if (map[hash] == key)
	{
		return false;
	}
	else
	{
		for (int j = 1; j <= 19; j++)
		{
			new_hash = (hash + (23 * j) + (j * j)) % 101;

			if (map[new_hash] == key)
			{
				return false;
			}
		}
	}
	if (map[hash] == "")
	{
		map[hash] = key;
		return true;
	}
	for (int j = 1; j <= 19; j++)
	{
		new_hash = (hash + (j * j) + (23 * j)) % 101;

		if (map[new_hash] == "")
		{
			map[new_hash] = key;
			return true;
		}
	}
	return false;
}

static bool del(string[] map, string key)
{
	for (int i = 0; i < 101; i++)
	{
		if (map[i] == key)
		{
			map[i] = "";
			return true;
		}
	}

	return false;

}



