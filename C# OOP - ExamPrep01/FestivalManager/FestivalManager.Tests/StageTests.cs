// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {

		private Stage stage = null;

		[SetUp]
		public void InitTest()
        {
			stage = new Stage();
        }

		[Test]
	    public void PerformerCannotBeNullInAddPerformer()
	    {

			Assert.Throws(typeof(ArgumentNullException), () => stage.AddPerformer(null));
		}

		[Test]
		public void PerformerUnder18InAddPerformer()
		{
			var performer = new Performer("Petar", "Petrov", 9);
			Assert.Throws(typeof(ArgumentException), () => stage.AddPerformer(performer));
		}

		[Test]
		public void PerformerAddedSuccessfullyInAddPerformer()
		{
			var performer = new Performer("Petar", "Petrov", 23);
			stage.AddPerformer(performer);

			Assert.That(stage.Performers.Count == 1);
			Assert.That(stage.Performers.FirstOrDefault().Equals(performer));
		}

		[Test]
		public void SongCannotBeNullInAddSong()
		{

			Assert.Throws(typeof(ArgumentNullException), () => stage.AddSong(null));
		}

		[Test]
		public void SongDurationUnderOneMinuteInAddSong()
		{
			var song = new Song("White rabbit", new TimeSpan(0, 0, 34));

			Assert.Throws(typeof(ArgumentException), () => stage.AddSong(song));
		}

		//[Test]
		//public void SongAddedSuccessfullyInAddSong()
		//{
		//	var song = new Song("White rabbit", new TimeSpan(0, 1, 34));
		//	stage.AddSong(song);

		//	Assert.That()
		//}

		[Test]
		public void SongNameAndPerformerNameMustNotBeNullInAddSongToPerformer()
        {
			Assert.Throws(typeof(ArgumentNullException), () => stage.AddSongToPerformer(null, "Pesho"));
			Assert.Throws(typeof(ArgumentNullException), () => stage.AddSongToPerformer("White rabbit", null));
		}

		[Test]
		public void AddSongToPerformerSongAdded()
		{
			var performer = new Performer("Petar", "Petrov", 23);
			var song = new Song("White rabbit", new TimeSpan(0, 1, 34));
			stage.AddPerformer(performer);
			stage.AddSong(song);

			stage.AddSongToPerformer("White rabbit", "Petar Petrov");

			Assert.That(performer.SongList.Count == 1);
			Assert.That(stage.Performers.FirstOrDefault().Equals(performer));

		}

		[Test]
		public void StagePlayReturnsRightNumbers()
		{
			var performer = new Performer("Petar", "Petrov", 23);
			var song = new Song("White rabbit", new TimeSpan(0, 1, 34));
			stage.AddPerformer(performer);
			stage.AddSong(song);

			stage.AddSongToPerformer("White rabbit", "Petar Petrov");

			string result = stage.Play();

			Assert.That(result == "1 performers played 1 songs");

		}

		[Test]
		public void AddSongToPerformerSongNotExist()
		{
			var performer = new Performer("Petar", "Petrov", 23);
			stage.AddPerformer(performer);

			Assert.Throws(typeof(ArgumentException), () => stage.AddSongToPerformer("White rabbit", "Petar Petrov"));
		}

		[Test]
		public void AddSongToPerformerPerformerNotExist()
		{
			var song = new Song("White rabbit", new TimeSpan(0, 1, 34));
			stage.AddSong(song);

			Assert.Throws(typeof(ArgumentException), () => stage.AddSongToPerformer("White rabbit", "Petar Petrov"));
		}
	}
}