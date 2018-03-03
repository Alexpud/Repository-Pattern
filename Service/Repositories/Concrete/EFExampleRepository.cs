using System.Collections.Generic;
using Service.Entities;
using Service.Repositories.Abstract;

namespace Service.Repositories.Concrete
{
	public class EFExampleRepository: BaseRepository<ExampleEntity>, IExampleRepository 
	{

		public EFExampleRepository(AppDbContext context) : base(context)
		{
		}
	}
}