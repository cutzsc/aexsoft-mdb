﻿using aexsoftmdb.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using aexsoftmdb.Models.ViewModels;

namespace aexsoftmdb.Components
{
	public class SearchDataViewComponent : ViewComponent
	{
		private IGenreRepository genreRepository;
		private IActorRepository actorRepository;

		public SearchDataViewComponent(IGenreRepository genreRepository, IActorRepository actorRepository) =>
			(this.genreRepository, this.actorRepository) = (genreRepository, actorRepository);

		public IViewComponentResult Invoke()
		{
			return View(new SearchDataViewModel()
			{
				Genres = genreRepository.Genres,
				Actors = actorRepository.Actors
			});
		}
	}
}
