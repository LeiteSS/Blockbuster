using System.Collections.Generic;
using blockbuster.Model;

namespace blockbuster.Repository
{
    public class MediaRepository : IRepository<Media>
    {
        private List<Media> mediaList = new List<Media>();
        public void Create(Media entity)
        {
            mediaList.Add(entity);
        }

        public void Delete(int id)
        {
            mediaList[id].StatusDeleted();
        }

        public Media FindById(int id)
        {
            return mediaList[id];
        }

        public List<Media> ListAll()
        {
            return mediaList;
        }

        public int NextId()
        {
            return mediaList.Count;
        }

        public void Update(int id, Media entity)
        {
            mediaList[id] = entity;
        }
    }
}