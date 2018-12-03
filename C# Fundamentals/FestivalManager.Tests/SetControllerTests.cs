// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    //using FestivalManager.Core.Controllers;
    //using FestivalManager.Entities;
    //using FestivalManager.Entities.Instruments;
    //using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System.Text;

    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void CheckIfInstrumentsWearDown()
        {
            var stage = new Stage();
            var setContoler = new SetController(stage);

            var instrument = new Guitar();
            var performer = new Performer("Gosho", 21);
            performer.AddInstrument(instrument);
            stage.AddPerformer(performer);
            var song = new Song("song1", new System.TimeSpan(0, 0, 50));
            stage.AddSong(song);

            var set = new Short("Set1");
            set.AddPerformer(performer);
            stage.AddSet(set);
            set.AddSong(song);
            

            for (int i = 0; i < 2; i++)
            {
                setContoler.PerformSets();
            }
            Assert.That(instrument.IsBroken);
        }

        [Test]
        public void ChechIfOutputIsValid()
        {
            var expectedResult = new StringBuilder();
            expectedResult.AppendLine("1. Set1:")
                .AppendLine("-- 1. Song1 (05:00)")
                .AppendLine("-- 2. Song2 (05:00)")
                .AppendLine("-- 3. Song3 (05:00)")
                .AppendLine("-- Set Successful");

            var stage = new Stage();
            var setContoler = new SetController(stage);

            var currentResult = expectedResult.ToString().TrimEnd('\r', '\n');

            var instrument = new Guitar();
            var performer = new Performer("Gosho", 21);
            performer.AddInstrument(instrument);
            stage.AddPerformer(performer);
            var song1 = new Song("Song1", new System.TimeSpan(0, 5, 0));
            var song2 = new Song("Song2", new System.TimeSpan(0, 5, 0));
            var song3 = new Song("Song3", new System.TimeSpan(0, 5, 0));
            stage.AddSong(song1);
            stage.AddSong(song2);
            stage.AddSong(song3);
            


            var set = new Short("Set1");
            set.AddSong(song1);
            set.AddSong(song2);
            set.AddSong(song3);
            set.AddPerformer(performer);
            stage.AddSet(set);

            var result = setContoler.PerformSets();

            Assert.That(result.Equals(currentResult));
        }

        [Test]
        public void ChechIfSongsArePreformed()
        {
            var expectedResult = new StringBuilder();
            expectedResult.AppendLine("1. Set2:")
                .AppendLine("-- Did not perform");

            var stage = new Stage();
            var setContoler = new SetController(stage);

            var currentResult = expectedResult.ToString().TrimEnd('\r', '\n');

            var instrument = new Guitar();
            var performer = new Performer("Gosho", 21);
            performer.AddInstrument(instrument);
            stage.AddPerformer(performer);
            var song1 = new Song("Song1", new System.TimeSpan(0, 5, 0));
            var song2 = new Song("Song2", new System.TimeSpan(0, 5, 0));
            var song3 = new Song("Song3", new System.TimeSpan(0, 5, 0));
            stage.AddSong(song1);
            stage.AddSong(song2);
            stage.AddSong(song3);



            var set = new Short("Set2");
            set.AddPerformer(performer);
            stage.AddSet(set);

            var result = setContoler.PerformSets();

            Assert.That(result.Equals(currentResult));
        }
    }
}