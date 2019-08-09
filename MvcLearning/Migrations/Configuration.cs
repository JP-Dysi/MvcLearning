namespace MvcLearning.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using MvcLearning.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcLearning.Models.MovieDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcLearning.Models.MovieDbContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.

			context.Movies.AddOrUpdate(i => i.Title, // update if already exists, based on Title
				new MovieModel
				{
					Title = "A New Hope",
					ReleaseDate = DateTime.Parse("25/5/1977"),
					Genre = "Space action",
					Price = 9.99M,
					Rating = "PG"
				},
				new MovieModel
				{
					Title = "The Empire Strikes Back",
					ReleaseDate = DateTime.Parse("21/5/1980"),
					Genre = "Space action",
					Price = 12M,
					Rating = "PG"

				},
				new MovieModel
				{
					Title = "Return of the Jedi",
					ReleaseDate = DateTime.Parse("25/5/1983"),
					Genre = "Space action",
					Price = 14.50M,
					Rating = "PG"
				},
				new MovieModel
				{
					Title = "The Phantom Menace",
					ReleaseDate = DateTime.Parse("19/5/1999"),
					Genre = "Comedy",
					Price = 22.2M,
					Rating = "PG"
				},
				new MovieModel
				{
					Title = "Attack of the Clones",
					ReleaseDate = DateTime.Parse("16/5/2002"),
					Genre = "Comedy",
					Price = 25M,
					Rating = "PG"
				},
				new MovieModel
				{
					Title = "Revenge of the Sith",
					ReleaseDate = DateTime.Parse("19/5/2005"),
					Genre = "Comedy",
					Price = 39.99M,
					Rating = "PG"
				},
				new MovieModel
				{
					Title = "The Force Awakens",
					ReleaseDate = DateTime.Parse("18/12/2015"),
					Genre = "Unknown",
					Price = 50M,
					Rating = "PG"
				},
				new MovieModel
				{
					Title = "The Last Jedi",
					ReleaseDate = DateTime.Parse("15/12/2017"),
					Genre = "Unknown",
					Price = 79M,
					Rating = "PG"
				},
				new MovieModel
				{
					Title = "The Rise of Skywalker",
					ReleaseDate = DateTime.Parse("20/12/2019"),
					Genre = "Unknown",
					Price = 100M,
					Rating = "PG"
				}
			);
        }
    }
}
