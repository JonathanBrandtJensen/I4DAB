using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2._1
{
    class Program
    {
        static void Main(string[] args)
        {
	        int key = 0;
	        while (key != 9)
	        {
		        MainMenu.Show();
				key = 0;
				string keyStr = Console.ReadLine();
		        key = int.Parse(keyStr);

				switch (key)
				{
					case 1:
					{
						ContactListMenu.Show();
						while (Console.ReadLine() != "e")
						{
							
						}
						break;
					}

					case 2:
					{
						SearchContactMenu.Show();
						break;
					}

					case 3:
					{
						AddContactMenu.Show();
						break;
					}

					case 9:
						break;

					default:
						break;
				}
	        }
        }
    }
}
