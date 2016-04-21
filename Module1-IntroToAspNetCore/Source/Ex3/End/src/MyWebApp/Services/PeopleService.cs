using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApp.Models;
using Microsoft.Data.Entity;

namespace MyWebApp.Services
{
	public interface IPeopleService
	{
		Task<List<Person>> GetAllPeopleAsync();
	}

	public class PeopleService : IPeopleService
    {
		private PeopleContext context;

		public PeopleService(PeopleContext context)
		{
			this.context = context;
		}

		public async Task<List<Person>> GetAllPeopleAsync()
		{
			return await context.Person.ToListAsync();
		}
    }
}
