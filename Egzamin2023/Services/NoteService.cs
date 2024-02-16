using System;
using Egzamin2023.Models;
namespace Egzamin2023.Services
{
	public class NoteService
	{
		private readonly IDateProvider _dateProvider;

		public NoteService(IDateProvider dateProvider)
		{
			_dateProvider = dateProvider;
		}

		private static List<Note> Notes = new();

		public void Add(Note note)
		{
			if (note.Deadline < _dateProvider.CurrentDate.AddHours(1))
				return;

			if (Notes.Where(x => x.Title.Equals(note.Title)).Count() != 0)
				return;

			Notes.Add(note);
		}

		public List<Note> GetAll() => Notes;

		public Note? GetById(string id) => Notes.SingleOrDefault(x => x.Title.Equals(id));
	}
}

