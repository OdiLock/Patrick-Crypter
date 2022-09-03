using System;
using System.Windows.Forms;

namespace Patrick_Jane_Crypter_Builder
{
	static class Program
	{
		/// <summary>
		/// Uygulamanın ana girdi noktası.
		/// </summary>
		[STAThread]
		static void Main()
		{

            

            Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());



        }

    }
}
