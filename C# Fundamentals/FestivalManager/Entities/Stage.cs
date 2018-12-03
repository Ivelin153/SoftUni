namespace FestivalManager.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Stage : IStage
    {
        // да си вкарват през полетата бе
        private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets;

        public IReadOnlyCollection<ISong> Songs => this.songs;

        public IReadOnlyCollection<IPerformer> Performers => this.performers;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet performer)
        {
            this.sets.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            return this.performers.First(p => p.Name == name);
        }

        public ISet GetSet(string name)
        {
            return this.sets.First(p => p.Name == name);
        }

        public ISong GetSong(string name)
        {
            return this.songs.First(p => p.Name == name);
        }

        public bool HasPerformer(string name)
        {
            return this.performers.Exists(p => p.Name == name);
        }

        public bool HasSet(string name)
        {
            return this.sets.Exists(p => p.Name == name);
        }

        public bool HasSong(string name)
        {
            return this.songs.Exists(p => p.Name == name);
        }
    }
}