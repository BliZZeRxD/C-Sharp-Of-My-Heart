using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

namespace Serialization{

class MainClass{
	public static void Main(string[] args){
		Student student = new Student();
		Console.ReadKey();
		ConsoleKeyInfo keyInfo = Console.ReadKey();

		if (keyInfo.Key == ConsoleKey.Enter){

		XmlSerializer save = new XmlSerializer(typeof(Student));
		FileStream fs = new FileStream("save.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
		save.Serialize(fs, student);
		fs.Close();
		}

		if (keyInfo.Key == ConsoleKey.Escape){

		XmlSerializer save = new XmlSerializer(typeof(Student));
		FileStream fs = new FileStream("save.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
		student = save.Deserialize(fs) as Student;
		fs.Close();
		student.Show();
		}
	}
}

[Serializable]
	public class Student{

	public double ID;
	public string Name;

		public void Data(){

			ID = Convert.ToDouble(Console.ReadLine());
			Name = Convert.ToString(Console.ReadLine());
		}
		public void Show(){

			Console.Clear();
			Console.WriteLine(ID);
			Console.WriteLine(Name);
			Console.WriteLine("Done");
		}
	}
}