using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPractice
{
    #region Jukebox
    class Seacrh { public string Name { get; set; } }
    class Song { public string SongName { get; set; } }
    class Settings
    {
        public bool repeat { get; set; }
        public bool shuffle { get; set; }
    }
    interface ISrc
    {
        string Name { get; set; }
        Settings settings { get; set; }

        List<ISrc> GetCollections();
        List<Song> LoadSongs(ISrc s);

    }

    class CD : ISrc
    {
        public List<CD> CDcollections { get; set; }
        public List<Song> Songs { get; set; }
        public string Name { get; set; }
        public Settings settings { get; set; }

        public List<ISrc> GetCollections()
        {
            var i = new List<ISrc>();
            foreach (var item in CDcollections)
                i.Add(item);
            return i;

        }

        public List<Song> LoadSongs(ISrc s)
        {
            return CDcollections.Where(c => c.Name == s.Name).FirstOrDefault().Songs;
        }
    }

    class Jukebox
    {
        public List<ISrc> collections { get; set; }
        public List<Song> songs { get; set; }
        List<ISrc> LoadSrcs(ISrc src)
        {
            collections = src.GetCollections();
            return collections;
        }

        ISrc ChooseSrc(Seacrh srch) { return collections.Where(c => c.Name == srch.Name).FirstOrDefault(); }
        List<Song> LoadSongs(ISrc s) { return s.LoadSongs(s); }
        private void NextSong(ISrc s) { int a; if (s.settings.shuffle)a = 1; }
        private void preSong(ISrc s) { int a; if (s.settings.shuffle)a = 1; }
        private void playPauseSong(Song s) { }

    }
    #endregion Jukebox


    #region Cache Design
    public class CacheSolution
    {
        List<NodeLinkedList> res = new List<NodeLinkedList>();
        public int cap;
        public CacheSolution(int capacity)
        {

            cap = capacity;
        }

        public int get(int key)
        {
            var r = res.Where(i => i.key == key).FirstOrDefault();
            if (r != null)
            {
                res.Remove(r);
                res.Insert(0, r);
                return r.val;
            }
            return -1;
        }

        public void set(int key, int value)
        {

            var r = res.Where(i => i.key == key).FirstOrDefault();
            if (r != null)
            {
                return;
            }

            if (res.Count == cap)
            {
                res.RemoveAt(cap - 1);
                res.Add(new NodeLinkedList { key = key, val = value });
            }
            else
                res.Add(new NodeLinkedList { key = key, val = value });

        }

    }
    #endregion Cahce Design


}
