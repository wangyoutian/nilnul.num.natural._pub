using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural.prime.model
{
	static public partial class DbX
	{
		


		static public PrimeEntities2 CreateConnection()
		{

			return new PrimeEntities2(@"metadata=res://*/prime.model.PrimeModel2.csdl|res://*/prime.model.PrimeModel2.ssdl|res://*/prime.model.PrimeModel2.msl;provider=System.Data.SqlClient;provider connection string="";Data Source=.\sqlexpress;Initial Catalog=nilnulP;Integrated Security=True;MultipleActiveResultSets=True"";");

		}
	}
}
