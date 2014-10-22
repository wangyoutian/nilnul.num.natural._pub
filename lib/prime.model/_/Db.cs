using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural.prime.model
{
	public partial class Db
	{
		


		static public PrimeEntities2 CreateConnection()
		{

			return new PrimeEntities2(@"metadata=res://*/_prime.PrimeModel.csdl|res://*/_prime.PrimeModel.ssdl|res://*/_prime.PrimeModel.msl;provider=System.Data.SqlClient;provider connection string="";Data Source=.\sqlexpress;Initial Catalog=nilnulP;Integrated Security=True;MultipleActiveResultSets=True"";");

		}
	}
}
