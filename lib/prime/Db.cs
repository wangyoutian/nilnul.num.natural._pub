using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nilnul.num.natural.prime
{
	public partial class Db
	{
		public const string ConnectionString = @"metadata=res://*/prime.db.Model1.csdl|res://*/prime.db.Model1.ssdl|res://*/prime.db.Model1.msl;provider=System.Data.SqlClient;provider connection string=""data source=(LocalDB)\v11.0;attachdbfilename=|DataDirectory|\prime\db.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework""";
#if DEBUG
		public const string ConnectionString2 = @"metadata=res://*/prime.db.Model2.csdl|res://*/prime.db.Model2.ssdl|res://*/prime.db.Model2.msl;provider=System.Data.SqlClient;provider connection string=""data source=.;initial catalog=nilnul3;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework""";
#else

		public const string ConnectionString2 = @"metadata=res://*/prime.db.Model2.csdl|res://*/prime.db.Model2.ssdl|res://*/prime.db.Model2.msl;provider=System.Data.SqlClient;provider connection string=""data source=tcp:s10.winhost.com;initial catalog=DB_24099_nilnul;User ID=DB_24099_nilnul_user;Password=;Integrated Security=False;MultipleActiveResultSets=True;App=EntityFramework""";


#endif

		public const string ConnectionString_winhost = @"metadata=res://*/prime.db.Model2.csdl|res://*/prime.db.Model2.ssdl|res://*/prime.db.Model2.msl;provider=System.Data.SqlClient;provider connection string=""data source=tcp:s10.winhost.com;initial catalog=DB_24099_nilnul;User ID=DB_24099_nilnul_user;Password=;Integrated Security=False;MultipleActiveResultSets=True;App=EntityFramework""";




		static public db.nilnul3Entities CreateConnection()
		{
		//	return new db.nilnul3Entities(ConnectionString2);
			return new db.nilnul3Entities(ConnectionString_winhost);
		}
	}
}
