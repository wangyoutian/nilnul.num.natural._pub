using System;
using System.IO;
using System.Collections;
namespace nilnul.series
{
	/// <summary>
	/// Fn=
	///		1
	///		/
	///		sqrt5
	///		*
	///		(
	///			(1+sqrt5)/2 )^n
	///			-
	///			((1-sqrt5)/2)^n
	///		)
	/// </summary>
	public class Fibonacci
	{
		static string path;

		static Fibonacci(){
			path=@"fibonacci.txt";
		}

		
		
		public static ulong Call(int n){
			//query in a file for the stocked results.
			
			
			//check in the file..
			Table t=new Table(path);
			if(t.Count<2){
				t.Add(0,0);
				t.Add(1,1);
			}
			if(n<=t.Count-1)
			{
				return ((Table.Record)(t[n])).f;

			}
			else{
				for(int i=t.Count;i<=n;i++){
					try
					{
						t.Add(i,((Table.Record)(t[i-1])).f+((Table.Record)(t[i-2])).f);
					}
					catch(OverflowException e)
					{
						throw new Exception(i.ToString()+" is too big.");
					}
					
					
					
				}
				return ((Table.Record)t[n]).f;
			 }
			

			
			
			
			
			
		}
		public class Table:ArrayList
		{
			
			string path;
			FileStream fsr;
			StreamReader sr;
			FileStream fsw;
			StreamWriter sw;
			

			public Table(string path)
			{
				this.path=path;

				fsr=new FileStream(path,FileMode.OpenOrCreate,FileAccess.Read,FileShare.ReadWrite);
				
				sr=new StreamReader(fsr);
				fsw=new FileStream(path,FileMode.Append,FileAccess.Write,FileShare.ReadWrite);
				sw = new StreamWriter(fsw);
				//check in the file..
				
				


			}
			public override int Count{
				get
				{
					return (int)(fsr.Length/Record.len);
				}
			}
			public int Add(int n,ulong f){
				sw.WriteLine((n.ToString()).PadLeft(Record.lenN,' ')+","+(f.ToString()).PadLeft(Record.lenF,' '));
				sw.Flush();
				return (int)(sw.BaseStream.Length/Record.len-1);
			}

			public override object this[int n]
			{
				get{
					if(n<Count){
						sr.DiscardBufferedData();
						fsr.Seek(n*Record.len,SeekOrigin.Begin);
						
						return new Record(sr.ReadLine());
					}
					else{
						throw new Exception("");
					}
				}
			
				


			}
			public class Record{
				public const int lenN=8;
				public const int lenF=30;
				public const string sep=",";
				public const int lenS=1;
				public const int lenL=2;
				public const int len=lenN+lenS+lenF+lenL;
				public int n;
				public ulong f;
				public Record(string s){
					string[] ss=s.Split(',');
					this.n=int.Parse(ss[0]);
					this.f=ulong.Parse(ss[1]);

				}

			}	//sub subclass
		}	//sub class
			
	}	//class
}	//namespace
